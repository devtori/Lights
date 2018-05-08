using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_DynamicObject : MonoBehaviour, A_IInteractable
{


    public GameObject ChangedStateSprite;
    public string UnlockItem;
    private A_Puzzlecontrol puzzlecontrol;
    private GameObject inventory;

    private A_OpenCloset closetstate;

    void Start () {
        ChangedStateSprite.SetActive(false);
        inventory = GameObject.Find("Inventory");
        puzzlecontrol = GameObject.Find("puzzlecontrol").GetComponent<A_Puzzlecontrol>();
        closetstate = GameObject.Find("open closet").GetComponent<A_OpenCloset>();
    }


    public void Interact(A_DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<A_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem || UnlockItem == "")
        {
            if(!(UnlockItem == "cloth" ) || (UnlockItem == "cloth" && closetstate.closet == false))
            {
                ChangedStateSprite.SetActive(true);
                this.gameObject.layer = 2;
                puzzlecontrol.puzzle++;
                Debug.Log("Puzzle=" + puzzlecontrol.puzzle);
                if (UnlockItem == "")
                    return;
                inventory.GetComponent<A_Inventory>().currentSelectedSlot.GetComponent<A_Slot>().ClearSlot();
            }
            
        }
    }
}
