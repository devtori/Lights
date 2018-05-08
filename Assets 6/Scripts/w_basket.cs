using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w_basket : MonoBehaviour {

    public GameObject AccessObject;
    public bool isRemoteIn = false;

    void Start()
    {
        AccessObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRemoteIn = !isRemoteIn;
            if (isRemoteIn)
            {
                AccessObject.SetActive(true);
                GameObject.Find("usingremote").SetActive(false);
            }
            else
            {
                AccessObject.SetActive(false);
            }
        }
    }
}
