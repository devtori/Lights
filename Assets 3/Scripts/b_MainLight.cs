using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class b_MainLight : MonoBehaviour{
	
	public enum State {playing, clear};
	public State currentState;

	private b_DisplayImage currentDisplay;
	private GameObject clearDisplay;
	private GameObject mainLight;



	void Start () {
		currentState = State.playing;
		currentDisplay = GameObject.Find("displayImage").GetComponent<b_DisplayImage>();
		clearDisplay = GameObject.Find ("displayClearImage");
		mainLight = GameObject.Find ("buttonMainLight");
	}


	public void OnClickMainLight()
	{
		if (currentState == State.clear) {
			Debug.Log ("Stage cleared");
		}
			
		else {
			if (currentDisplay.CurrentWall < 10) {
				currentDisplay.CurrentWall = currentDisplay.CurrentWall + 10;
				mainLight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/b_switch_off");
				currentDisplay.GetComponent<b_LightManager> ().lightNumbers = currentDisplay.GetComponent<b_LightManager> ().lightNumbers - 1;
				if (currentDisplay.GetComponent<b_LightManager> ().lightNumbers == 0) {
					currentState = State.clear;
					Debug.Log ("Stage Clear!");
					StartCoroutine (SomeCoroutine ());
				}
			} else {
				currentDisplay.CurrentWall = currentDisplay.CurrentWall - 10;
				mainLight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/b_switch");
				currentDisplay.GetComponent<b_LightManager> ().lightNumbers = currentDisplay.GetComponent<b_LightManager> ().lightNumbers + 1;
			}
		}
	}
		
	IEnumerator SomeCoroutine()
	{
		Debug.Log ("Starting Animation . . .");
		yield return new WaitForSeconds(1f);
		clearDisplay.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
		yield return new WaitForSeconds(1f);
		clearDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/b_2");
		yield return new WaitForSeconds(1f);
		clearDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/b_3");
		yield return new WaitForSeconds(1f);
		clearDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/b_4");
		yield return new WaitForSeconds(1f);
		clearDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/b_5");
		d_GameClear.num++;
		SceneManager.LoadScene(0);
		yield return null;
	}


}
