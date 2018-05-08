using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class t_dart : MonoBehaviour, t_IInteractable
{
    public enum State { correct, uncorrect}
    public State state;

    private GameObject inventory;
    public GameObject AccessObject;
    private string UnlockItem = "t_dart";
    

    void Start ()
    {
        inventory = GameObject.Find("Inventory");
        AccessObject.SetActive(false);
    }

    public void Interact(t_DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<t_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            AccessObject.SetActive(true);
            inventory.GetComponent<t_Inventory>().currentSelectedSlot.GetComponent<t_Slot>().ClearSlot();
        }
    }
}
