using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class b_KitchenLight : MonoBehaviour{

	private enum State {playing, clear};
	private State currentState;

	private b_DisplayImage currentDisplay;
	private GameObject clearDisplay;
	private GameObject kitchenLight;

	private GameObject pot;

	public GameObject pot_off;
	public GameObject ifLightOff;

	void Start () {
		currentState = State.playing;
		currentDisplay = GameObject.Find("displayImage").GetComponent<b_DisplayImage>();
		clearDisplay = GameObject.Find ("displayClearImage");
		kitchenLight = GameObject.Find ("buttonKitchenLight");
		pot = GameObject.Find ("b_pot");


	}


	public void OnClickKitchenLight()
	{
		if (currentDisplay.GetComponent<SpriteRenderer>().sprite.name == "b_kitchen") {
			currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/b_kitchen_off");
			kitchenLight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/b_switch_off");
			currentDisplay.GetComponent<b_LightManager> ().lightNumbers = currentDisplay.GetComponent<b_LightManager> ().lightNumbers - 1;
			if (pot == null)
				pot_off.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
			} 
		else {
			currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/b_kitchen");
			kitchenLight.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/b_switch");
			currentDisplay.GetComponent<b_LightManager> ().lightNumbers = currentDisplay.GetComponent<b_LightManager> ().lightNumbers + 1;
			}
		}
	}



