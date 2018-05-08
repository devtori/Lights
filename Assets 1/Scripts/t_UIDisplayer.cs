using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_UIDisplayer : MonoBehaviour, t_IInteractable
{

    public GameObject DisplayObject;

    public void Interact(t_DisplayImage currentDisplay)
    {
        DisplayObject.SetActive(true);
    }
}
