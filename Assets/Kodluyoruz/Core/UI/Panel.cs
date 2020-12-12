using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[RequireComponent(typeof(CanvasGroup))]
public class Panel : MonoBehaviour
{
    //Don't use this in your code this is just a referance to cache it.
    CanvasGroup canvasGroup;
    //Use this to access the canvas group.
    public CanvasGroup CanvasGroup
    {
        get
        {
            //Check if canvas group is null
            if(canvasGroup == null)
            {
                //Get if canvas group added to the game object.
                canvasGroup = GetComponent<CanvasGroup>();

                //Check if we successfully get the canvas group
                if (canvasGroup == null)
                    //Means that we don't have canvas group at the gameobject, so add it.
                    canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }

            return canvasGroup;
        }
    }

    [Button]
    public virtual void ShowPanel()
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
    }

    [Button]
    public virtual void HidePanel()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
    }

}
