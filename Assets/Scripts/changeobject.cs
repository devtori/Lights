using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeobject : MonoBehaviour {
    public GameObject book1;
    public GameObject book2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void change()
    {
        if (book1.gameObject.activeSelf)
        {
            book2.gameObject.SetActive(true);
        }
        else
        {
            book2.gameObject.SetActive(false);
        }
    }
}
