using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DifficulityMode { Easy, Medium, Hard }
[CreateAssetMenu(fileName = "Difficulity Data", menuName = "Endless Runner/Difficulity Data")]
public class DifficulityData : ScriptableObject
{   
    public DifficulityMode DifficulityMode = DifficulityMode.Easy;
    public float TrackSpeed;

    [Tooltip("Use this as a spawn percentage to determan the chance of this object being created when level creates a level object.")]
    [Range(1, 100)]
    public float ObstacleSpawnRetrio = 1f;

    [Tooltip("Use this as a spawn percentage to determan the chance of this object being created when level creates a level object.")]
    [Range(1, 100)]
    public float PowerUpSpawnRetrio = 1f;

    [Tooltip("Determans at which point should this difficulity be activated.")]
    public float ActivateTimeTrashold;

}
