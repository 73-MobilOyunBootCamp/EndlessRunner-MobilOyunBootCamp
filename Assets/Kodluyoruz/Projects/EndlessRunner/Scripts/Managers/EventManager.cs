﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameEnd = new UnityEvent();

    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelContine = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();

    public static UnityEvent OnLevelSuccess = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();

    public static SwipeEvent OnSwipeDetected = new SwipeEvent();
    public static UnityEvent OnTapDetected = new UnityEvent();
    public static UnityEvent OnSwipeFail = new UnityEvent();

    public static UnityEvent OnObstacleCreated = new UnityEvent();

    public static UnityEvent OnPlayerStartedRunning = new UnityEvent();

    public static PlayerDataEvent OnPlayerDataUpdated = new PlayerDataEvent();
}

public class SwipeEvent : UnityEvent<Swipe, Vector2> { }
public class PlayerDataEvent : UnityEvent<PlayerData> { }
