using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class C_CatSound : MonoBehaviour
{

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    void Start()
    {
        MusicSource.clip = MusicClip;

    }

    void Update()
    {
        if (MusicSource.isPlaying == false && SceneManager.GetActiveScene().buildIndex == 4)
        {
            MusicSource.Play();
            MusicSource.loop = true;

        }
    }



}