using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
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

    private void CreateCoins()
    {
       
    }

    private IEnumerator CreateCoinsCo(LaneObject laneObject, int targetCoinCount)
    {
        
        yield return null;
    }

    private void CreatePowerUp()
    {
        
    }
}
