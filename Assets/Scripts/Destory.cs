using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Destory : MonoBehaviour {
    private GameObject inventory;
    public Button saveButton;
    private GameObject slots;

    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }
    public void clearInteractSlot_key()
    {
        slots = GameObject.Find("Slots");
        foreach (Transform slot in slots.transform) {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite ==  Resources.Load<Sprite>("InventoryItems/key"))
            {
                inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slot>().ClearSlot();
            }
        }
    }
    public void clearInteractSlot_cushion()
    {
        slots = GameObject.Find("Slots");
        foreach (Transform slot in slots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite == Resources.Load<Sprite>("InventoryItems/cushion"))
            {
                inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slot>().ClearSlot();
            }
        }
    }
    public void clearInteractSlot_book()
    {
        slots = GameObject.Find("Slots");
        foreach (Transform slot in slots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite == Resources.Load<Sprite>("InventoryItems/book"))
            {
                inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slot>().ClearSlot();
            }
        }
    }

}
