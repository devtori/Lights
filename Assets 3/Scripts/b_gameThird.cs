using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class b_gameThird : MonoBehaviour {

	private b_DisplayImage currentDisplay;

	public Text thirdGameText;
	public Text countDownText;

	public string password;
	private float time = 5;
	private float count;

	public GameObject monitorOn1;
	public GameObject monitorOn2;

	public GameObject changeView;
	public GameObject deactivate;

	void Start()
	{
		currentDisplay = GameObject.Find("displayImage").GetComponent<b_DisplayImage>();
		password = "";

	}
	
	// Update is called once per frame
	void Update ()
	{
		countDown ();
		first ();
		second ();
		third ();
	}



	void first(){
		if (password == "" && Input.GetKey ("up")) {
			password = "up";
			thirdGameText.text = "Press ↓";
		}

		else if (password == "up" && Input.GetKey ("down")) {
			password = "updown";
			thirdGameText.text = "Press ↑";
		}

		else if (password == "updown" && Input.GetKey ("up")) {
			Input.ResetInputAxes();
			password = "updownup";
			thirdGameText.text = "Press ↑";
		}
	}

	void second(){
		if (password == "updownup" && Input.GetKey ("up")) {
			password = "updownupup";
			thirdGameText.text = "Press ↓";
		}  
		else if (password == "updownupup" && Input.GetKey ("down")) {
			password = "updownupupdown";
			thirdGameText.text = "Press ↑";
		}
		else if (password == "updownupupdown" && Input.GetKey ("up")) {
			password = "updownupupdownup";
			thirdGameText.text = "Press ↓";
		}  
		else if (password == "updownupupdownup" && Input.GetKey ("down")) {
			password = "updownupupdownupdown";
			thirdGameText.text = "Press ↑";
		}  
		else if (password == "updownupupdownupdown" && Input.GetKey ("up")) {
			Input.ResetInputAxes();
			password = "updownupupdownupdownup";
			thirdGameText.text = "Press ↑";
		}  
	}

	void third(){
		if (password == "updownupupdownupdownup" && Input.GetKey ("up")) {
			password = "updownupupdownupdownupup";
			thirdGameText.text = "Press ↓";
		}  
		else if (password == "updownupupdownupdownupup" && Input.GetKey ("down")) {
			password = "updownupupdownupdownupupdown";
			Debug.Log ("CLEAR!");


			currentDisplay.GetComponent<b_LightManager> ().lightNumbers = currentDisplay.GetComponent<b_LightManager> ().lightNumbers - 1;

			monitorOn1.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
			monitorOn1.SetActive (false);
			monitorOn2.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
			monitorOn2.SetActive (false);
			changeView.SetActive (false);
			deactivate.SetActive (false);


			currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/b_wall" + currentDisplay.CurrentWall);
			currentDisplay.CurrentState = currentDisplay.PreviousState;

		}
	}

	void countDown(){
		time = time - Time.deltaTime;
		count = Mathf.FloorToInt (time);
		countDownText.text = ("Time : " + count);

		if (time <= 0) {
			password = "";
			thirdGameText.text = "Press ↑";
			time = 8.0f;
		}
	}
}




