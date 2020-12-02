using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class MagnetPowerUp : PowerUpBase
{
    private GameObject effect;
    public override IEnumerator ExecuteCo()
    {
        yield return null;
    }

    public override void Use()
    {
       
    }

    public override void Interup()
    {
        base.Interup();
    }
}
