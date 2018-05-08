using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class b_PickUpItem : MonoBehaviour, b_IInteractable {

    public string DisplaySprite;
    public enum Property { usuable, displayble, destroy, combined };
    public enum Identity { normal, firstzoom, zoomed, changeview, whatever};

    public string displayImage;
	public string combinationItem;

	private b_DisplayImage currentDisplay;

    public Property itemProperty;
    public Identity itemIdentity;
	public GameObject ifDestroyed;


    private GameObject InventorySlots;




	public void b_Interact(b_DisplayImage currentDisplay)
    {
        ItemPickUp();
    }

    void Start()
    {
		currentDisplay = GameObject.Find("displayImage").GetComponent<b_DisplayImage>();
    }

    public void ItemPickUp()
    {

        InventorySlots = GameObject.Find("Slots");

        foreach (Transform slot in InventorySlots.transform)
        {
			if (
				this.itemProperty == Property.combined ||
				this.itemIdentity == Identity.whatever ||
				(this.itemIdentity == b_PickUpItem.Identity.normal && currentDisplay.CurrentState == b_DisplayImage.State.normal) ||
				(this.itemIdentity == b_PickUpItem.Identity.firstzoom && currentDisplay.CurrentState == b_DisplayImage.State.firstzoom)||
				(this.itemIdentity == b_PickUpItem.Identity.zoomed && currentDisplay.CurrentState == b_DisplayImage.State.zoom)||
				(this.itemIdentity == b_PickUpItem.Identity.changeview && currentDisplay.CurrentState == b_DisplayImage.State.ChangedView)
				)
            {
				if (this.itemProperty == Property.combined)
					this.itemProperty = Property.usuable;
				else {
				}

				if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
					{
					if (this.itemProperty == b_PickUpItem.Property.destroy) 
					{
						Destroy (gameObject);
						ifDestroyed.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
						break;
					} 
					else 
					{
						slot.transform.GetChild(0).GetComponent<Image>().sprite =
							Resources.Load<Sprite>("Inventory Items/" + DisplaySprite);
						slot.GetComponent<b_Slot>().AssignProperty((int)itemProperty, (int)itemIdentity, displayImage, combinationItem);
						Destroy(gameObject);
						break;
					}
						
					}


            }
            
        }
    }


}

