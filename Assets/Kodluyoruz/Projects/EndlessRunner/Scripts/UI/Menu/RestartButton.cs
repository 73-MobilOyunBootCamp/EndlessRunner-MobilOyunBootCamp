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

        

    }

    protected override void OnDisable()
    {
        base.OnEnable();
        if (Managers.Instance == null)
            return;

        

    }
}
