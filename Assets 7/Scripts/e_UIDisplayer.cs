using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_UIDisplayer : MonoBehaviour, e_IInteractable {
    public GameObject DisplayObject;

	public void Interact(e_DisplayImage currentDisplay)
    {
        DisplayObject.SetActive(true);
    }
}
