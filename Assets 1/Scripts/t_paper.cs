using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_paper : MonoBehaviour, t_IInteractable
{
    public GameObject ChangeState;


    void Start()
    {
        ChangeState.SetActive(false);
    }

    public void Interact(t_DisplayImage currentDisplay)
    {
        ChangeState.SetActive(true);
        gameObject.SetActive(false);

    }
}