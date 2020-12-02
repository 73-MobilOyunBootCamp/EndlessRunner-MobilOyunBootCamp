﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class HealthPowerUp : PowerUpBase
{
    public override IEnumerator ExecuteCo()
    {
        throw new System.NotImplementedException();
    }

    public override void Use()
    {
        CharacterManager.Instance.Player.HealCharacter();
        Instantiate(PowerUpDisplayPrefab, CharacterManager.Instance.Player.transform.position,
            Quaternion.identity,
            CharacterManager.Instance.Player.transform);

        Dispose();
    }
}
