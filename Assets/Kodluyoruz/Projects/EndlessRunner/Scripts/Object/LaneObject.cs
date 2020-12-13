using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LaneHolder
{
    public LaneObject LaneObject;
    public Swipe SwipeDirection;
}


public class LaneObject : MonoBehaviour
{

    public List<LaneHolder> ConnectedLanes = new List<LaneHolder>();

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        TrackManager.Instance.AddLane(this);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        TrackManager.Instance.RemoveLane(this);
    }
   

    public LaneObject GetLane(Swipe swipe)
    {
        return null;
    }


}
