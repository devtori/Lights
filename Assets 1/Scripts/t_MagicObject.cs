using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_MagicObject : MonoBehaviour {

    public GameObject rabbit;
    public GameObject human;
    public GameObject horse;

    public GameObject Play;
    public GameObject cutPlay;
    public GameObject bed;

    void Start()
    {
        Play.SetActive(true);
        cutPlay.SetActive(false);
        bed.SetActive(false);
    }
    void Update()
    {
        if(rabbit.activeSelf && human.activeSelf && horse.activeSelf)
        {
            GameObject.Find("automaticDoor").GetComponent<AudioSource>().Play();
            Play.SetActive(false);
            cutPlay.SetActive(true);
            bed.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
