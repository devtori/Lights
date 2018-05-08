using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class computer : MonoBehaviour {
    int i = 0;
    public Button exitButton;
    public Button computerButton1;
    public Button computerButton2;
    public Button computerButton3;

    public void counterComputer()
    {
        
        i++;
        Debug.Log(i);
    }
    void Update()
    {
        if (i == 3 && !computerButton3.gameObject.activeSelf) {
            exitButton.gameObject.SetActive(true);
            computerButton1.gameObject.SetActive(false);
            computerButton2.gameObject.SetActive(false);
            computerButton3.gameObject.SetActive(false);
        }   

    }

}
