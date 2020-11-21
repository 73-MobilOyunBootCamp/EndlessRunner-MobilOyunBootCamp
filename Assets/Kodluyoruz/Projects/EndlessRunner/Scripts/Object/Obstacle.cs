﻿using System.Collections;
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
        Character character = collision.GetComponent<Character>();

        if(character)
        {
            if(character.CharacterControllerType == CharacterControllerType.Player)
            {
                character.DamageCharacter();
                if (!string.IsNullOrEmpty(HitSoundID))
                    AudioManager.Instance.PlayOneShot2D(HitSoundID);
                if (Animation != null)
                    Animation.Play();
            }
        }
    }
}
