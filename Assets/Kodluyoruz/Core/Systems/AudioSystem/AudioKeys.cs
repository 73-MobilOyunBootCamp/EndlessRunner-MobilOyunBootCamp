
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

public static class AudioKeys
{
    public static readonly string None = "None";
    public static readonly string ButtonClick = "ButtonClick";
    public static readonly string PopUpOpen = "PopUpOpen";
    public static readonly string PopUpClose = "PopUpClose";
    public static readonly string GameWinSound = "GameWinSound";
    public static readonly string GameLoseSound = "GameLoseSound";
    public static readonly string FishboneCollect = "FishboneCollect";
    public static readonly string TrashCanHitSound = "TrashCanHitSound";
    public static readonly string RatHit = "RatHit";
    public static readonly string DogHit = "DogHit";
    public static readonly string BarrierHitSound = "BarrierHitSound";

    private static List<string> audioKeyList;

    public static List<string> AudioKeyList
    {
        get
        {
            audioKeyList = new List<string>();
            audioKeyList.Add(string.Empty);
            List<AudioData> audioDatas = new List<AudioData>();
#if UNITY_EDITOR
            audioDatas = Utilities.FindAssetsByType<AudioData>();
#else
            audioDatas = new List<AudioData>(AudioManager.Instance.AudioDatas);
#endif
            for (int i = 0; i < audioDatas.Count; i++)
            {
                foreach (var keys in audioDatas[i].AudioClips.Keys)
                {
                    audioKeyList.Add(keys);
                }
            }

            return audioKeyList;
        }
    }

}
