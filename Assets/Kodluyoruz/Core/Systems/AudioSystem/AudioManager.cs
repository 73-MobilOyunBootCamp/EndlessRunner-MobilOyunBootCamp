using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    public List<AudioData> AudioDatas = new List<AudioData>();

    private Dictionary<string, AudioClip> audioClips;
    public Dictionary<string, AudioClip> AudioClips
    {
        get
        {
            if (audioClips == null)
            {
                audioClips = new Dictionary<string, AudioClip>();
                for (int i = 0; i < AudioDatas.Count; i++)
                {
                    foreach (var item in AudioDatas[i].AudioClips)
                    {
                        audioClips.Add(item.Key, item.Value);
                    }
                }
            }
            return audioClips;
        }
    }

    public bool isMute
    {
        get
        {
            return (PlayerPrefs.GetInt(PlayerPrefKeys.SoundStatus, 0) == 1) ? true : false;
        }
    }

    public AudioMixer AudioMixer;
    public AudioMixerGroup MusicGroup;
    public AudioMixerGroup SFXGroup;

    private void Start()
    {
        ToggleAudio();
    }

    public void MuteMasterSound()
    {
        AudioMixer.SetFloat("MasterVolume", -80f);
        PlayerPrefs.SetInt(PlayerPrefKeys.SoundStatus, 1);
    }

    public void UnmuteMasterSound()
    {
        PlayerPrefs.SetInt(PlayerPrefKeys.SoundStatus, 0);
        AudioMixer.SetFloat("MasterVolume", 0f);
    }

    public void ToggleAudio()
    {
        if (isMute)
            MuteMasterSound();
        else UnmuteMasterSound();
    }

    public AudioSource PlayOneShot2D(string clipName, float volume = 1f, float pitch = 1f, Action OnCompilate = null)
    {
        AudioSource audioSource = GetSource(volume, pitch);
        audioSource.spatialBlend = 0;
        audioSource.PlayOneShot(AudioClips[clipName]);
        audioSource.outputAudioMixerGroup = SFXGroup;
        OnClipEnd(clipName, OnCompilate);
        return audioSource;
    }

    public AudioSource PlayOneShot3D(string clipName, Vector3 position, float volume = 1f, float pitch = 1f, Action OnCompilate = null)
    {
        AudioSource audioSource = GetSource(volume, pitch);
        audioSource.transform.position = position;
        audioSource.spatialBlend = 1;
        audioSource.PlayOneShot(AudioClips[clipName]);
        audioSource.outputAudioMixerGroup = SFXGroup;
        OnClipEnd(clipName, OnCompilate);
        return audioSource;
    }

    public AudioSource PlayLooping(string clipName, float volume = 1f, float pitch = 1f, float spaitialBlend = 0f)
    {
        AudioSource audioSource = GetSource(volume, pitch);
        audioSource.spatialBlend = spaitialBlend;
        audioSource.clip = AudioClips[clipName];
        audioSource.loop = true;
        audioSource.outputAudioMixerGroup = SFXGroup;
        audioSource.Play();
        return audioSource;
    }

    private AudioSource GetSource(float volume, float pitch)
    {
        AudioSource audioSource = PoolingSystem.Instance.GetAudioSource();
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        return audioSource;
    }

    /// <summary>
    /// Things to do on clip start.
    /// </summary>
    /// <param name="clipName">ClipName to add to NowPlayingList.</param>
    /// <param name="onClipStart">Actions to be taken on clip start.</param>
    private void OnClipStart(string clipName, Action onClipStart = null)
    {
        onClipStart?.Invoke();
    }

    /// <summary>
    /// Things to do on clip end.
    /// </summary>
    /// <param name="clipName">ClipName to add to NowPlayingList.</param>
    /// <param name="clipDuration">ClipDuration to wait for (needs to be in milliseconds and an integer number).</param>
    /// <param name="onClipEnd">Actions to be taken on clip end.</param>
    /// <returns></returns>
    private async Task OnClipEnd(string clipName, Action onClipEnd = null)
    {
        var clipDuration = (int)(audioClips[clipName].length * 1000);
        await Task.Delay(clipDuration);
        //if (toBeDestroyed != null)
        //    Destroy(toBeDestroyed);

        onClipEnd?.Invoke();
    }
}
