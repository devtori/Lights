﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_PickUpItem3 : MonoBehaviour, C_IInteractable
{

    public string DisplaySprite;
    public enum property { usable, displayable };

    public string DisplayImage;

    public string CombinationItem;

    public property itemProperty;

    private GameObject InventorySlots;

    public GameObject ChangedSprite;

    void Start()
    {
        ChangedSprite.SetActive(true);

    }
    public void Interact(C_DisplayImage currentDisplay)
    {
        ItemPickUp();

    }

    public void ItemPickUp()
    {
        InventorySlots = GameObject.Find("Slots");

        foreach (Transform slot in InventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "c_empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Inventory Items/" + DisplaySprite);
                slot.GetComponent<C_Slot>().AssignProperty((int)itemProperty, DisplayImage, CombinationItem);
                Destroy(gameObject);
                ChangedSprite.SetActive(false);

                break;
            }
        }
    }


}
