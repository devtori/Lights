using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class b_Inventory : MonoBehaviour {

    public GameObject currentSelectedSlot { get; set; }
    public GameObject previousSelectedSlot { get; set; }

    private GameObject slots;
    public GameObject itemDisplayer { get; private set; }

    void Start()
    {
        InitializeInventory();
        
    }

    void Update()
    {
        SelectSlot();
//        HideDisplay();
    }

    void InitializeInventory()
    {
        slots = GameObject.Find("Slots");
        itemDisplayer = GameObject.Find("ItemDisplayer");
        itemDisplayer.SetActive(false);
        
        foreach (Transform slot in slots.transform)
        {
            slot.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory Items/empty_item");
			slot.GetComponent<b_Slot>().ItemProperty = b_Slot.property.empty;
        }
        currentSelectedSlot = GameObject.Find("slot");
        previousSelectedSlot = currentSelectedSlot;

    }

    void SelectSlot()
    {
        foreach (Transform slot in slots.transform)
        {
			if (slot.gameObject == currentSelectedSlot && slot.GetComponent<b_Slot>().ItemProperty == b_Slot.property.usuable)
            {
                slot.GetComponent<Image>().color = new Color(1, 1, .5f, 1);
            }
			else if (slot.gameObject == currentSelectedSlot && slot.GetComponent<b_Slot>().ItemProperty == b_Slot.property.displayble)
            {
            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }

        }

    }

    public void HideDisplay()
    {
            itemDisplayer.SetActive(false);
		if (currentSelectedSlot.GetComponent<b_Slot>().ItemProperty == b_Slot.property.displayble)
            {
                currentSelectedSlot = previousSelectedSlot;
                previousSelectedSlot = currentSelectedSlot;
            }

        
    }
}
