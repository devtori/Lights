using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class w_Inventory : MonoBehaviour
{

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
            slot.GetComponent<w_Slot>().ItemProperty = w_Slot.property.empty;
        }
        currentSelectedSlot = GameObject.Find("slot");
        previousSelectedSlot = currentSelectedSlot;
    }

    void SelectSlot()
    {
        foreach (Transform slot in slots.transform)
        {
            if (slot.gameObject == currentSelectedSlot && slot.GetComponent<w_Slot>().ItemProperty == w_Slot.property.usable)
            {
                slot.GetComponent<Image>().color = new Color(1, 1, .5f, 1);
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

        if (currentSelectedSlot.GetComponent<w_Slot>().ItemProperty == w_Slot.property.displayable)
        {
            currentSelectedSlot = previousSelectedSlot;
            previousSelectedSlot = currentSelectedSlot;
        }
    }
}
