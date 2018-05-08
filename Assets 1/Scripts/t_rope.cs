using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_rope : MonoBehaviour, t_IInteractable
{
    public GameObject rope;
    public GameObject rope2;
    public GameObject untied;

    void Start()
    {
        untied.SetActive(false);
    }

    public void Interact(t_DisplayImage currentDisplay)
    {
        rope.SetActive(false);
        rope2.SetActive(false);
        untied.SetActive(true);
    }
}
