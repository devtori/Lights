using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class t_DynamicObject : MonoBehaviour, t_IInteractable
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

    public void Interact(t_DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<t_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem || UnlockItem == "")
        {
            if(UnlockItem == "t_key_cage")
            {
                GameObject.Find("unlockSound").GetComponent<AudioSource>().Play();
            }

            ChangedStateSprite.SetActive(true);
            this.gameObject.layer = 2;
            
            if (Property == InteractionProperty.simple_interaction) return;
            inventory.GetComponent<t_Inventory>().currentSelectedSlot.GetComponent<t_Slot>().ClearSlot();
            AccessObject.SetActive(true);
        }

    }
}
