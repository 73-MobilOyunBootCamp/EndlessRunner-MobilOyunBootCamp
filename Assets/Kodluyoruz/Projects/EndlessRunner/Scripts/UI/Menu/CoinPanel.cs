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

        
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

       
    }

    private void InitilizePanel()
    {
        
    }


    private void UpdateCoinText(PlayerData playerData)
    {
        
    }
}
