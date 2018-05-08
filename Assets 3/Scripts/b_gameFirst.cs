using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class b_gameFirst : MonoBehaviour {

	public int firstGameCount;
	public GameObject firstGame;
	public GameObject secondGame;
	public Text firstGameText;

	private b_DisplayImage currentDisplay;
	private Sprite currentDisplayImage;




	// Use this for initialization
	void Start () {
		firstGameCount = 0;
		currentDisplay = GameObject.Find("displayImage").GetComponent<b_DisplayImage>();
	}

	public void OnFirstClick()
	{
		firstGameCount = firstGameCount + 1;

		if (firstGameCount == 9) {
			firstGameText.text = "Stop!";
			StartCoroutine(Wait()); 
		}
		else if(firstGameCount > 9){
			StopAllCoroutines();
			firstGameCount = 0;
			firstGameText.text = "! Click !";

		}
	}


	IEnumerator Wait(){
		yield return new WaitForSeconds (3);	
		if (currentDisplay.CurrentState == b_DisplayImage.State.ChangedView && currentDisplay.GetComponent<SpriteRenderer>().sprite.name == "b_monitor") {
			Debug.Log ("First Game clear!");
			secondGame.SetActive (true);
			firstGame.SetActive (false);
		}
	}
}


