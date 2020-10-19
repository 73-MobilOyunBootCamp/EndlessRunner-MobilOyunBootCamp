using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Endless Runner Level", menuName = "Endless Runner/Level Data")]
public class Level : ScriptableObject
{
    public List<ThemeData> ThemeDatas = new List<ThemeData>();
    public List<DifficulityData> DifficulityData = new List<DifficulityData>();


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

                    return ThemeDatas[i].LevelObjectDatas[(int)theme].ObjectsToCreate[Random.Range(0, ThemeDatas[i].LevelObjectDatas[(int)theme].ObjectsToCreate.Count)];
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
