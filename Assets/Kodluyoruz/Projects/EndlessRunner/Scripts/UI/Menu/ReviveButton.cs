using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;


public class ReviveButton : Button
{

    protected override void OnEnable()
    {
        base.OnEnable();
        if (Managers.Instance == null)
            return;

        onClick.AddListener(() => EventManager.OnLevelContine.Invoke());

    }

    protected override void OnDisable()
    {
        base.OnEnable();
        if (Managers.Instance == null)
            return;

        onClick.RemoveListener(() => EventManager.OnLevelContine.Invoke());
    }
}
