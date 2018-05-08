using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w_remote : MonoBehaviour {

    private GameObject displayImage;

    void Start()
    {
        displayImage = GameObject.Find("displayImage");

        this.gameObject.SetActive(false);
    }

    void Update()
    {
        HideDisplay();
    }

    void HideDisplay()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
        }

        if (displayImage.GetComponent<w_DisplayImage>().CurrentState == w_DisplayImage.State.normal)
        {
            this.gameObject.SetActive(false);
        }

    }
}
