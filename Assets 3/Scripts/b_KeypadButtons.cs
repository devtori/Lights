using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class b_KeypadButtons : MonoBehaviour, b_IInteractable {
	public Text KeypadField;
	public string answer;
	public GameObject active;
	public GameObject deactive;


	public void b_Interact(b_DisplayImage currentDisplay)
	{
		if (this.name != "delete" && this.name != "enter") 
		{
			KeypadField.text = KeypadField.text + this.name;
		} 

		else if (this.name == "delete") 
		{
			if (KeypadField.text.Length == 0) {
			} else
				KeypadField.text = KeypadField.text.Substring (0, KeypadField.text.Length - 1);
		} 

		else if (this.name == "enter") 
		{
			if (KeypadField.text == answer) {
				KeypadField.text = "Unlocked!";
				active.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
				active.GetComponent<BoxCollider2D> ().size = new Vector2 ((float)2.5, (float)4.1);
				deactive.GetComponent<BoxCollider2D> ().size = new Vector2 ((float)0.0001, 0);
			} 
			else
			{
				KeypadField.text = "";
			}
		}
			

	}
		
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}
}
