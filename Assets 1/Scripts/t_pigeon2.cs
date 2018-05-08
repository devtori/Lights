using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_pigeon2 : MonoBehaviour
{
    public GameObject cagePigeon;
    public GameObject pigeon2;

	void Start () {
        cagePigeon.SetActive(false);
	}
	
	void Update () {
        Pigeon();
	}

    void Pigeon()
    {
        if (!pigeon2.activeSelf)
        {
            cagePigeon.SetActive(true);
        }
    }
}
