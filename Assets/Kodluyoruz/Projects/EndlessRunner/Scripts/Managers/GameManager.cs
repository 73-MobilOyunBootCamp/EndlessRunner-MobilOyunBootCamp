using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameStarted;


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
