using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_Phone : MonoBehaviour {

	private float time = 2;
	private float count;

	public GameObject phoneOn;
	public GameObject phoneInteraction;
	public GameObject ifPhoneOff;

	public bool haveSeen = false;




	private b_DisplayImage currentDisplay;

	void Start()
	{
		haveSeen = false;
		currentDisplay = GameObject.Find("displayImage").GetComponent<b_DisplayImage>();
	}


	void Update()
	{
		if (haveSeen == true) countDown ();
	}



	void countDown(){
		time = time - Time.deltaTime;
		count = Mathf.FloorToInt (time);

		if (time <= 0) {
			phoneOn.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
			phoneOn.SetActive (false);
			phoneInteraction.SetActive (false);
			haveSeen = false;
			ifPhoneOff.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
			ifPhoneOff.SetActive (false);


			currentDisplay.GetComponent<b_LightManager> ().lightNumbers = currentDisplay.GetComponent<b_LightManager> ().lightNumbers - 1;
		}
	}


}
