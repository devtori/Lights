using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w_mute : MonoBehaviour {

    public bool isMute = false;
    public AudioSource bgm;

    public void Mute()
    {
        isMute = !isMute;
        bgm.mute = isMute ? true : false;

    }
}
