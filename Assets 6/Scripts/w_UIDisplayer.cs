using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w_UIDisplayer : MonoBehaviour, w_IInteractable
{

    public GameObject DisplayObject;

    public void Interact(w_DisplayImage currentDisplay)
    {
        if (DisplayObject)
        {
            DisplayObject.SetActive(true);
        }
    }
}
