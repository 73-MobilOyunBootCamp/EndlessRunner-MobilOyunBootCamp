using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrackObject : MonoBehaviour
{
    public Theme Theme;
    public Transform StartPoint;
    public Transform EndPoint;


    private void OnEnable()
    {
        TrackManager.Instance.AddTrack(this);
    }

    private void OnDisable()
    {
        TrackManager.Instance.RemoveTrack(this);
    }
}
