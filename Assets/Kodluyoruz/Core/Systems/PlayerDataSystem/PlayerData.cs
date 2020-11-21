using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[System.Serializable]
public class PlayerData
{
    [SerializeField]
    private int coinAmount;
    public int CoinAmount { get { return coinAmount; } set { coinAmount = value; EventManager.OnPlayerDataUpdated.Invoke(this); } }

    private int currentHealth;
    public int CurrentHelath { get { return currentHealth; } set { currentHealth = value; EventManager.OnPlayerDataUpdated.Invoke(this); } }
}