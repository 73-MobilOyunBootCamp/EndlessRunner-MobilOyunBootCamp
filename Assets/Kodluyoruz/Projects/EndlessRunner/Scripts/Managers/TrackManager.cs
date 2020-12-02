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
            if(tracks == null)
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
    private bool canMoveTracks;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
       
    }


    public void AddTrack(TrackObject trackObject)
    {
       
    }

    public void RemoveTrack(TrackObject trackObject)
    {
        
    }

    public void AddLane(LaneObject laneObject)
    {
        
    }

    public void RemoveLane(LaneObject laneObject)
    {
        
    }

    public void Initilize()
    {
        
    }

    /// <summary>
    /// Update is a Monobehavior method that is provided to by unity.
    /// Is called every frame and we can perform tasks that accur frequently here.
    /// </summary>
    private void Update()
    {
        
    }

    #region Tracks
    /// <summary>
    /// This method is resposible for moving track objects.
    /// We use a for loop to itterate trough all the track objects that we have.
    /// </summary>
    private void MoveTrackObjects()
    {
        
    }

    private void ManageTracks()
    {
        
    }


    /// <summary>
    /// This Method will be responsible for creating tracks.
    /// </summary>
    public void CreateTrack()
    {
        
    }

    /// <summary>
    /// This method is for removing track objects that are no longer needed.
    /// </summary>
    /// <param name="trackObject"></param>
    public void DisposeTrack(TrackObject trackObject)
    {
       
    }
    #endregion
    #region Lanes

    public LaneObject GetClosestLane(Vector3 position)
    {
        return null;
    }

    #endregion
}
