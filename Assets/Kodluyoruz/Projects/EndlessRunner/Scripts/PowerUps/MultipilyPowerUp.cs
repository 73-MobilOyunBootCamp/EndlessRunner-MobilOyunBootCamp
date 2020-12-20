using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class MultipilyPowerUp : PowerUpBase
{
    private GameObject effect;
    public override IEnumerator ExecuteCo()
    {
        yield return null;

    }

    public override void Use()
    {
        MagnetPowerUp magnetPowerUp = CharacterManager.Instance.Player.gameObject.AddComponent<MagnetPowerUp>();

        magnetPowerUp.Execute();
        Dispose();
    }

    public override void Interup()
    {
        base.Interup();
        
    }
}
