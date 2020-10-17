using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IComponent
{
    //To Check if any interface is null or destroyed you must inherit an interface from this
    //and call Utilities.IsNullOrDestroyed

    GameObject gameObject { get; }
    Transform transform { get; }
    Component component { get; }
    bool isDestroyed { get; }
}
