using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour {
    public GameObject radio1;
	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            radio1.gameObject.SetActive(true);
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
