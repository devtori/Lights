using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_hat : MonoBehaviour, t_IInteractable
{
    public GameObject hat;
    public GameObject hang;

    void Start()
    {
        hang.SetActive(false);
    }

    public void Interact(t_DisplayImage currentDisplay)
    {
        hat.SetActive(false);
        hang.SetActive(true);
    }
}
