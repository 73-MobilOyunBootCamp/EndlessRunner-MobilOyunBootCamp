using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public abstract class PowerUpBase : CollectableBase, IPowerUp
{
    public GameObject PowerUpDisplayPrefab;
    protected GameObject effect;

    public override void Collect()
    {
        base.Collect();

        var powerUpInUse = CharacterManager.Instance.Player.GetComponent<IPowerUp>();
        if (powerUpInUse != null)
            powerUpInUse.Interup();

        Use();
    }

    public virtual void Interup()
    {
        if (effect != null)
            Destroy(effect);
        StopAllCoroutines();
        Destroy(this);
    }

    public void Initialize(PowerUpBase powerUpBase)
    {
        CollectSoundID = powerUpBase.CollectSoundID;
        CollectParticlePrefab = powerUpBase.CollectParticlePrefab;
        PowerUpDisplayPrefab = powerUpBase.PowerUpDisplayPrefab;
    }

    public void Execute()
    {
        StartCoroutine(ExecuteCo());
    }

    public abstract IEnumerator ExecuteCo();

}
