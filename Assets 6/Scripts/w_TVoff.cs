using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w_TVoff : MonoBehaviour
{

    public GameObject AccessObject;
    public GameObject button;
    public bool isOffTV = false;
    private w_mute TVmute;


    void Start()
    {
        AccessObject.SetActive(true);
        TVmute = GameObject.Find("TVmute").GetComponent<w_mute>();
    }
    public void TurnOutTV()
    {
        if (TVmute.isMute)
        {
            isOffTV = !isOffTV;
            if (isOffTV)
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
}