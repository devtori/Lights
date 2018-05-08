using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_UIDisplayer : MonoBehaviour, b_IInteractable {
    public GameObject DisplayObject;

	public void b_Interact(b_DisplayImage currentDisplay)
    {
        DisplayObject.SetActive(true);
    }
}
