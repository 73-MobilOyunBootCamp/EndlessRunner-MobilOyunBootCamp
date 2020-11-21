using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public abstract class CollectableBase : MonoBehaviour, Icollectable
{
    [ValueDropdown("audioKeyList")]
    public string CollectSoundID;
    public GameObject DestroyParticlePrefab;

   
    private List<string> audioKeyList { get { return AudioKeys.AudioKeyList; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelFinish.AddListener(Dispose);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelFinish.RemoveListener(Dispose);
    }

    public virtual void Collect()
    {
        if(!string.IsNullOrEmpty(CollectSoundID))
            AudioManager.Instance.PlayOneShot2D(CollectSoundID);
    }

    public abstract void Use();

    public virtual void Dispose()
    {
        if(DestroyParticlePrefab != null)
            Instantiate(DestroyParticlePrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
