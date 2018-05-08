using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class e_MainLight : MonoBehaviour{
	
	private enum State {playing, clear};
	private State currentState;

	private e_DisplayImage currentDisplay;
	private GameObject clearDisplay;


	void Start () {
		currentState = State.playing;
		currentDisplay = GameObject.Find("displayImage").GetComponent<e_DisplayImage>();
		clearDisplay = GameObject.Find ("displayClearImage");
		clearDisplay.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
	}


	public void OnClickMainLight()
	{
		if (currentState == State.clear)
			Debug.Log ("Stage already cleared");
		else {
			if (currentDisplay.CurrentWall < 10) {
				GameObject.Find ("lightsManager").GetComponent<e_LightsManage> ().numberOfLights = GameObject.Find ("lightsManager").GetComponent<e_LightsManage> ().numberOfLights - 1;
				Debug.Log ("main light OFF / " + GameObject.Find ("lightsManager").GetComponent<e_LightsManage> ().numberOfLights + " lights left");
				currentDisplay.CurrentWall = currentDisplay.CurrentWall + 10;
				if (GameObject.Find ("lightsManager").GetComponent<e_LightsManage> ().numberOfLights == 0) {
					currentState = State.clear;
					Debug.Log ("Stage Clear!");
					StartCoroutine (SomeCoroutine ());
				}
		
			} else {
				Debug.Log ("main light ON");
				GameObject.Find ("lightsManager").GetComponent<e_LightsManage> ().numberOfLights = GameObject.Find ("lightsManager").GetComponent<e_LightsManage> ().numberOfLights + 1;
				currentDisplay.CurrentWall = currentDisplay.CurrentWall - 10;
			}
		}
	}
		
	IEnumerator SomeCoroutine()
	{
		Debug.Log ("Starting Animation . . .");
		yield return new WaitForSeconds(1f);
		clearDisplay.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
		yield return new WaitForSeconds(1f);
		clearDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/e_2");
		yield return new WaitForSeconds(1f);
		clearDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/e_3");
		yield return new WaitForSeconds(1f);
		clearDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/e_4");
		yield return new WaitForSeconds(1f);
		clearDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/e_5");
        d_GameClear.num++;
        SceneManager.LoadScene(0);
        yield return null;
	}

}
