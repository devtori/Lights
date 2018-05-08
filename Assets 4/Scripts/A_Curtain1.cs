using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Curtain1 : MonoBehaviour, A_IInteractable {

    public GameObject ChangedSprite;
    [HideInInspector]
    public bool curtain1;

	void Start () {
        ChangedSprite.SetActive(false);
        curtain1 = false;
	}
	
    public void Interact(A_DisplayImage currentDisplay)
    {
        ChangedSprite.SetActive(true);
        curtain1 = true;
    }
}
