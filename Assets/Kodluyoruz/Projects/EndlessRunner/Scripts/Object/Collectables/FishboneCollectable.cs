using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;


public class FishboneCollectable : CollectableBase
{
    private bool isStarted;

    public override void Collect()
    {
        base.Collect();
        Use();
    }

    public override void Use()
    {
        var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
        playerData.CoinAmount += 1;
        SaveLoadManager.SavePDP(playerData, SavedFileNameHolder.PlayerData);
        Dispose();

    }

    private void Update()
    {
        
    }
}
