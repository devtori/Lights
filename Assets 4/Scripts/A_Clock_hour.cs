using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Clock_hour : MonoBehaviour, A_IInteractable {
    [HideInInspector]
    public int clock;
    [HideInInspector]
    public bool h;
    private A_Clock_minute minute;
    public GameObject key2;

    void Start()
    {
        clock = 0;
        h = false;
        minute = GameObject.Find("Clock_minute").GetComponent<A_Clock_minute>();
        //key2.SetActive(false);

    }

    public void Interact(A_DisplayImage currentDisplay)
    {
        clock = clock - 30;
        this.gameObject.transform.Rotate(0, 0, -30);
        if (clock == -360)
        {
            clock = 0;
        }

        if (clock == -240 && minute.clock == -180)
        {
            Debug.Log("right");
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            minute.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            key2.SetActive(true);
        }

        //if (h && minute.m)
        //{
        //    Debug.Log("right");
        //    this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //    minute.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //    key2.SetActive(true);
        //}

    }

    
	
	
}
