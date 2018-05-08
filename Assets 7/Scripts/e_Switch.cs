using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_Switch : MonoBehaviour {

	public string input;
	public string answer;

	private GameObject buttons;
	private GameObject switches;
	private GameObject mainLight;

	void Start()
	{
		buttons = GameObject.Find("buttons");
		switches = GameObject.Find("switches");
		mainLight = GameObject.Find ("buttonMainLight");

		mainLight.SetActive (false);
	}

	void Update() 
	{
		InputSwitch ();
	}


	public void InputSwitch(){
		{
			if (input == answer) {
				buttons.SetActive (false);
				switches.SetActive (false);
				mainLight.SetActive (true);
			} else {
			}
		}
	}
}
