using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_picture : MonoBehaviour {

    public GameObject mood;
    public GameObject moodoff;
    public GameObject lantern;
    public GameObject pic;

    void Start()
    {
        pic.SetActive(false);
    }
    void Update()
    {
        picture();
    }

    public void picture()
    {
        if (mood.activeSelf)
        {
            if (!moodoff.activeSelf && lantern.GetComponent<t_lantern>().isLanternOn)
            {
                pic.SetActive(true);
            }
            else
            {
                pic.SetActive(false);
            }
        }
    }
}
