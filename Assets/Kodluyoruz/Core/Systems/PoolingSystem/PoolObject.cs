using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelFinish.AddListener(() => PoolingSystem.Instance.DestroyAPS(gameObject));
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelFinish.RemoveListener(() => PoolingSystem.Instance.DestroyAPS(gameObject));
    }
}
