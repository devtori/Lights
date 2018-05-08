using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class b_Slot : MonoBehaviour, IPointerClickHandler {

	private GameObject inventory;

	public enum property { usuable, displayble, destroy, empty, };
    public enum identity { always, zoomed };    
    public property ItemProperty { get; set; }
    public identity ItemIdentity { get; set; }


    private string displayImage;
	public string combinationItem { get; private set; }

    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }


    public void OnPointerClick(PointerEventData eventData)
    {
		inventory.GetComponent<b_Inventory>().previousSelectedSlot = inventory.GetComponent<b_Inventory>().currentSelectedSlot;
		inventory.GetComponent<b_Inventory>().currentSelectedSlot = this.gameObject;
		Combine();
		//Debug.Log (inventory.GetComponent<b_Inventory> ().currentSelectedSlot.name);

		if (ItemProperty == b_Slot.property.displayble) DisplayItem ();
    }

	public void AssignProperty(int orderNumber1, int orderNumber2, string displayImage, string combinationItem)
    {
        ItemProperty = (property)orderNumber1;
        ItemIdentity = (identity)orderNumber2;
        this.displayImage = displayImage;
		this.combinationItem = combinationItem;
    }

    public void DisplayItem()		
	{
		if (!inventory.GetComponent<b_Inventory> ().itemDisplayer.activeInHierarchy) {
			inventory.GetComponent<b_Inventory> ().itemDisplayer.SetActive (true);
			inventory.GetComponent<b_Inventory> ().itemDisplayer.GetComponent<Image> ().sprite = 
				Resources.Load<Sprite> ("Inventory Items/" + displayImage);
		} 
		else 
		{
			inventory.GetComponent<b_Inventory> ().HideDisplay ();
		}
    }


    public void ClearSlot()
    {
		ItemProperty = b_Slot.property.empty;
        displayImage = "";
		combinationItem = "";
        transform.GetChild(0).GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory Items/empty_item");
    }

	void Combine()
	{
		if (inventory.GetComponent<b_Inventory> ().previousSelectedSlot.GetComponent<b_Slot>().combinationItem
		    == this.gameObject.GetComponent<b_Slot> ().combinationItem && this.gameObject.GetComponent<b_Slot> ().combinationItem != "") {
			if (!(inventory.GetComponent<b_Inventory> ().previousSelectedSlot.GetComponent<b_Slot> ().displayImage == this.gameObject.GetComponent<b_Slot> ().displayImage)) {
				Debug.Log ("combine");
				GameObject resultItem = Instantiate (Resources.Load<GameObject> ("Combined Items/" + combinationItem));
				inventory.GetComponent<b_Inventory> ().previousSelectedSlot.GetComponent<b_Slot> ().ClearSlot ();
				ClearSlot ();
				resultItem.GetComponent<b_PickUpItem>().ItemPickUp ();
			}

		} 
		else {
		}
	}

}
