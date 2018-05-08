using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject currentSelectedSlot { get; set; }
    public GameObject previousSelectedSlot { get; set; }

    private GameObject slots;
    public GameObject itemDisplayer { get; private set; }
    public string UnlockItem;
    public string cushion;
    public string book;
    private GameObject inventory;
    public Button lockButton;
    public Button cushionButton;
    public Button bookButton;

    void Start()
    {
        InitializeInventory();
        inventory = GameObject.Find("Inventory");
    }

    private void Update()
    {
        SelectSlot();
       
    }


    void InitializeInventory()
    {
        slots = GameObject.Find("Slots");
       
        foreach (Transform slot in slots.transform)
        {
            slot.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("InventoryItems/empty_item");
            
        }
       
        
    }

   void SelectSlot()
    {
        foreach (Transform slot in slots.transform)
        {
            if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.usable)
            {
                slot.GetComponent<Image>().color = new Color(1, 1, .5f, 1);
                if (inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
                {
                    lockButton.gameObject.SetActive(true);
                }
                if (inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == cushion)
                {
                    cushionButton.gameObject.SetActive(true);
                }
                if (inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == book)
                {
                    bookButton.gameObject.SetActive(true);
                }
            }
            else if(slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
            {
                slot.GetComponent<Slot>().DisplayItem();
            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }

  
    }
    

}