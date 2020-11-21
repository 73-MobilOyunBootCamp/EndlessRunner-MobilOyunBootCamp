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

        EventManager.OnLevelStart.AddListener(() => Animator.SetTrigger("Start"));
        EventManager.OnLevelFinish.AddListener(() => Animator.Rebind());
        Character.OnCharacterRevive.AddListener(() => Animator.SetTrigger("Start"));
        Character.OnCharacterJump.AddListener(()=> InvokeTrigger("Jump"));
        Character.OnCharacterSlide.AddListener(()=> InvokeTrigger("Slide"));
        Character.OnCharacterHit.AddListener(()=> InvokeTrigger("Hit"));
        Character.OnCharacterDie.AddListener(() => InvokeTrigger("Die"));
        Character.OnCharacterDie.AddListener(() => Animator.SetBool("Dead", Character.IsDead));
        Character.OnCharacterRevive.AddListener(() => Animator.SetBool("Dead", Character.IsDead));


    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.RemoveListener(() => Animator.SetTrigger("Start"));
        EventManager.OnLevelFinish.RemoveListener(() => Animator.Rebind());
        Character.OnCharacterRevive.RemoveListener(() => Animator.SetTrigger("Start"));
        Character.OnCharacterJump.RemoveListener(() => InvokeTrigger("Jump"));
        Character.OnCharacterSlide.RemoveListener(() => InvokeTrigger("Slide"));
        Character.OnCharacterHit.RemoveListener(() => InvokeTrigger("Hit"));
        Character.OnCharacterDie.RemoveListener(() => InvokeTrigger("Die"));
        Character.OnCharacterDie.RemoveListener(() => Animator.SetBool("Dead", Character.IsDead));
        Character.OnCharacterRevive.RemoveListener(() => Animator.SetBool("Dead", Character.IsDead));
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
        Character.Collider.enabled = true;
    }

    public void OnJumpFinish()
    {
        Character.Collider.enabled = true;
    }

    public void OnRunStart()
    {
        Debug.Log("RunStart");
        Character.IsControlable = true;
        EventManager.OnPlayerStartedRunning.Invoke();
    }
}
