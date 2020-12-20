using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;


public class CoinPanel : Panel
{

    public TextMeshProUGUI CoinText;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnPlayerDataUpdated.AddListener(UpdateCoinText);
        EventManager.OnGameStart.AddListener(InitilizePanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
       
        EventManager.OnPlayerDataUpdated.RemoveListener(UpdateCoinText);
        EventManager.OnGameStart.RemoveListener(InitilizePanel);
    }

    private void InitilizePanel()
    {
        var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
        UpdateCoinText(playerData);
    }


    private void UpdateCoinText(PlayerData playerData)
    {
        CoinText.SetText(playerData.CoinAmount.ToString());
    }
}
