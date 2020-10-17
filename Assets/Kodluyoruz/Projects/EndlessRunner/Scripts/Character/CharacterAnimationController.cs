using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.AddListener(() => Animator.SetTrigger("Start"));
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.RemoveListener(() => Animator.SetTrigger("Start"));
    }

    private void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        Animator.SetBool("Moving", LevelManager.Instance.IsLevelStarted);
    }
}
