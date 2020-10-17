using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaneObject : MonoBehaviour
{

    public List<Swipe> AvialibleDirections = new List<Swipe>();

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

    public bool HasDirection(Swipe swipe)
    {
        for (int i = 0; i < AvialibleDirections.Count; i++)
        {
            if (AvialibleDirections[i].Equals(swipe))
                return true;
        }

        return false;
    }


}
