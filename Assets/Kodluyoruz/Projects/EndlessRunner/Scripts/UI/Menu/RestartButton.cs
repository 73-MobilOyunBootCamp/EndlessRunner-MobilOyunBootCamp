using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;


public class RestartButton : Button
{

    protected override void OnEnable()
    {
        base.OnEnable();
        if (Managers.Instance == null)
            return;

        onClick.AddListener(() => LevelManager.Instance.FinishLevel());
        onClick.AddListener(() => GameManager.Instance.EndGame());

    }

    protected override void OnDisable()
    {
        base.OnEnable();
        if (Managers.Instance == null)
            return;

        onClick.RemoveListener(() => LevelManager.Instance.FinishLevel());
        onClick.RemoveListener(() => GameManager.Instance.EndGame());

    }
}
