using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LevelManager : Singleton<LevelManager>
{
    [InlineEditor(InlineEditorModes.GUIOnly)]
    public LevelData LevelData;
    public Theme CurrentTheme = Theme.Industrial;


    //Public Properities about current Level
    public Level CurrentLevel { get { return (LevelData.Levels[LevelIndex]); } }
    public DifficulityData DifficulityData { get { return (LevelData.Levels[LevelIndex].DifficulityData[DifficulityIndex]); } }
    public ThemeData CurrentThemeData { get { return (LevelData.Levels[LevelIndex].ThemeDatas[(int)CurrentTheme]); } }


    private bool isLevelStarted;
    [ShowInInspector]
    [ReadOnly]
    public bool IsLevelStarted { get { return isLevelStarted; } private set { isLevelStarted = value; } }

    public int LevelIndex
    {
        get
        {
            return PlayerPrefs.GetInt("LastLevel", 0);
        }
        set
        {
            if (value >= LevelData.Levels.Count)
                value = 0;

            PlayerPrefs.SetInt("LastLevel", value);
        }
    }

    public int DifficulityIndex { get; set; }

    public void StartLevel()
    {
        if (IsLevelStarted)
        {
            return;
        }

        IsLevelStarted = true;
        EventManager.OnLevelStart.Invoke();
    }

    public void FinishLevel()
    {
        if (!IsLevelStarted)
        {
            return;
        }

        IsLevelStarted = false;
        EventManager.OnLevelFinish.Invoke();
    }
    
}
