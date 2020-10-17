using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CharacterController : MonoBehaviour, ICharacterController
{

    public LaneObject CurrentLane { get { return TrackManager.Instance.GetClosestLane(transform.position); } }

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

    /// <summary>
    /// This method comes with interface. We don't really need it in Endless Runner game.
    /// but we will use it in character controller example.
    /// </summary>
    /// <param name="direction"></param>
    public void Move(Vector3 direction)
    {

    }

    public void Move(Swipe swipe, Vector3 direction)
    {
        if (!CurrentLane.HasDirection(swipe))
            return;

        //Get which lane should this character move
    }

    public void Jump()
    {
        Debug.Log("Jump");
    }

    public void Slide()
    {
        Debug.Log("Slide");
    }
}
