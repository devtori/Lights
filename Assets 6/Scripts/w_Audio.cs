using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w_Audio : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        soundsMute();
    }

    void soundsMute()
    {
        if(Input.GetMouseButtonDown(0))
            audioSource.mute = !audioSource.mute;
    }
}
