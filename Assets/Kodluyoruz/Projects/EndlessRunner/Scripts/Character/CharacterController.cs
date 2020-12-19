using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CharacterController : MonoBehaviour, ICharacterController
{

    public LaneObject CurrentLane { get { return TrackManager.Instance.GetClosestLane(transform.position); } }
    Character character;
    Character Character { get { return (character == null) ? character = GetComponent<Character>() : character; } }

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

    public void Move(Swipe swipe, Vector2 direction)
    {
        
        

    }

    public void Jump()
    {
        
    }

    public void Slide()
    {
       
    }
}
