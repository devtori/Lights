using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Curtain2 : MonoBehaviour, A_IInteractable
{

    public GameObject ChangedSprite2;
    private A_Curtain1 curtain;
    private A_Curtain1 curtain1_2;
    public GameObject key1;
    public GameObject c;
    public GameObject c2;

    void Start()
    {
        key1.SetActive(false);
        ChangedSprite2.SetActive(false);
        curtain = GameObject.Find("curtain1").GetComponent<A_Curtain1>();
        curtain1_2 = GameObject.Find("curtain1_2").GetComponent<A_Curtain1>();
    }

    public void Interact(A_DisplayImage currentDisplay)
    {
        if (curtain.curtain1 == true || curtain1_2.curtain1 == true)
        {
            ChangedSprite2.SetActive(true);
            key1.SetActive(true);
            this.gameObject.SetActive(false);
            c.SetActive(false);
            c2.SetActive(false);
        }

    }
}