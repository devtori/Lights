using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class b_BabyWants : MonoBehaviour, b_IInteractable {

	public string UnlockItem;
	public GameObject babyWants;
	public GameObject babyGotIt;
	public GameObject audioTest;
	public GameObject sleeping;

	private GameObject inventory;



	void Start()
	{
		inventory = GameObject.Find("Inventory");

	}
	public void b_Interact(b_DisplayImage currentDisplay)
	{
		if (inventory.GetComponent<b_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
		{
			if (UnlockItem == "b_jjubjjub") 
			{
				Debug.Log ("well done");
				audioTest.GetComponent<AudioSource>().mute = true;
			} else {
			}

			Debug.Log("unlock");
			inventory.GetComponent<b_Inventory>().currentSelectedSlot.GetComponent<b_Slot>().ClearSlot();
			babyWants.SetActive (false);
			babyGotIt.SetActive (false);
			sleeping.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
			currentDisplay.GetComponent<b_LightManager> ().lightNumbers = currentDisplay.GetComponent<b_LightManager> ().lightNumbers - 1;
		}


	}
}
