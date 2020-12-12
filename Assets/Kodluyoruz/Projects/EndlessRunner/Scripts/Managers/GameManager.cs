﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class GameData
{
    public int PointMultiplier;
    public float MultiplyTimer;
    public float MagnetTimer;
    public bool IsMagnetActive;
}

public class GameManager : Singleton<GameManager>
{
    private bool isGameStarted;
    [ShowInInspector]
    [ReadOnly]
    public bool IsGameStarted { get { return isGameStarted; } private set { isGameStarted = value; } }

    public GameData GameData = new GameData();

    public void StartGame()
    {
        if (isGameStarted)
            return;

        isGameStarted = true;
        EventManager.OnGameStart.Invoke();
    }

    public void EndGame()
    {
        if (!isGameStarted)
            return;

        isGameStarted = false;
        EventManager.OnGameEnd.Invoke();
    }
}
