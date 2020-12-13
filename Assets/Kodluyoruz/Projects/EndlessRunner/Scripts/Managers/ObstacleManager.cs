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
        SpawnObstacle();
    }


    public void SpawnObstacle()
    {
        //Check for is it creating time
        if (Time.time < lastObstacleCreateTime + obstacleCreateWaitTime)
        {
            return;
        }

        //Create obstacle
        //We use our retio from difficulty data to see if we pass the chance of craeting the obstacle
        float chance = Random.Range(0f, 100f);

        if (chance < LevelManager.Instance.DifficulityData.ObstacleSpawnRetrio)
        {
            lastObstacleCreateTime = Time.time; //Last obstacle creted time is now our passed game time
            EventManager.OnObstacleCreated.Invoke(); //Wen invoke this if wont create obstacle
            return; //We havent pass so we wait for the next time
        }

        //First make list of lane objects
        List<LaneObject> laneObjects = new List<LaneObject>(TrackManager.Instance.Lanes);
        laneObjects.Shuffle();
        //Now er remove lane object from list ake sure our player has one lane without obstacle
        laneObjects.RemoveAt(Random.Range(0, laneObjects.Count));

        float chanceForAnotherObstacle = Random.Range(0f, 1f);

        lastObstacleCreateTime = Time.time; //Last obstacle creted time is now our passed game time

        for (int i = 0; i < laneObjects.Count; i++)
        {
            if (chanceForAnotherObstacle > 0.5f)
            {
                CreateObstacle(laneObjects[i].transform.position);
                chanceForAnotherObstacle = 0f;
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
