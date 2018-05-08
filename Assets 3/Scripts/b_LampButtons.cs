using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class b_LampButtons : MonoBehaviour,b_IInteractable {
	private b_DisplayImage currentDisplay;

	public GameObject lamp;
	public GameObject lampON1;
	public GameObject lampON2;

	public GameObject changeView;

	public GameObject lampLight;
	public Color lampLightColor;

	private GameObject slot1;
	private GameObject slot2;
	private GameObject slot3;
	private GameObject slot4;
	private GameObject slot5;
	private GameObject slot6;
	private GameObject slot7;



	void Start()
	{
		lamp.GetComponent<b_Lamp> ().input = "";
		currentDisplay = GameObject.Find("displayImage").GetComponent<b_DisplayImage>();
	}

	public void b_Interact(b_DisplayImage currentDisplay) {
		lamp.GetComponent<b_Lamp> ().input = lamp.GetComponent<b_Lamp> ().input + this.name;
		lampLight.GetComponent<SpriteRenderer> ().color = lampLightColor;

		if (lamp.GetComponent<b_Lamp> ().input == lamp.GetComponent<b_Lamp> ().answer)
			ifClear ();

	}

	void ifClear()
	{
		lampON1.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
		lampON1.SetActive (false);
		lampON2.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
		lampON2.SetActive (false);

		changeView.SetActive (false);

		currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/b_wall" + currentDisplay.CurrentWall);
		currentDisplay.CurrentState = currentDisplay.PreviousState;

		Debug.Log ("clear");
		currentDisplay.GetComponent<b_LightManager> ().lightNumbers = currentDisplay.GetComponent<b_LightManager> ().lightNumbers - 1;
}
}