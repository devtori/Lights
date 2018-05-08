using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_mood : MonoBehaviour {

    public GameObject moodZoomIn;
    public GameObject moodOn;


    void Start()
    {
        gameObject.SetActive(true);
    }
    void Update()
    {
        isCompleteMood();
    }

    void isCompleteMood()
    {
        if (moodZoomIn.activeSelf && moodOn.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
