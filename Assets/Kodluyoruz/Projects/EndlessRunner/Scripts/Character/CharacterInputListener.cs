using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterInputListener : MonoBehaviour
{
    private ICharacterController characterController;
    public ICharacterController CharacterController { get { return (characterController == null) ? characterController = GetComponent<ICharacterController>() : characterController; } }

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
}
