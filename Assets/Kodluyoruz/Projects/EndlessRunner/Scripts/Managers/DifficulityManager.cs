using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DifficulityManager : MonoBehaviour
{

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
}
