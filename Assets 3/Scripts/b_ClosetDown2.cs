using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class b_ClosetDown2 : MonoBehaviour, b_IInteractable {

    public string UnlockItem;


    private GameObject inventory;


    void Start()
    {
        inventory = GameObject.Find("Inventory");

        
    }
	public void b_Interact(b_DisplayImage currentDisplay)
    {
		if (inventory.GetComponent<b_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            Debug.Log("unlock");
			inventory.GetComponent<b_Inventory>().currentSelectedSlot.GetComponent<b_Slot>().ClearSlot();
			this.GetComponent<BoxCollider2D> ().size = new Vector2 ((float)0.001, 0);


        }
            

    }



}
