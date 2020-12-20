using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class HealthPowerUp : PowerUpBase
{
    public override void Collect()
    {
        if (!string.IsNullOrEmpty(CollectSoundID))
            AudioManager.Instance.PlayOneShot2D(CollectSoundID);

        if (CollectParticlePrefab != null)
            Instantiate(CollectParticlePrefab, transform.position, Quaternion.identity);

        Use();
    }

    public override void Use()
    {
        CharacterManager.Instance.Player.GetComponent<IHealable>().Heal();
        Instantiate(PowerUpDisplayPrefab,
            CharacterManager.Instance.Player.transform.position,
            Quaternion.identity,
            CharacterManager.Instance.Player.transform);

        Dispose();
    }
}