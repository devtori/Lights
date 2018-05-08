using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_lantern : MonoBehaviour, t_IInteractable
{
    public GameObject LanternOff;
    public bool isLanternOn;

    void Start()
    {
        isLanternOn = false;
        LanternOff.SetActive(false);
    }

    public void Interact(t_DisplayImage currentDisplay)
    {
        isLanternOn = !isLanternOn;
        if (isLanternOn)
        {
            LanternOff.SetActive(true);
        }
        else
            LanternOff.SetActive(false);
    }
}
