using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_OpenDoor : MonoBehaviour, A_IInteractable {

    [HideInInspector]
    public bool isOpen;
    public GameObject opend_door_light;
    public string UnlockItem;
    private A_Puzzlecontrol puzzlecontrol;
    private GameObject inventory;
    private bool locked;

    private A_DoorLight doorlight;

    void Start () {
        isOpen = false;
        opend_door_light.SetActive(false);
        inventory = GameObject.Find("Inventory");
        puzzlecontrol = GameObject.Find("puzzlecontrol").GetComponent<A_Puzzlecontrol>();
        doorlight = GameObject.Find("door light").GetComponent<A_DoorLight>();
        locked = true;
    }


    public void Interact(A_DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<A_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            opend_door_light.SetActive(true);
            puzzlecontrol.puzzle++;
            Debug.Log("Puzzle=" + puzzlecontrol.puzzle);
            inventory.GetComponent<A_Inventory>().currentSelectedSlot.GetComponent<A_Slot>().ClearSlot();
            locked = false;
            isOpen = true;

        }

        else if (locked == false && isOpen == false)
        {
            if(doorlight.isLight == true)
            {
                opend_door_light.SetActive(true);
                isOpen = true;
            }

            else if(doorlight.isLight == false)
            {
                doorlight.open_door_lightoff.SetActive(true);
                isOpen = true;
            }
        }
    }
}
