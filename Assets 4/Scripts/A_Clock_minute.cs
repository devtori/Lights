using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Clock_minute : MonoBehaviour, A_IInteractable {
    [HideInInspector]
    public int clock;
    [HideInInspector]
    public bool m;
    private A_Clock_hour hour;
    public GameObject key2;

    void Start () {
        clock = 0; 
        m = false;
        hour = GameObject.Find("Clock_hour").GetComponent<A_Clock_hour>();
        key2.SetActive(false);
    }
	
	
    public void Interact(A_DisplayImage currentDisplay)
    {
        clock = clock - 30;
        this.gameObject.transform.Rotate(0, 0, -30);
        if (clock == -360)
        {
            clock = 0;
        }

        if (clock == -180 && hour.clock == -240)
        {
            Debug.Log("right");
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hour.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            key2.SetActive(true);
        }

        //if (hour.h && m)
        //{
        //    Debug.Log("right");
        //    this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //    hour.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //    key2.SetActive(true);
        //}
    }
}
