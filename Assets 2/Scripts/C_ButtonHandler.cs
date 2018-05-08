using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ButtonHandler : MonoBehaviour {

    private C_DisplayImage currentDisplay;

    private float initialCameraSize;
    private Vector3 initialCameraPosition;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<C_DisplayImage>();
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;
    }

    public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;

    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
    }

    public void OnClickReturn()
    {
        if (currentDisplay.CurrentState == C_DisplayImage.State.zoom)
        {
            GameObject.Find("displayImage").GetComponent<C_DisplayImage>().CurrentState = C_DisplayImage.State.normal;
            var zoomInObjects = FindObjectsOfType<C_ZoomInObject>();
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
                = Resources.Load<Sprite>("Sprites/c_wall" + currentDisplay.CurrentWall);
            currentDisplay.CurrentState = C_DisplayImage.State.normal;
        }
    }


}
