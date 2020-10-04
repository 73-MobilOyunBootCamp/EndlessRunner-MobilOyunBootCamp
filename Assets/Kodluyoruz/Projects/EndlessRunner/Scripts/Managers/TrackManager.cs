using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : Singleton<TrackManager>
{
    private List<TrackObject> createdTracks;
    public List<TrackObject> CreatedTracks
    {
        get
        {
            if(createdTracks == null)
            {
                createdTracks = new List<TrackObject>();
                for (int i = 0; i < 2; i++)
                {
                    CreateTrack();
                }
            }

            return createdTracks;
        }
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

    public void Initilize()
    {
        CreateTrack();
    }

    public void CreateTrack()
    {
        GameObject roadObj = Instantiate(LevelManager.Instance.LevelData.GetRandomTrack(LevelManager.Instance.CurrentTheme), CreatedTracks[CreatedTracks.Count].EndPoint.position, Quaternion.identity);
    }


}
