using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class t_magnetic : MonoBehaviour, t_IInteractable
{
    private GameObject inventory;
    public GameObject[] magnetic = new GameObject[3];

    public GameObject[] ItemMag = new GameObject[3];


    void Start()
    {
        inventory = GameObject.Find("Inventory");
        for (int i = 0; i < 3; i++)
        {
            magnetic[i].SetActive(false);
            ItemMag[i].SetActive(false);
        }
    }

    public void Interact(t_DisplayImage currentDisplay)
    {
        if (magnetic[0].activeSelf)
        {
            ItemMag[0].SetActive(true);
            magnetic[0].SetActive(false);
        }
        else if(magnetic[1].activeSelf)
        {
            ItemMag[1].SetActive(true);
            magnetic[1].SetActive(false);
        }
        else if (magnetic[2].activeSelf)
        {
            ItemMag[2].SetActive(true);
            magnetic[2].SetActive(false);
        }
        else
        {
            if (inventory.GetComponent<t_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == "t_rabbit_item")
            {
                magnetic[0].SetActive(true);
                inventory.GetComponent<t_Inventory>().currentSelectedSlot.GetComponent<t_Slot>().ClearSlot();
            }
            if (inventory.GetComponent<t_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == "t_horse_item")
            {
                magnetic[1].SetActive(true);
                inventory.GetComponent<t_Inventory>().currentSelectedSlot.GetComponent<t_Slot>().ClearSlot();
            }
            if (inventory.GetComponent<t_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == "t_human_item")
            {
                magnetic[2].SetActive(true);
                inventory.GetComponent<t_Inventory>().currentSelectedSlot.GetComponent<t_Slot>().ClearSlot();
            }
        }
    }
}