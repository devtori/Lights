using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class e_Drawer : MonoBehaviour, e_IInteractable {

    public string UnlockItem;
    private GameObject inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory");
        
    }
	public void Interact(e_DisplayImage currentDisplay)
    {
		if (inventory.GetComponent<e_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            Debug.Log("unlock");
			inventory.GetComponent<e_Inventory>().currentSelectedSlot.GetComponent<e_Slot>().ClearSlot();
        }
            

    }



}
