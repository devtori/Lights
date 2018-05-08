using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Trash : MonoBehaviour, C_IInteractable
{

    private GameObject inventory;
    private C_Puzzlecontrol puzzlecontrol;
    void Start()
    {
        inventory = GameObject.Find("Inventory");
        puzzlecontrol = GameObject.Find("puzzlecontrol").GetComponent<C_Puzzlecontrol>();
    }

    public void Interact(C_DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<C_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == "c_trash")
        {
            Debug.Log("trash destroy");
            inventory.GetComponent<C_Inventory>().currentSelectedSlot.GetComponent<C_Slot>().ClearSlot();
            puzzlecontrol.puzzle++;
            Debug.Log("Puzzle=" + puzzlecontrol.puzzle);
        }
    }


}
