using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[CreateAssetMenu(fileName = "Endless Runner Level", menuName = "Endless Runner/Level Data")]
public class Level : ScriptableObject
{
    [Header("Theme Data")]
    public List<ThemeData> ThemeDatas = new List<ThemeData>();
    [Header("Difficulity Data")]
    [InlineEditor(InlineEditorModes.GUIOnly)]
    public List<DifficulityData> DifficulityData = new List<DifficulityData>();

    public PowerUpData PowerUpData;

    [Range(0, 1000)]
    public int UnlockPrice = 0;


    public GameObject GetRandomTrack(Theme theme)
    {
        try
        {
            for (int i = 0; i < ThemeDatas.Count; i++)
            {
                if (theme == ThemeDatas[i].Theme)
                {
                    return ThemeDatas[i].Tracks[Random.Range(0, ThemeDatas[i].Tracks.Count)];
                }
            }
            Debug.LogError("Theme Prefab is null");
            return null;
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Can't find a theme prefab " + ex.ToString());
            return null;
        }
    }

    public GameObject GetRandomLevelObject(LevelObjectType levelObjectType)
    {
        try
        {
            Theme theme = LevelManager.Instance.CurrentTheme;
            for (int i = 0; i < ThemeDatas.Count; i++)
            {
                if (theme == ThemeDatas[i].Theme)
                {
                    for (int j = 0; j < ThemeDatas[i].LevelObjectDatas.Count; j++)
                    {
                        if(ThemeDatas[i].LevelObjectDatas[j].LevelObjectType == levelObjectType)
                            return ThemeDatas[i].LevelObjectDatas[j]
                                .ObjectsToCreate[Random.Range(0, ThemeDatas[i]
                                .LevelObjectDatas[j].ObjectsToCreate.Count)];
                    }
                }
            }
            Debug.LogError("Theme Level Object is null");
            return null;
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Can't find the theme level object " + ex.ToString());
            return null;
        }
    }
}
