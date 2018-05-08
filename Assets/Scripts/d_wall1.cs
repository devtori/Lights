using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class d_wall1 : MonoBehaviour {
    public GameObject radio;
    public Button AudioButton;

    // Use this for initialization
    void Start () {
        Debug.Log(SceneManager.GetActiveScene().buildIndex );
        if (SceneManager.GetActiveScene().buildIndex == 2 && AudioButton.gameObject.activeSelf)
        {
            radio.gameObject.SetActive(true);
        }else
        {
            radio.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
