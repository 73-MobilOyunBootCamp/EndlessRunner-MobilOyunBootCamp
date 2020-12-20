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
        IDamagable ıDamagable = collision.GetComponent<IDamagable>();
        if (ıDamagable != null)
        {
            ıDamagable.Damage();
            if (!string.IsNullOrEmpty(HitSoundID))
            {
                AudioManager.Instance.PlayOneShot2D(HitSoundID);
            }
            if (Animation!=null)
            {
                Animation.Play();
            }
        }
    }
}
