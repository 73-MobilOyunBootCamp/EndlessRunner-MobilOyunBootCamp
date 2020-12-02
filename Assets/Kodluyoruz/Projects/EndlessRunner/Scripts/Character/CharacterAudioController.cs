using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class CharacterAudioController : MonoBehaviour
{
    Character character;
    Character Character { get { return (character == null) ? character = GetComponent<Character>() : character; } }

    [ValueDropdown("audioKeyList")]
    public string JumpSound;

    [ValueDropdown("audioKeyList")]
    public string HitSound;

    [ValueDropdown("audioKeyList")]
    public string DeathSound;

    [ValueDropdown("audioKeyList")]
    public string SlideSound;

    [ValueDropdown("audioKeyList")]
    public string SwitchLane;

    private List<string> audioKeyList { get { return AudioKeys.AudioKeyList; } }

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
