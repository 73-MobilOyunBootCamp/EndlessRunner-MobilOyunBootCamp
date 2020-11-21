using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class FishboneCollectable : CollectableBase
{

    public override void Collect()
    {
        base.Collect();
        Use();
    }

    public override void Use()
    {
        var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
        playerData.CoinAmount++;
        SaveLoadManager.SavePDP(playerData, SavedFileNameHolder.PlayerData);
        Dispose();
    }
}
