using System.Collections;
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
        // Güvence altına aldık sadece bir kere çalışmasını istiyoruz.
        if (IsGameStarted)
        {
            return;
        }

        IsGameStarted = true;
        EventManager.OnGameStart.Invoke(); 
    }

    //Bu tarz metotlardan GameManager sorumlu olmalı. Bu yüzden play butonunun içine yazmadık.
    //Bu Manageri başka projelerde kullanabilmeliyim.
    //Bir sorun olduğunda yerini bulması daha kolay olur.
    public void EndGame()
    {
        if (!IsGameStarted)
        {
            return;
        }

        IsGameStarted = false;
        EventManager.OnGameEnd.Invoke();        
    }
}
