using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_DynamicObject : MonoBehaviour, C_IInteractable
{


    public GameObject ChangedStateSprite;
    public string UnlockItem;
    private C_Puzzlecontrol puzzlecontrol;
    private GameObject inventory;

    void Start () {
        ChangedStateSprite.SetActive(false);
        inventory = GameObject.Find("Inventory");
        puzzlecontrol = GameObject.Find("puzzlecontrol").GetComponent<C_Puzzlecontrol>();
    }


    public void Interact(C_DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<C_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem || UnlockItem == "")
        {
            ChangedStateSprite.SetActive(true);
            this.gameObject.layer = 2;
            puzzlecontrol.puzzle++;
            Debug.Log("Puzzle=" + puzzlecontrol.puzzle);
            if (UnlockItem == "")
                return;
            inventory.GetComponent<C_Inventory>().currentSelectedSlot.GetComponent<C_Slot>().ClearSlot();
        }
    }
}
