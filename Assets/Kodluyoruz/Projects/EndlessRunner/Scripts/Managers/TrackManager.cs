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
    private List<TrackObject> tracks;
    //This is a property. Property allows us to perform logic while getting or setting and also we can define privite protedted or publuc to getters and setters.
    public List<TrackObject> Tracks
    {
        get
        {
            if (tracks == null)
            {
                tracks = new List<TrackObject>();
            }

            return tracks;
        }
        private set
        {
            tracks = value;
        }
    }

    private List<LaneObject> lanes;
    public List<LaneObject> Lanes { get { return (lanes == null) ? lanes = new List<LaneObject>() : lanes; } set { lanes = value; } }
    public LaneObject MiddleLane
    {
        get
        {
            for (int i = 0; i < Lanes.Count; i++)
            {
                if (Lanes[i].ConnectedLanes.Count > 1)
                    return Lanes[i];
            }

            return null;
        }
    }

    private float startDelay = 3.8f;
    private float startTime;
    [SerializeField]
    private bool canMoveTracks;

    private void OnEnable()
    {
        EventManager.OnGameStart.AddListener(Initilize);
        EventManager.OnPlayerStartedRunning.AddListener(() => canMoveTracks = true);
        EventManager.OnLevelFail.AddListener(() => canMoveTracks = false);
    }

    private void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(Initilize);
        EventManager.OnPlayerStartedRunning.RemoveListener(() => canMoveTracks = true);
        EventManager.OnLevelFail.RemoveListener(() => canMoveTracks = false);
    }

    public void Initilize()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateTrack();
            Debug.Log("Track Created");
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

    #region Tracks

    public void AddTrack(TrackObject trackObject)
    {
        if (!Tracks.Contains(trackObject))
            Tracks.Add(trackObject);
    }

    public void RemoveTrack(TrackObject trackObject)
    {
        if (Tracks.Contains(trackObject))
            Tracks.Remove(trackObject);
    }


    /// <summary>
    /// This method is resposible for moving track objects.
    /// We use a for loop to itterate trough all the track objects that we have.
    /// </summary>
    private void MoveTrackObjects()
    {
        for (int i = 0; i < Tracks.Count; i++)
        {
            Tracks[i].transform.position += Vector3.back * LevelManager.Instance.DifficulityData.TrackSpeed * Time.deltaTime;
        }
    }

    private void ManageTracks()
    {
        for (int i = 0; i < Tracks.Count; i++)
        {
            if(Tracks[i].transform.position.z < -30)
            {
                DisposeTrack(Tracks[i]);
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

        if(Tracks != null)
        {
            if (Tracks.Count > 0)
            {
                createPos = Tracks[Tracks.Count - 1].EndPoint.position + Vector3.forward * 4f;
            }
        }

        GameObject trackObj = Instantiate(LevelManager.Instance.CurrentLevel.GetRandomTrack(LevelManager.Instance.CurrentTheme), createPos, Quaternion.identity);
    }

    /// <summary>
    /// This method is for removing track objects that are no longer needed.
    /// </summary>
    /// <param name="trackObject"></param>
    public void DisposeTrack(TrackObject trackObject)
    {
        Tracks.Remove(trackObject);
        Destroy(trackObject.gameObject);
    }


    public TrackObject GetLastTrackObject()
    {
        return Tracks[Tracks.Count - 1];
    }

    #endregion

    #region Lanes
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

    public LaneObject GetClosestLane(Vector3 position)
    {
        float minDistance = Mathf.Infinity;
        LaneObject closestLane = null;
        float distance = 0;

        for (int i = 0; i < Lanes.Count; i++)
        {
            distance = Vector3.Distance(Lanes[i].transform.position, position);

            if(distance < minDistance)
            {
                minDistance = distance;
                closestLane = Lanes[i];
            }
        }

        return closestLane;
    }

    public LaneObject GetRandomLane()
    {
        return Lanes[UnityEngine.Random.Range(0, Lanes.Count)];
    }
    #endregion
}
