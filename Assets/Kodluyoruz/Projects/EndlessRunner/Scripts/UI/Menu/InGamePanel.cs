using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class InGamePanel : Panel
{


    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.AddListener(ShowPanel);
        EventManager.OnGameEnd.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.RemoveListener(ShowPanel);
        EventManager.OnGameEnd.RemoveListener(HidePanel);
    }
}
