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
        playerData.CoinAmount += 1 * GameManager.Instance.GameData.PointMultiplier;
        SaveLoadManager.SavePDP(playerData, SavedFileNameHolder.PlayerData);
        Dispose();
    }

    private void Update()
    {
        if (!GameManager.Instance.GameData.IsMagnetActive && !isStarted)
        {
            return;
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 toOther = CharacterManager.Instance.Player.transform.position - transform.position;

        if (Vector3.Dot(forward, toOther) > 0 )
        {
            return;
        }

        float distToPlayer = Vector3.Distance(transform.position, CharacterManager.Instance.Player.transform.position);

        if (distToPlayer < 10f)
        {
            isStarted = true;
            float speed = 30 - distToPlayer;
            speed = speed * Time.deltaTime * 0.5f;
            transform.position = Vector3.MoveTowards(transform.position, CharacterManager.Instance.Player.transform.position + Vector3.up, speed);
        }
    }
}
