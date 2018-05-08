using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_OpenCloset : MonoBehaviour,A_IInteractable {

    public GameObject opencloset;
    [HideInInspector]
    public bool closet;
    public string UnlockItem;
    private A_Puzzlecontrol puzzlecontrol;
    private GameObject inventory;
    [HideInInspector]
    public bool cloth;
    private bool locked;

    void Start()
    {
        opencloset.SetActive(false);
        closet = false;
        inventory = GameObject.Find("Inventory");
        puzzlecontrol = GameObject.Find("puzzlecontrol").GetComponent<A_Puzzlecontrol>();
        locked = true;
    }

    
    public void Interact(A_DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<A_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            opencloset.SetActive(true);
            puzzlecontrol.puzzle++;
            Debug.Log("Puzzle=" + puzzlecontrol.puzzle);
            inventory.GetComponent<A_Inventory>().currentSelectedSlot.GetComponent<A_Slot>().ClearSlot();
            closet = true;
            locked = false;
        }

        else if(closet == false && locked == false)
        {
            opencloset.SetActive(true);
            closet = true;
        }
    }
}
