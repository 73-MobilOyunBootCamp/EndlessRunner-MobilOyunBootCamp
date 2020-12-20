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

        EventManager.OnPlayerDataUpdated.AddListener(UpdateHealth);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnPlayerDataUpdated.RemoveListener(UpdateHealth);
    }

    private void UpdateHealth(PlayerData playerData)
    {
        if (playerData.CurrentHelath > HeartImages.Count)
        {
            return;
        }

        foreach (var item in HeartImages)
        {
            item.enabled = false;
        }

        for (int i = 0; i < playerData.CurrentHelath; i++)
        {
            HeartImages[i].enabled = true;
        }
    }
}
