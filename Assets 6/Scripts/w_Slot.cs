using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class w_Slot : MonoBehaviour, IPointerClickHandler
{
    private GameObject inventory;

    public enum property { usable, displayable, empty };
    public property ItemProperty { get; set; }

    private string displayImage;

    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.GetComponent<w_Inventory>().previousSelectedSlot = inventory.GetComponent<w_Inventory>().currentSelectedSlot;
        inventory.GetComponent<w_Inventory>().currentSelectedSlot = this.gameObject;
        if (ItemProperty == w_Slot.property.displayable) DisplayItem();
    }

    public void AssignProperty(int orderNumber, string displayImage)
    {
        ItemProperty = (property)orderNumber;
        this.displayImage = displayImage;
    }

    public void DisplayItem()
    {
        if(!inventory.GetComponent<w_Inventory>().itemDisplayer.activeSelf)
        {
            inventory.GetComponent<w_Inventory>().itemDisplayer.SetActive(true);
            inventory.GetComponent<w_Inventory>().itemDisplayer.GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory Items/" + displayImage);
        } 
		else 
		{
            inventory.GetComponent<w_Inventory>().HideDisplay();
        }
    }

    public void ClearSlot()
    {
        ItemProperty = w_Slot.property.empty;
        displayImage = "";
        transform.GetChild(0).GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory Items/empty_item");
    }
}