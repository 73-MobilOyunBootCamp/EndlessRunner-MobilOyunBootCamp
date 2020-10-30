using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleManager : Singleton<ObstacleManager>
{

    private float lastObstacleCreateTime;
    private float obstacleCreateWaitTime;

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



    public void CreateObstacle()
    {
        if (Time.time + obstacleCreateWaitTime < lastObstacleCreateTime)
            return;

        //Crete obstacle
        //We use our retio from difficulity data to see if we pass the chance of creating the obstacle
        float chance = Random.Range(0, 100);
        if (chance < LevelManager.Instance.DifficulityData.ObstacleSpawnRetrio)
        {
            lastObstacleCreateTime = Time.time; //We set the last obstacle create time to Time.time to wait for next interval.
            return; // We havent pass so we wait for the next time.
        }

        //First we make a new list of line objects
        List<LaneObject> laneObjects = new List<LaneObject>(TrackManager.Instance.Lanes);
        //then we suffle the list to make a different variation
        laneObjects.Shuffle();
        //Now we remove one lane object from the list to make sure our player has one lane without an obstacle.
        laneObjects.RemoveAt(Random.Range(0, laneObjects.Count));

        //We loop the list that contains two random lanes (different order each time because we suffle it.)
        float chanceForAnotherObstacle = 1; //This is our chance for second obstacle if we pass this float we will create a second obstacle.
                                            //If not we will only create one obstacle 100 percent

        for (int i = 0; i < laneObjects.Count; i++)
        {
            if(chanceForAnotherObstacle > 0.5f)
            {
                //Instantiate(LevelManager.Instance.CurrentThemeData.LevelObjectDatas)
            }
        }

    }

}
