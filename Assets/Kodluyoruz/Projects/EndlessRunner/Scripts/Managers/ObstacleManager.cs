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

        EventManager.OnLevelStart.AddListener(() => canCreateObstacles = true);
        EventManager.OnLevelContine.AddListener(() => canCreateObstacles = true);
        EventManager.OnLevelFail.AddListener(() => canCreateObstacles = false);
        EventManager.OnLevelSuccess.AddListener(() => canCreateObstacles = false);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.RemoveListener(() => canCreateObstacles = true);
        EventManager.OnLevelContine.RemoveListener(() => canCreateObstacles = true);
        EventManager.OnLevelFail.RemoveListener(() => canCreateObstacles = false);
        EventManager.OnLevelSuccess.RemoveListener(() => canCreateObstacles = false);
    }

    private void Update()
    {
        if (!canCreateObstacles)
        {
            lastObstacleCreateTime = Time.time; //We set the last obstacle create time to Time.time.
                                                //Because we don't want to create a new obstacle as soon as this bool turns true
            return;
        }

        CreateObstacle();
    }


    public void CreateObstacle()
    {
        if (Time.time < lastObstacleCreateTime + obstacleCreateWaitTime)
            return;

        //Crete obstacle
        //We use our retio from difficulity data to see if we pass the chance of creating the obstacle
        float chance = Random.Range(0, 100);
        if (chance < LevelManager.Instance.DifficulityData.ObstacleSpawnRetrio)
        {
            lastObstacleCreateTime = Time.time; //We set the last obstacle create time to Time.time to wait for next interval.
            EventManager.OnObstacleCreated.Invoke(); //We invoke this event even if we don't create any obstacles. Because we want the come continue on it's loop.
            return; // We havent pass so we wait for the next time.
        }

        //First we make a new list of line objects
        List<LaneObject> laneObjects = new List<LaneObject>(TrackManager.Instance.Lanes);
        //then we suffle the list to make a different variation
        laneObjects.Shuffle();
        //Now we remove one lane object from the list to make sure our player has one lane without an obstacle.
        laneObjects.RemoveAt(Random.Range(0, laneObjects.Count));

        //We loop the list that contains two random lanes (different order each time because we suffle it.)
        float chanceForAnotherObstacle = Random.Range(0f, 1f);//This is our chance for second obstacle if we pass this float we will create a second obstacle.
                                                              //If not we will only create one obstacle 100 percent

        lastObstacleCreateTime = Time.time; //We set the last obstacle create time to Time.time to wait for next interval.

        for (int i = 0; i < laneObjects.Count; i++)
        {
            if(chanceForAnotherObstacle > 0.5f)
            {
                Instantiate(LevelManager.Instance.CurrentLevel.GetRandomLevelObject(LevelObjectType.Obstacle)
                    , laneObjects[i].transform.position,
                    Quaternion.identity,
                    TrackManager.Instance.Tracks[TrackManager.Instance.Tracks.Count - 1].transform);

                chanceForAnotherObstacle = 0f;
                continue; //This statment will allow us the pass the code below in the for loop.
                            //We don't want to create two obstacles on the same lane however we also don't know if we passed the
                            //if statement.
            }

            Instantiate(LevelManager.Instance.CurrentLevel.GetRandomLevelObject(LevelObjectType.Obstacle)
                   , laneObjects[i].transform.position,
                   Quaternion.identity,
                   TrackManager.Instance.Tracks[TrackManager.Instance.Tracks.Count - 1].transform);
            break; //This statment will allow us the quit from for loop. 
        }
        EventManager.OnObstacleCreated.Invoke();

    }

}
