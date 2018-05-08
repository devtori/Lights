using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class A_Slot : MonoBehaviour, IPointerClickHandler
{
    private GameObject inventory;

    public enum property { usable, displayable, empty };
    public property ItemProperty { get; set; }

    private string displayImage;
    public string combinationItem { get; private set; }

    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.GetComponent<A_Inventory>().previousSelectedSlot = inventory.GetComponent<A_Inventory>().currentSelectedSlot;
        inventory.GetComponent<A_Inventory>().currentSelectedSlot = this.gameObject;
        Combine();
        if (ItemProperty == A_Slot.property.displayable) DisplayItem();
    }

    public void AssignProperty(int orderNumber, string displayImage, string combinationItem)
    {
        ItemProperty = (property)orderNumber;
        this.displayImage = displayImage;
        this.combinationItem = combinationItem;
    }

    public void DisplayItem()
    {
        inventory.GetComponent<A_Inventory>().itemDisplayer.SetActive(true);
        inventory.GetComponent<A_Inventory>().itemDisplayer.GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory Items/" + displayImage);
    }

    void Combine()
    {
        if (inventory.GetComponent<A_Inventory>().previousSelectedSlot.GetComponent<A_Slot>().combinationItem
            == this.gameObject.GetComponent<A_Slot>().combinationItem && this.gameObject.GetComponent<A_Slot>().combinationItem != "")
        {
            if(!(inventory.GetComponent<A_Inventory>().previousSelectedSlot.GetComponent<A_Slot>().displayImage == this.gameObject.GetComponent<A_Slot>().displayImage))
            {
                Debug.Log("combine");
                GameObject combinedItem = Instantiate(Resources.Load<GameObject>("Combined Items/" + combinationItem));
                inventory.GetComponent<A_Inventory>().previousSelectedSlot.GetComponent<A_Slot>().ClearSlot();
                ClearSlot();
                combinedItem.GetComponent<A_PickUpItem>().ItemPickUp();
            }

        }
    }

    public void ClearSlot()
    {
        ItemProperty = A_Slot.property.empty;
        displayImage = "";
        combinationItem = "";
        transform.GetChild(0).GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory Items/empty_item");
    }
}
