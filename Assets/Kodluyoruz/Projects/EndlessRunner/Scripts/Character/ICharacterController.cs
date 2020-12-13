using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// bunlar bütün karakter kontrollerlerin ortak özellikleri alttakiler.
public interface ICharacterController
{
    void Move(Vector3 direction);
    void Jump();
    void Slide();
}
