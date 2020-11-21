using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CharacterControllerType { Player, AI}

public class Character : MonoBehaviour
{

    public CharacterControllerType CharacterControllerType = CharacterControllerType.Player;

    private Rigidbody rigidbody;
    public Rigidbody Rigidbody { get { return (rigidbody == null) ? rigidbody = GetComponent<Rigidbody>() : rigidbody; } }

    private Collider collider;
    public Collider Collider { get { return (collider == null) ? collider = GetComponent<Collider>() : collider; } }

    #region Events
    [HideInInspector]
    public UnityEvent OnCharacterHit = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterDie = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterRevive = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterJump = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterSlide = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterSwitchLane = new UnityEvent();

    #endregion

    private bool isDead;
    public bool IsDead { get { return (isDead); } set { isDead = value; } }

    private bool isControlable;
    public bool IsControlable { get { return isControlable; } set { isControlable = value; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelContine.AddListener(ReviveCharacter);
        EventManager.OnLevelFinish.AddListener(()=>
        {
            transform.position = new Vector3(TrackManager.Instance.MiddleLane.transform.position.x, transform.position.y, transform.position.z);
            transform.LookAt(TrackManager.Instance.MiddleLane.transform);
        });
        EventManager.OnLevelStart.AddListener(ReviveCharacter);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelContine.RemoveListener(ReviveCharacter);
        EventManager.OnLevelFinish.RemoveListener(ReviveCharacter);
        EventManager.OnLevelFinish.RemoveListener(() =>
        {
            transform.position = new Vector3(TrackManager.Instance.MiddleLane.transform.position.x, transform.position.y, transform.position.z);
            transform.LookAt(TrackManager.Instance.MiddleLane.transform);
        });
        EventManager.OnLevelStart.RemoveListener(ReviveCharacter);

    }


    public void DamageCharacter()
    {
        OnCharacterHit.Invoke();
    }

    public void KillCharacter()
    {
        if (IsDead)
            return;

        IsDead = true;
        IsControlable = false;
        OnCharacterDie.Invoke();
        if(CharacterControllerType == CharacterControllerType.Player)
            EventManager.OnLevelFail.Invoke();
    }

    public void ReviveCharacter()
    {
        if (!IsDead)
            return;

        IsControlable = true;
        IsDead = false;
        OnCharacterRevive.Invoke();
    }


    private void OnTriggerEnter(Collider other)
    {
        Icollectable icollectable = other.GetComponent<Icollectable>();
        if (icollectable != null)
            icollectable.Collect();
    }

}
