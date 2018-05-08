using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class w_ButtonHandler : MonoBehaviour {

    private w_DisplayImage currentDisplay;

    private float initialCameraSize;
    private Vector3 initialCameraPosition;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<w_DisplayImage>();
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;
    }

    public void OnRightClickArrow()
    {
        currentDisplay.CurrentRoom = currentDisplay.CurrentRoom + 1;
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentRoom = currentDisplay.CurrentRoom - 1;
    }

    public void OnClickReturn()
    {
        if (currentDisplay.CurrentState == w_DisplayImage.State.zoom)
        {
            GameObject.Find("displayImage").GetComponent<w_DisplayImage>().CurrentState = w_DisplayImage.State.normal;
            var zoomInObjects = FindObjectsOfType<w_ZoomInObject>();
            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }

            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }
        else
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/room" + currentDisplay.CurrentRoom);
            currentDisplay.CurrentState = w_DisplayImage.State.normal;
        }
    }
}
