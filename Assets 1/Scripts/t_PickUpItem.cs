using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class t_PickUpItem : MonoBehaviour, t_IInteractable
{

    public string DisplaySprite;
    public enum property { usable, displayable };

    public string DisplayImage;

    public property ItemProperty;

    private GameObject InventorySlots;

    public void Interact(t_DisplayImage currentDisplay)
    {
        ItemPickUp();
    }

    public void ItemPickUp()
    {
        InventorySlots = GameObject.Find("Slots");

        foreach (Transform slot in InventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Inventory Items/" + DisplaySprite);
                slot.GetComponent<t_Slot>().AssignProperty((int)ItemProperty, DisplayImage);
                gameObject.SetActive(false);
                break;
            }
        }
    }


}
