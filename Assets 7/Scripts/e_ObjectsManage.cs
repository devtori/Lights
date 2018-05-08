﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class e_ObjectsManage : MonoBehaviour {

	private e_DisplayImage currentDisplay;

    public GameObject[] ObjectsToManage;

    void Start()
    {
		currentDisplay = GameObject.Find("displayImage").GetComponent<e_DisplayImage>();
    }

    void Update()
    {
        ManageObjects();
    }


    void ManageObjects()
    {
        for (int i = 0; i < ObjectsToManage.Length; i++)
        {
            if (ObjectsToManage[i].name == currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
            {
                ObjectsToManage[i].SetActive(true);
            }
            else
            {
                ObjectsToManage[i].SetActive(false);
            }
        }

    }
}
