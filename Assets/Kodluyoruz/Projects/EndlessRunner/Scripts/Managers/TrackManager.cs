using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : Singleton<TrackManager>
{
    /// <summary>
    /// Here is an example of capsulation. We use a variable and a property to capsulate Tracks that we create.
    /// This way we get or set properties in an optimal way.
    /// </summary>
    private List<TrackObject> createdTracks;
    //This is a property. Property allows us to perform logic while getting or setting and also we can define privite protedted or publuc to getters and setters.
    public List<TrackObject> CreatedTracks
    {
        get
        {
            if(createdTracks == null)
            {
                createdTracks = new List<TrackObject>();
            }

            return createdTracks;
        }
        private set
        {
            createdTracks = value;
        }
    }

    private List<LaneObject> lanes;
    public List<LaneObject> Lanes { get { return (lanes == null) ? lanes = new List<LaneObject>() : lanes; } set { lanes = value; } }

    private float startDelay = 3.8f;
    private float startTime;
    private bool canMoveTracks;

    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(() =>
        {
            Initilize();
            startTime = Time.time;
        });

        EventManager.OnPlayerStartedRunning.AddListener(() => canMoveTracks = true);
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(()=>
        {
            Initilize();
            startTime = Time.time;
        });

        EventManager.OnPlayerStartedRunning.RemoveListener(() => canMoveTracks = true);
    }


    public void AddTrack(TrackObject trackObject)
    {
        if (!CreatedTracks.Contains(trackObject))
            CreatedTracks.Add(trackObject);
    }

    public void RemoveTrack(TrackObject trackObject)
    {
        if (CreatedTracks.Contains(trackObject))
            CreatedTracks.Remove(trackObject);
    }

    public void AddLane(LaneObject laneObject)
    {
        if (!Lanes.Contains(laneObject))
            Lanes.Add(laneObject);
    }

    public void RemoveLane(LaneObject laneObject)
    {
        if (Lanes.Contains(laneObject))
            Lanes.Remove(laneObject);
    }

    public void Initilize()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateTrack();
        }
    }

    /// <summary>
    /// Update is a Monobehavior method that is provided to by unity.
    /// Is called every frame and we can perform tasks that accur frequently here.
    /// </summary>
    private void Update()
    {
        if (!canMoveTracks)
            return;

        MoveTrackObjects();
        ManageTracks();
    }

    /// <summary>
    /// This method is resposible for moving track objects.
    /// We use a for loop to itterate trough all the track objects that we have.
    /// </summary>
    private void MoveTrackObjects()
    {
        for (int i = 0; i < CreatedTracks.Count; i++)
        {
            CreatedTracks[i].transform.position += Vector3.back * 10 * Time.deltaTime;
        }
    }

    private void ManageTracks()
    {
        for (int i = 0; i < CreatedTracks.Count; i++)
        {
            if(CreatedTracks[i].transform.position.z < -30f)
            {
                DisposeTrack(CreatedTracks[i]);
                CreateTrack();
            }
        }
    }


    /// <summary>
    /// This Method will be responsible for creating tracks.
    /// </summary>
    public void CreateTrack()
    {
        Vector3 createPos = Vector3.zero;
        if(CreatedTracks != null)
        {
            if (CreatedTracks.Count > 0)
            {
                createPos = CreatedTracks[CreatedTracks.Count - 1].EndPoint.position + Vector3.forward * 4f;
            }
        }
        
        GameObject roadObj = Instantiate(LevelManager.Instance.LevelData.Levels[LevelManager.Instance.LevelIndex].GetRandomTrack(LevelManager.Instance.CurrentTheme), createPos, Quaternion.identity);
    }

    /// <summary>
    /// This method is for removing track objects that are no longer needed.
    /// </summary>
    /// <param name="trackObject"></param>
    public void DisposeTrack(TrackObject trackObject)
    {
        CreatedTracks.Remove(trackObject);
        Destroy(trackObject.gameObject);
    }

    public LaneObject GetClosestLane(Vector3 position)
    {
        float minDistance = Mathf.Infinity;
        LaneObject closestLine = null;
        float distance = 0;
        for (int i = 0; i < Lanes.Count; i++)
        {
            distance = Vector3.Distance(Lanes[i].transform.position, position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestLine = Lanes[i];
            }
        }

        return closestLine;
    }
}
