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
        if (Managers.Instance == null)
            return;

        TrackManager.Instance.AddTrack(this);
        EventManager.OnLevelFinish.AddListener(() => Destroy(gameObject));
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        TrackManager.Instance.RemoveTrack(this);
        EventManager.OnLevelFinish.RemoveListener(() => Destroy(gameObject));
    }
}
