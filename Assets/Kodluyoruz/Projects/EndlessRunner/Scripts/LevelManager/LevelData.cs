using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Theme { Industrial = 0, Suburbs = 1, Urban = 2 }
public enum LevelObjectType { Obstacle, PowerUp, Coin}


[System.Serializable]
public class LevelObjectData
{
    public LevelObjectType LevelObjectType;

    public List<GameObject> ObjectsToCreate = new List<GameObject>();

    [Tooltip("Use this as a spawn percentage to determan the chance of this object being created when level creates a level object")]
    [Range(1, 100)]
    public float SpawnRetrio = 1f;
}

[System.Serializable]
public class ThemeData
{
    public Theme Theme;
    public List<GameObject> Tracks = new List<GameObject>();
    public List<LevelObjectData> LevelObjectDatas = new List<LevelObjectData>();
}

[CreateAssetMenu(fileName = "Endless Runner Level Data", menuName = "Endless Runner/Level Data")]
public class LevelData : ScriptableObject
{
    public List<ThemeData> ThemeDatas = new List<ThemeData>();


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

    public GameObject GetRandomLevelObject(Theme theme, LevelObjectType levelObjectType)
    {
        try
        {
            for (int i = 0; i < ThemeDatas.Count; i++)
            {
                if (theme == ThemeDatas[i].Theme)
                {
                    for (int j = 0; j < ThemeDatas[i].LevelObjectDatas.Count; j++)
                    {
                        return ThemeDatas[i].LevelObjectDatas[j].ObjectsToCreate[Random.Range(0, ThemeDatas[i].LevelObjectDatas[j].ObjectsToCreate.Count)];

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
