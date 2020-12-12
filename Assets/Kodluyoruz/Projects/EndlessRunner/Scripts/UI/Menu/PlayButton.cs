using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayButton : Button
{
   

    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(StartGame);
    }

    protected override void OnDisable()
    {
        base.OnEnable();
        onClick.RemoveListener(StartGame);
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }
}
