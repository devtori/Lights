using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_CloseCloset : MonoBehaviour, A_IInteractable {

    private A_OpenCloset open;

    void Start () {
        open = GameObject.Find("open closet").GetComponent<A_OpenCloset>();
    }
	

    public void Interact(A_DisplayImage currentDisplay)
    {
        if(open.closet)
        {
            open.opencloset.SetActive(false);
            open.closet = false;
        }
    }
}
