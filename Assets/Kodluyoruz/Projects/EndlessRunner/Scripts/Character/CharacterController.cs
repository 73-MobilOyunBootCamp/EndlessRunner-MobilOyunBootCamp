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

        EventManager.OnSwipeDetected.AddListener(Move);
       
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnSwipeDetected.RemoveListener(Move);

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
        Debug.Log("Move with Swipe!");

        if (!Character.IsControlable)
            return;

        LaneObject laneObject = CurrentLane.GetLane(swipe);

        switch (swipe)
        {
            case Swipe.Up:
                Jump();
                break;
            case Swipe.Down:
                Slide();
                break;
            case Swipe.Left:

                if (laneObject == null)
                    return;
                
                JumpToLane(laneObject);

                break;
            case Swipe.Right:
                
                if (laneObject == null)
                    return;

                JumpToLane(laneObject);

                break;
            default:
                break;
        }

    }

    public void Jump()
    {
        
    }

    public void Slide()
    {
       
    }

    private void JumpToLane(LaneObject laneObject)
    {
        Debug.Log("JumpToLane method!");
        transform.DOJump(new Vector3(laneObject.transform.position.x, transform.position.y, transform.position.z), 1f, 1, 0.3f);
        Character.OnCharacterSwitchLane.Invoke();
    }
}
