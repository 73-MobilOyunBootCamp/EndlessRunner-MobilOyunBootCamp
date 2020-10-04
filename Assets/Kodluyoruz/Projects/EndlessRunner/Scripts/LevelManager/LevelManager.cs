using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public LevelData LevelData;
    public Theme CurrentTheme = Theme.Industrial;


    private bool isLevelStarted;

    public void Initilize()
    {
        TrackManager.Instance.Initilize();
    }

    public void StartLevel()
    {
        if (isLevelStarted)
            return;

        isLevelStarted = true;
        EventManager.OnLevelStart.Invoke();
    }

    public void FinishLevel()
    {
        if (!isLevelStarted)
            return;

        isLevelStarted = false;
        EventManager.OnLevelFinish.Invoke();
    }
    
}
