using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class b_gameSecond : MonoBehaviour {
	public GameObject secondGame;
	public GameObject thirdGame;
	public Text secondGameText;

	public int secondGameCount;
	private b_DisplayImage currentDisplay;
	private Sprite currentDisplayImage;

	void Start () {
		secondGameCount = 0;
		currentDisplay = GameObject.Find("displayImage").GetComponent<b_DisplayImage>();
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(1))
		{
			secondGameCount = secondGameCount + 1;
			if (secondGameCount == 14) {
				secondGameText.text = "Stop!";
				StartCoroutine(Wait()); 
			}
			else if(secondGameCount > 14){
				StopAllCoroutines();
				secondGameText.text = "! Click !";
				secondGameCount = 3;
			}
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (3);	
		if (currentDisplay.CurrentState == b_DisplayImage.State.ChangedView && currentDisplay.GetComponent<SpriteRenderer>().sprite.name == "b_monitor") {
			yield return new WaitForSeconds (2);
			Debug.Log ("Second Game clear!");
			secondGame.SetActive (false);
			thirdGame.SetActive (true);
		}
	}


}
