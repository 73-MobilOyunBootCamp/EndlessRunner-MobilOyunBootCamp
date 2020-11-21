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
        EventManager.OnLevelFail.AddListener(StopAllCoroutines);
        EventManager.OnLevelSuccess.AddListener(StopAllCoroutines);

    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnObstacleCreated.RemoveListener(CreateCoins);
        EventManager.OnLevelFinish.RemoveListener(StopAllCoroutines);
        EventManager.OnLevelSuccess.RemoveListener(StopAllCoroutines);
    }

    private void CreateCoins()
    {
        LaneObject laneObject = TrackManager.Instance.Lanes[Random.Range(0, TrackManager.Instance.Lanes.Count)];
        int targetCoinCount = Random.Range(5, 10);

        StartCoroutine(CreateCoinsCo(laneObject, targetCoinCount));
    }

    private IEnumerator CreateCoinsCo(LaneObject laneObject, int targetCoinCount)
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        for (int i = 0; i < targetCoinCount; i++)
        {
            GameObject coin = LevelManager.Instance.CurrentLevel.GetRandomLevelObject(LevelObjectType.Coin);
            Instantiate(coin, laneObject.transform.position + Vector3.up, Quaternion.identity, TrackManager.Instance.Tracks[TrackManager.Instance.Tracks.Count - 1].transform);
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }
}
