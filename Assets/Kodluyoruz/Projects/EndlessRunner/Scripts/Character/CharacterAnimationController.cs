using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    Character character;
    Character Character { get { return (character == null) ? character = GetComponentInParent<Character>() : character; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.AddListener(() => InvokeTrigger("Start"));

        Character.OnCharacterJump.AddListener(() => InvokeTrigger("Jump"));
        Character.OnCharacterSlide.AddListener(() => InvokeTrigger("Slide"));
        Character.OnCharacterHit.AddListener(() => InvokeTrigger("Hit"));

    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.RemoveListener(() => InvokeTrigger("Start"));

        Character.OnCharacterJump.RemoveListener(() => InvokeTrigger("Jump"));
        Character.OnCharacterSlide.RemoveListener(() => InvokeTrigger("Slide"));
        Character.OnCharacterHit.RemoveListener(() => InvokeTrigger("Hit"));


    }

    private void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        Animator.SetBool("Moving", LevelManager.Instance.IsLevelStarted);
        Animator.SetBool("IsDead", Character.IsDead);
    }

    private void InvokeTrigger(string value)
    {
        Animator.SetTrigger(value);
    }

    public void OnSlideFinish()
    {
        
    }

    public void OnJumpFinish()
    {
        
    }

    public void OnRunStart()
    {
        Debug.Log("Run Start");
        Character.IsControlable = true;
        EventManager.OnPlayerStartedRunning.Invoke();
    }
}
