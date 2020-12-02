using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class CollectableBase : MonoBehaviour, Icollectable
{
    [ValueDropdown("audioKeyList")]
    public string CollectSoundID;
    public GameObject CollectParticlePrefab;

   
    private List<string> audioKeyList { get { return AudioKeys.AudioKeyList; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

    }

    public virtual void Collect()
    {
        
    }

    public abstract void Use();

    public virtual void Dispose()
    {

    }
}
