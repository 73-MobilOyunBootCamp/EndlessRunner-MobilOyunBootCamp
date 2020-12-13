using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleManager : Singleton<ObstacleManager>
{

    private float lastObstacleCreateTime;
    private float obstacleCreateWaitTime;

    private bool canCreateObstacles;

    private void Start()
    {
        obstacleCreateWaitTime = Random.Range(3f, 6f);
    }

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

    private void Update()
    {
        SpawnObstacles();
    }


    public void SpawnObstacles()
    {
        if (Time.time < lastObstacleCreateTime + obstacleCreateWaitTime) //Oyun süresine bak, obstacle oluşturma süresi + bekleme süresinden küçükse return
        {
            return;
        }
        float chance = Random.Range(0f, 100f);
        if (chance < LevelManager.Instance.DifficulityData.ObstacleSpawnRetrio)
        {
            lastObstacleCreateTime = Time.time; //Obstacle üretmiyoruz, üretmiş gibi yapıyoruz.
            EventManager.OnObstacleCreated.Invoke();
            return;
        }

        List<LaneObject> laneObjects = new List<LaneObject>(TrackManager.Instance.Lanes);
        laneObjects.Shuffle();
        laneObjects.RemoveAt(Random.Range(0, laneObjects.Count));

        float chanceForAnotherObstacle = Random.Range(0f, 1f);
        lastObstacleCreateTime = Time.time; 
        for (int i = 0; i < laneObjects.Count; i++)
        {
            if (chanceForAnotherObstacle > 0.5f)
            {
                CreateObstacle(laneObjects[i].transform.position);
                chanceForAnotherObstacle = 0;
                continue;
            }
            CreateObstacle(laneObjects[i].transform.position);
            break;
        }
        EventManager.OnObstacleCreated.Invoke();
    }
    private GameObject CreateObstacle(Vector3 position)
    {
        return Instantiate(LevelManager.Instance.CurrentLevel.GetRandomLevelObject(LevelObjectType.Obstacle), 
            position, Quaternion.identity, TrackManager.Instance.Tracks[TrackManager.Instance.Tracks.Count-1].transform);
    
    }
}
