using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_window : MonoBehaviour, t_IInteractable
{
    public GameObject other;
    public GameObject rope;

    public enum WindowId { window, curtain }
    public enum Property { open, close }
    public WindowId windowId;
    public Property property;

    void Start()
    {
        if (windowId == WindowId.curtain && property == Property.close ||
            windowId == WindowId.window && property == Property.close)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

    public void Interact(t_DisplayImage currentDisplay)
    {
        if (rope.activeSelf)
        {
            other.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
