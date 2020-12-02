using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;


public class HealthPanel : Panel
{

    public List<Image> HeartImages = new List<Image>();

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

    }

    private void UpdateHealth(PlayerData playerData)
    {
       
    }
}
