using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class e_DynamicObject : MonoBehaviour, e_IInteractable {

    public string UnlockItem;
	public enum DynamicState {lights, scenes}
	public DynamicState state;

    public GameObject ChangeStateSprite;
	public GameObject LightOnInteraction;


	private GameObject inventory;
	private GameObject lightsOff;

		


    void Start()
    {
        ChangeStateSprite.SetActive(true);
        inventory = GameObject.Find("Inventory");
		lightsOff = LightOnInteraction.GetComponent<e_Lights> ().offImage;
    }

	public void Interact(e_DisplayImage currentDisplay)
    {
		if (state == DynamicState.lights) 
		{
			LightOnInteraction.GetComponent<e_Lights> ().currentLight = e_Lights.Light.lightsOFF;
			lightsOff.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);

			ChangeStateSprite.SetActive (false);
			GameObject.Find ("lightsManager").GetComponent<e_LightsManage> ().numberOfLights = GameObject.Find ("lightsManager").GetComponent<e_LightsManage> ().numberOfLights - 1;
			Debug.Log ("somthing OFF / "+GameObject.Find ("lightsManager").GetComponent<e_LightsManage> ().numberOfLights+" lights left");
			this.GetComponent<BoxCollider2D> ().enabled = false;
		}

		else if (inventory.GetComponent<e_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            ChangeStateSprite.SetActive(false);

			if (inventory.GetComponent<e_Inventory> ().currentSelectedSlot.GetComponent<e_Slot> ().ItemProperty == e_Slot.property.usuable && UnlockItem != "") {
				inventory.GetComponent<e_Inventory> ().currentSelectedSlot.GetComponent<e_Slot> ().ClearSlot ();
			}

        }
			
	}

}
