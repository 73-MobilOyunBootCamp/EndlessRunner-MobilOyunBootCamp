using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class Obstacle : MonoBehaviour
{

    Animation animation;
    Animation Animation { get { return (animation == null) ? animation = GetComponentInChildren<Animation>() : animation; } }

    [ValueDropdown("audioKeyList")]
    public string HitSoundID;


    private List<string> audioKeyList { get { return AudioKeys.AudioKeyList; } }

    private void OnTriggerEnter(Collider collision)
    {
        
    }
}
