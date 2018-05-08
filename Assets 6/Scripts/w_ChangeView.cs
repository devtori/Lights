﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w_ChangeView : MonoBehaviour, w_IInteractable
{

    public string SpriteName;

    private float initialCameraSize;
    private Vector3 initialCameraPosition;

    void Start()
    {
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;
    }

    public void Interact(w_DisplayImage currentDisplay)
    {
        currentDisplay.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>("Sprites/" + SpriteName);
        currentDisplay.CurrentState = w_DisplayImage.State.ChangedView;

        Camera.main.orthographicSize = initialCameraSize;
        Camera.main.transform.position = initialCameraPosition;
    }
}
