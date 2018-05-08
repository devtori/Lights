using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_ZoominObject : MonoBehaviour, e_IInteractable
{
    public float ZoomRatio = .5f;
	public float additionalYmove = 0;

	public void Interact(e_DisplayImage currentDisplay)
    {
		if (currentDisplay.CurrentState == e_DisplayImage.State.zoom)
        {
        }
        else
        {
            Camera.main.orthographicSize *= ZoomRatio;
			Camera.main.transform.position = new Vector3(this.transform.position.x, (this.transform.position.y-ZoomRatio)+additionalYmove,
                Camera.main.transform.position.z);
            gameObject.layer = 2;
			currentDisplay.CurrentState = e_DisplayImage.State.zoom;

            ConstrainCamera();
        }        
    }

    void ConstrainCamera()
    {
        var height = Camera.main.orthographicSize;
        var width = height * Camera.main.aspect;

        var cameraBounds = GameObject.Find("cameraBounds");

        if (Camera.main.transform.position.x + width > cameraBounds.transform.position.x + cameraBounds.GetComponent<BoxCollider2D>().size.x / 2)
        {
            Camera.main.transform.position += new Vector3((cameraBounds.transform.position.x + cameraBounds.GetComponent<BoxCollider2D>().size.x/2) -
                (Camera.main.transform.position.x + width), 0, 0);
        }
    }

    
}
