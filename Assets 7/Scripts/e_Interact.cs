using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_Interact : MonoBehaviour {
	private e_DisplayImage currentDisplay;

    void Start()
    {
		currentDisplay = GameObject.Find("displayImage").GetComponent<e_DisplayImage>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero, 100);

            if (hit && hit.transform.tag == "Interactable")
            {
				hit.transform.GetComponent<e_IInteractable>().Interact(currentDisplay);
            }
        }

    }


}
