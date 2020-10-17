using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICharacterController
{
    void Move(Vector3 direction);
    void Jump();
    void Slide();
}
