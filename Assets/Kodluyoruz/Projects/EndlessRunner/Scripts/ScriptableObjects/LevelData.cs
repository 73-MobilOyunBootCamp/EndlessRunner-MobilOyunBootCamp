using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum Theme { Industrial = 0, Suburbs = 1, Urban = 2 }
public enum LevelObjectType { Obstacle, PowerUp, Coin}


[System.Serializable]
public class LevelObjectData
{
    public LevelObjectType LevelObjectType;

    public List<GameObject> ObjectsToCreate = new List<GameObject>();
}

[System.Serializable]
public class ThemeData
{
    public Theme Theme;
    public List<GameObject> Tracks = new List<GameObject>();
    public List<LevelObjectData> LevelObjectDatas = new List<LevelObjectData>();
}

[System.Serializable]
public class PowerUpData
{
    public List<GameObject> PowerUpPrefabs;
}

[CreateAssetMenu(fileName = "Endless Runner Level Data", menuName = "Endless Runner/Level Data")]
public class LevelData : ScriptableObject
{
    [InlineEditor(InlineEditorModes.GUIOnly)]
    public List<Level> Levels = new List<Level>();
}
