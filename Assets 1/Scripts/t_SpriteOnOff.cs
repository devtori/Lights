using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_SpriteOnOff : MonoBehaviour {

    public GameObject[] OnOff;
    public GameObject[] IsOff;


    void Start()
    {
        for(int i=0; i<OnOff.Length; i++) OnOff[i].SetActive(false);
    }

    void Update()
    {
        LightOn();
    }
    public void LightOn()
    {
        for (int i = 0; i < OnOff.Length; i++)
        {
            if (IsOff[i].activeSelf)
            {
                OnOff[i].SetActive(true);
            }
            else
            {
                OnOff[i].SetActive(false);
            }
        }
    }
}
