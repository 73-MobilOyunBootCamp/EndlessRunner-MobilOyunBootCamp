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

        


    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

       
    }

    private void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        Animator.SetBool("Moving", LevelManager.Instance.IsLevelStarted);
        Animator.SetBool("isDead", Character.IsDead);
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
        
    }
}
