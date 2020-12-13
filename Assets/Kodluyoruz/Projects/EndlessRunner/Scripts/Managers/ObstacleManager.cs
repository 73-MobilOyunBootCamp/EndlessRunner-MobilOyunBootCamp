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
        if (Time.time < lastObstacleCreateTime + obstacleCreateWaitTime)
            return;

        float chance = Random.Range(0f,100f);

        if (chance < LevelManager.Instance.DifficulityData.ObstacleSpawnRetrio)
        {
            lastObstacleCreateTime = Time.time;
            EventManager.OnObstacleCreated.Invoke();
            return;

        }
    }

}
