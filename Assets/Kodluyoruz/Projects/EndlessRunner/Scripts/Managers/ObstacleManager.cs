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
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.RemoveListener(() => canCreateObstacles = true);
    }

    private void Update()
    {
        if (!canCreateObstacles)
        {
            lastObstacleCreateTime = Time.time;
            return;
        }
        SpawnObstacles();
    }


<<<<<<< Updated upstream
    public void SpawnObstacles()
    {
        if (Time.time < lastObstacleCreateTime + obstacleCreateWaitTime)
            return;

        //Create obstacle
        //We use our retio from difficulity data to see if we pass the chance of creating the obstacle
        float chance = Random.Range(0f, 100f);

        if(chance < LevelManager.Instance.DifficulityData.ObstacleSpawnRetrio)
        {
            lastObstacleCreateTime = Time.time; //We set the last obstacle create time to Time.time to wait for next interval.
            EventManager.OnObstacleCreated.Invoke(); //We invoke this event even if we don't create any obstacles. Because we want the come continue on it's loop.
            return; // We havent pass so we wait for the next time.
        }


        //First we make a new list of lane objects
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
                CreateObstacle(laneObjects[i].transform.position);
                chanceForAnotherObstacle = 0f;
                continue; //This statment will allow us the pass the code below in the for loop.
                          //We don't want to create two obstacles on the same lane however we also don't know if we passed the
                          //if statement.
            }

            CreateObstacle(laneObjects[i].transform.position);
            break; //This statment will allow us the quit from for loop. 
=======
    public void SpawnObstacle()
    {
        if (Time.time < lastObstacleCreateTime + obstacleCreateWaitTime)
        {
            return;
        }

        //Create obstacle
        //We use our retio from difficulity data to see if we pass the cahange of creating the obstacle

        float change = Random.Range(0f, 100f); //f eklemezsen int döner

        if (change < LevelManager.Instance.DifficulityData.ObstacleSpawnRetrio)
        {
            lastObstacleCreateTime = Time.time; //We set the last obstacle create .......
            EventManager.OnObstacleCreated.Invoke();
            return;
        }

        //First we make sure new list of lane objects
        List<LaneObject> laneObjects = new List<LaneObject>(TrackManager.Instance.Lanes);
        //then we suffle the list to make a different variation
        laneObjects.Shuffle(); //Extension metodu listelere özgü
        laneObjects.RemoveAt(Random.Range(0, laneObjects.Count));//En fazla 2 engel olabileceğinden emin oluyoruz, bir yol hep boş olmalı
        float changeForAnotherObstacle = Random.Range(0f, 1f);
        lastObstacleCreateTime = Time.time;

        for (int i = 0; i < laneObjects.Count; i++)
        {
            if (changeForAnotherObstacle > 0.5f)
            {
                CreateObstacle(laneObjects[i].transform.position);
                changeForAnotherObstacle = 0f;
                continue;
            }

            CreateObstacle(laneObjects[i].transform.position);
            break;
>>>>>>> Stashed changes
        }

        EventManager.OnObstacleCreated.Invoke();
    }

<<<<<<< Updated upstream
    private GameObject CreateObstacle(Vector3 position)
=======
    private GameObject CreateObstacle(Vector3 position) 
>>>>>>> Stashed changes
    {
        return Instantiate(LevelManager.Instance.CurrentLevel.GetRandomLevelObject(LevelObjectType.Obstacle),
            position,
            Quaternion.identity,
<<<<<<< Updated upstream
            TrackManager.Instance.Tracks[TrackManager.Instance.Tracks.Count - 1].transform);

=======
            TrackManager.Instance.Tracks[TrackManager.Instance.Tracks.Count -1].transform);//Trackle beraber hareket edecek childı olduğu için
>>>>>>> Stashed changes
    }

}
