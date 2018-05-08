using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class e_Slot : MonoBehaviour, IPointerClickHandler {

	private GameObject inventory;

	public enum property { usuable, displayble, destroy, empty, };
    public enum identity { always, zoomed };    
    public property ItemProperty { get; set; }
    public identity ItemIdentity { get; set; }


    private string displayImage;

    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }


    public void OnPointerClick(PointerEventData eventData)
    {
		inventory.GetComponent<e_Inventory>().previousSelectedSlot = inventory.GetComponent<e_Inventory>().currentSelectedSlot;
		inventory.GetComponent<e_Inventory>().currentSelectedSlot = this.gameObject;

		if (ItemProperty == e_Slot.property.displayble) DisplayItem ();
    }

    public void AssignProperty(int orderNumber1, int orderNumber2, string displayImage)
    {
        ItemProperty = (property)orderNumber1;
        ItemIdentity = (identity)orderNumber2;
        this.displayImage = displayImage;
    }

    public void DisplayItem()		
	{
		if (!inventory.GetComponent<e_Inventory> ().itemDisplayer.activeInHierarchy) {
			inventory.GetComponent<e_Inventory> ().itemDisplayer.SetActive (true);
			inventory.GetComponent<e_Inventory> ().itemDisplayer.GetComponent<Image> ().sprite = 
				Resources.Load<Sprite> ("Inventory Items/" + displayImage);
		} 
		else 
		{
			inventory.GetComponent<e_Inventory> ().HideDisplay ();
		}
    }


    public void ClearSlot()
    {
		ItemProperty = e_Slot.property.empty;
        displayImage = "";
        transform.GetChild(0).GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory Items/empty_item");
    }


}
