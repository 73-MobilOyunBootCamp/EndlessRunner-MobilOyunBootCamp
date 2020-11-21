using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.IO;
using System.Linq;

[CreateAssetMenu(fileName = "Audio Data", menuName = "Audio/Audio Data")]
public class AudioData : SerializedScriptableObject
{
    [OnValueChanged("SetDirtyEd")]
    public Dictionary<string, AudioClip> AudioClips = new Dictionary<string, AudioClip>();

    private void SetDirtyEd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
    [FolderPath]
    public string pathToCsv;
    [Button]
    public void ExportSoundDictinary()
    {
#if UNITY_EDITOR
        File.WriteAllLines(pathToCsv + "/" + this.name + ".text", AudioClips.Select(x => x.Key + ": " + x.Value.name + "|"));
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}
