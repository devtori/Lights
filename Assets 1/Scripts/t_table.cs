using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class t_table : MonoBehaviour, t_IInteractable
{
    public GameObject pigeon1;
    public GameObject pigeon2;
    public GameObject tableopen;
    public GameObject table;

    void Start()
    {
        table.SetActive(true);
        tableopen.SetActive(false);
    }

    public void Interact(t_DisplayImage currentDisplay)
    {
        if(!pigeon1.activeSelf && !pigeon2.activeSelf)
        {
            table.SetActive(false);
            tableopen.SetActive(true);
        }
    }
}
