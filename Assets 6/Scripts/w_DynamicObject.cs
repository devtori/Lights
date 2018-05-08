using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class w_DynamicObject : MonoBehaviour, w_IInteractable
{
    public GameObject ChangedStateSprite;

    public enum InteractionProperty {  simple_interaction, access_interaction }
    public InteractionProperty Property;

    public string UnlockItem;
    public GameObject AccessObject;

    private GameObject inventory;


    void Start()
    {
        ChangedStateSprite.SetActive(false);
        inventory = GameObject.Find("Inventory");
        AccessObject.SetActive(false);

    }

    public void Interact(w_DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<w_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem || UnlockItem == "")
        {
            ChangedStateSprite.SetActive(true);
            this.gameObject.layer = 2;

            if (Property == InteractionProperty.simple_interaction) return;
            inventory.GetComponent<w_Inventory>().currentSelectedSlot.GetComponent<w_Slot>().ClearSlot();
            AccessObject.SetActive(true);
        }

    }
}
