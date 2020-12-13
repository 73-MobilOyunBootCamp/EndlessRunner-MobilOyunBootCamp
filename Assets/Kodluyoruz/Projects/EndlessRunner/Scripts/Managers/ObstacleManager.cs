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
        
    }


    public void CreateObstacle()
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
            EventManager.OnObstacleCreated.Invoke();
        }
    }

}
