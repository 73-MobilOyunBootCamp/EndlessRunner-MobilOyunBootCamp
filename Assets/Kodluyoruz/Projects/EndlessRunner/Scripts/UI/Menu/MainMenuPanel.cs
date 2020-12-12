using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : Panel
{

    private void OnEnable()
    {
        //Singleton hatası almamak için bir check
        //Kişisel bir tercihtir.
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.AddListener(HidePanel);
        EventManager.OnGameEnd.AddListener(ShowPanel);
        
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.RemoveListener(HidePanel);
        EventManager.OnGameEnd.RemoveListener(ShowPanel);
    }
}
