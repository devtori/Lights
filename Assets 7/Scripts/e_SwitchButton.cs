using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_SwitchButton : MonoBehaviour, e_IInteractable {
	public GameObject switchObject;

	public void Interact(e_DisplayImage currentDisplay)
	{
		switchObject.GetComponent<e_Switch> ().input = switchObject.GetComponent<e_Switch> ().input + this.name;
	}


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
