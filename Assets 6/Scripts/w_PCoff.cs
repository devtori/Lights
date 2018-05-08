using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w_PCoff : MonoBehaviour {
    
    public GameObject AccessObject;
    public GameObject button;
    public bool isOffPC = false;


    void Start()
    {
        AccessObject.SetActive(true);
        button.SetActive(true);
    }
    public void TurnOutComputer()
    {
        isOffPC = !isOffPC;
        if (isOffPC)
        {
            AccessObject.SetActive(false);
            button.SetActive(false);
        }
        else
        {
            AccessObject.SetActive(true);
            button.SetActive(true);
        }
    }
}
