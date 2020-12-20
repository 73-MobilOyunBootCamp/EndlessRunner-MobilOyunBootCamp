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
        MultipilyPowerUp multipilyPowerUp = CharacterManager.Instance.Player.gameObject.AddComponent<MultipilyPowerUp>();
        multipilyPowerUp.Initialize(this);
        multipilyPowerUp.Execute();

    }

    public override void Interup()
    {
        base.Interup();
        
    }
}
