using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public interface IPowerUp : Icollectable
{
    void Execute();
    IEnumerator ExecuteCo();
    void Initialize(PowerUpBase powerUpBase);
    void Interup();
}
