using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class b_DynamicObject : MonoBehaviour, b_IInteractable {

    public string UnlockItem;
	public enum DynamicState {lights, scenes}
	public DynamicState state;

    public GameObject ChangeStateSprite;
	public GameObject LightOnInteraction;


	private GameObject inventory;
	//private GameObject lightsOff;

		


    void Start()
    {
        ChangeStateSprite.SetActive(true);
        inventory = GameObject.Find("Inventory");
//		lightsOff = LightOnInteraction.GetComponent<b_Lights> ().offImage;
    }

	public void b_Interact(b_DisplayImage currentDisplay)
    {
		if (state == DynamicState.lights) {
//			LightOnInteraction.GetComponent<b_Lights> ().currentLight = b_Lights.Light.lightsOFF;
			//lightsOff.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);

			ChangeStateSprite.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
			ChangeStateSprite.SetActive (false);
			this.GetComponent<BoxCollider2D>().size = new Vector2 ((float)0.0001, 0);

//			GameObject.Find ("lightsManager").GetComponent<b_LightsManage> ().numberOfLights = GameObject.Find ("lightsManager").GetComponent<b_LightsManage> ().numberOfLights - 1;
//			Debug.Log ("somthing OFF / " + GameObject.Find ("lightsManager").GetComponent<b_LightsManage> ().numberOfLights + " lights left");
			this.GetComponent<BoxCollider2D> ().enabled = false;
		} 
		else if (state == DynamicState.scenes)
		{
			ChangeStateSprite.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
			ChangeStateSprite.SetActive(false);
			this.GetComponent<BoxCollider2D>().size = new Vector2 ((float)0.0001, 0);

		}
		else if (inventory.GetComponent<b_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
			ChangeStateSprite.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
            ChangeStateSprite.SetActive(false);
			this.GetComponent<BoxCollider2D>().size = new Vector2 ((float)0.0001, 0);


			if (inventory.GetComponent<b_Inventory> ().currentSelectedSlot.GetComponent<b_Slot> ().ItemProperty == b_Slot.property.usuable && UnlockItem != "") {
				inventory.GetComponent<b_Inventory> ().currentSelectedSlot.GetComponent<b_Slot> ().ClearSlot ();
			}

        }
			
	}

}
