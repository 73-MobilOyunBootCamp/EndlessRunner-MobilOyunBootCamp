using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public abstract class PowerUpBase : CollectableBase, IPowerUp
{
    public GameObject PowerUpDisplayPrefab;


    public override void Collect()
    {
        base.Collect();
    }

    public virtual void Interup()
    {
        
    }

    public void Initialize(PowerUpBase powerUpBase)
    {
        
    }

    public void Execute()
    {
        StartCoroutine(ExecuteCo());
    }

    public abstract IEnumerator ExecuteCo();

}
