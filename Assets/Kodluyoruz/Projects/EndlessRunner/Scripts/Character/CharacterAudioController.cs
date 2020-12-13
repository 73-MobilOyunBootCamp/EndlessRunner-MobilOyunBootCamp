using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class CharacterAudioController : MonoBehaviour
{
    Character character;
    Character Character { get { return (character == null) ? character = GetComponent<Character>() : character; } }

    [ValueDropdown("audioKeyList")]
    public string JumpSound;

    [ValueDropdown("audioKeyList")]
    public string HitSound;

    [ValueDropdown("audioKeyList")]
    public string DeathSound;

    [ValueDropdown("audioKeyList")]
    public string SlideSound;

    [ValueDropdown("audioKeyList")]
    public string SwitchLane;

    private List<string> audioKeyList { get { return AudioKeys.AudioKeyList; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        Character.OnCharacterJump.AddListener(() => AudioManager.Instance.PlayOneShot2D(JumpSound));
        Character.OnCharacterHit.AddListener(() => AudioManager.Instance.PlayOneShot2D(HitSound));
        Character.OnCharacterDie.AddListener(() => AudioManager.Instance.PlayOneShot2D(DeathSound));
        Character.OnCharacterSlide.AddListener(() => AudioManager.Instance.PlayOneShot2D(SlideSound));
        Character.OnCharacterSwitchLane.AddListener(() => AudioManager.Instance.PlayOneShot2D(SwitchLane));

    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        Character.OnCharacterJump.RemoveListener(() => AudioManager.Instance.PlayOneShot2D(JumpSound));
        Character.OnCharacterHit.RemoveListener(() => AudioManager.Instance.PlayOneShot2D(HitSound));
        Character.OnCharacterDie.RemoveListener(() => AudioManager.Instance.PlayOneShot2D(DeathSound));
        Character.OnCharacterSlide.RemoveListener(() => AudioManager.Instance.PlayOneShot2D(SlideSound));
        Character.OnCharacterSwitchLane.RemoveListener(() => AudioManager.Instance.PlayOneShot2D(SwitchLane));
    }
}
