using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{

    public string DisplaySprite;
    public enum property { usable, displayable };

    public string DisplayImage;

    public string CombinationItem;

    public property itemProperty;

    private GameObject InventorySlots;

    public string displayImage;

    void Start()
    {
        InventorySlots = GameObject.Find("Slots");
    }

    public void ItemPickUp()
    {

        foreach (Transform slot in InventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item" )
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("InventoryItems/"+ DisplaySprite);
                slot.GetComponent<Slot>().AssignProperty((int)itemProperty, DisplayImage, CombinationItem);
                Destroy(gameObject);
                break;
            }
        }
    }


}

