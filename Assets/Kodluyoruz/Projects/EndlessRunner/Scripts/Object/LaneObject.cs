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
        
    }

    private void OnDisable()
    {
        
    }

    public LaneObject GetLane(Swipe swipe)
    {
        for (int i = 0; i < ConnectedLanes.Count; i++)
        {
            if (ConnectedLanes[i].SwipeDirection.Equals(swipe))
                return ConnectedLanes[i].LaneObject;
        }
        return null;
    }


}
