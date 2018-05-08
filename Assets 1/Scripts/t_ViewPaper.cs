using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_ViewPaper : MonoBehaviour
{
    void Start()
    {
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
        
    }
}
