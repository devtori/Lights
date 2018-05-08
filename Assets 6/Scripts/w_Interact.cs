using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w_Interact : MonoBehaviour
{

    private w_DisplayImage currentDisplay;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<w_DisplayImage>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPostion, Vector2.zero, 100);

            if (hit && hit.transform.tag == "Interactable" && currentDisplay.CurrentState != w_DisplayImage.State.idle)
            {
                hit.transform.GetComponent<w_IInteractable>().Interact(currentDisplay);
            }
        }

    }
}
