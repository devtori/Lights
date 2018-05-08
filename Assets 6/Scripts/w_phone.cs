using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w_phone : MonoBehaviour {

    public GameObject AccessObject;
    public bool isReversePhone = false;

    void Start()
    {
        AccessObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            isReversePhone = !isReversePhone;
            if (isReversePhone)
            {
                AccessObject.SetActive(true);
            }
            else
            {
                AccessObject.SetActive(false);
            }
        }
    }
}
