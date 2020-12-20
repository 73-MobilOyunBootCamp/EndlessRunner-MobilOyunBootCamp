using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnObstacleCreated.AddListener(CreateCoins);

    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnObstacleCreated.RemoveListener(CreateCoins);
    }

    private void CreateCoins()
    {
        LaneObject laneObject = TrackManager.Instance.GetRandomLane();
        int targetCoinCount = Random.Range(5, 10);

        StartCoroutine(CreateCoinsCo(laneObject,targetCoinCount));
    }

    private IEnumerator CreateCoinsCo(LaneObject laneObject, int targetCoinCount)
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));//coinleri obstacle oluşturduktan sonra yapacagız aralarında bosluk olsun diye boyle yapıyoruz.

        for(int i = 0; i < targetCoinCount; i++)
        {
            GameObject coinObject = LevelManager.Instance.CurrentLevel.GetRandomLevelObject(LevelObjectType.Coin);
            Instantiate(coinObject, laneObject.transform.position + Vector3.up, Quaternion.identity,
                TrackManager.Instance.GetLastTrackObject().transform);
            yield return new WaitForSeconds(0.2f);

        }
        yield return null;
    }

    private void CreatePowerUp()
    {
        
    }
}
