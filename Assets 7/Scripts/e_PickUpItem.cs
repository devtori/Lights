using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class e_PickUpItem : MonoBehaviour, e_IInteractable {

    public string DisplaySprite;
    public enum Property { usuable, displayble, destroy };
    public enum Identity { normal, firstzoom, zoomed };

    public string displayImage;
	private e_DisplayImage currentDisplay;

    public Property itemProperty;
    public Identity itemIdentity;
	public GameObject ifDestroyed;

    private GameObject InventorySlots;



	public void Interact(e_DisplayImage currentDisplay)
    {
        ItemPickUp();
    }

    void Start()
    {
		currentDisplay = GameObject.Find("displayImage").GetComponent<e_DisplayImage>();
    }

    void ItemPickUp()
    {
        InventorySlots = GameObject.Find("Slots");



        foreach (Transform slot in InventorySlots.transform)
        {
			if ((this.itemIdentity == e_PickUpItem.Identity.normal && currentDisplay.CurrentState == e_DisplayImage.State.normal) ||
				(this.itemIdentity == e_PickUpItem.Identity.firstzoom && currentDisplay.CurrentState == e_DisplayImage.State.firstzoom)||
				(this.itemIdentity == e_PickUpItem.Identity.zoomed && currentDisplay.CurrentState == e_DisplayImage.State.zoom))
            {
				if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
					{
					if (this.itemProperty == e_PickUpItem.Property.destroy) 
					{
						Destroy (gameObject);
						ifDestroyed.GetComponent<e_Lights> ().currentItem = e_Lights.Item.destroyed;
						ifDestroyed.GetComponent<e_Lights> ().offImage.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
						break;
					} 
					else 
					{
						slot.transform.GetChild(0).GetComponent<Image>().sprite =
							Resources.Load<Sprite>("Inventory Items/" + DisplaySprite);
						slot.GetComponent<e_Slot>().AssignProperty((int)itemProperty, (int)itemIdentity, displayImage);
						Destroy(gameObject);
						break;
					}
						
					}


            }
            

            
        }
    }


}
