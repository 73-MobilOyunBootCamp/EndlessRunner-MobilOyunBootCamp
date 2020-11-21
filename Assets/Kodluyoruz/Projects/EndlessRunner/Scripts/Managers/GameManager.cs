using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : Singleton<GameManager>
{
    private bool isGameStarted;
    [ShowInInspector]
    [ReadOnly]
    public bool IsGameStarted { get { return isGameStarted; } private set { isGameStarted = value; } }


    public void StartGame()
    {
        if (IsGameStarted)
            return;

        IsGameStarted = true;
        EventManager.OnGameStart.Invoke();
    }

    public void EndGame()
    {
        if (!isGameStarted)
            return;

        IsGameStarted = false;
        EventManager.OnGameEnd.Invoke();
    }
}
