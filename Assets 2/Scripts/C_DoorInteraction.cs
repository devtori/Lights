using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_DoorInteraction : MonoBehaviour, C_IInteractable
{

    public GameObject Audio;
    public GameObject ChangedStateSprite;

    [HideInInspector]
    public enum InteractionProperty { locked, unlocked }
    [HideInInspector]
    public enum DoorState { open, close };
    [HideInInspector]
    public InteractionProperty Property;
    [HideInInspector]
    public DoorState DoorProperty;
    public string UnlockItem;

    private GameObject inventory;
    [HideInInspector]
    public GameObject cat;
    [HideInInspector]
    public bool iscat;
    private C_NumberLock numberlock;

    private C_Puzzlecontrol puzzlecontrol;

    void Start()
    {
        ChangedStateSprite.SetActive(false);
        inventory = GameObject.Find("Inventory");
        Property = InteractionProperty.locked;
        DoorProperty = DoorState.close;
        cat = GameObject.Find("cat3");
        cat.SetActive(false);
        iscat = false;
        numberlock = GameObject.Find("numberLock").GetComponent<C_NumberLock>();
        puzzlecontrol = GameObject.Find("puzzlecontrol").GetComponent<C_Puzzlecontrol>();
    }

    public void Interact(C_DisplayImage currentDisplay)
    {
        if (Property == InteractionProperty.locked)
        {
            if (inventory.GetComponent<C_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem && Property == InteractionProperty.locked)
            {
                Debug.Log("Unlock!");
                Audio.SetActive(false);
                ChangedStateSprite.SetActive(true);
                inventory.GetComponent<C_Inventory>().currentSelectedSlot.GetComponent<C_Slot>().ClearSlot();
                Property = InteractionProperty.unlocked;
                DoorProperty = DoorState.open;

                if (numberlock.isOpen == true)
                {
                    numberlock.MovedCat.SetActive(true);
                    puzzlecontrol.puzzle++;
                    Debug.Log("Puzzle=" + puzzlecontrol.puzzle);
                }
                else
                {
                    cat.SetActive(true);
                    iscat = true;
                }
                
            }

        }

        else if (Property == InteractionProperty.unlocked)
        {
            if (DoorProperty == DoorState.open)
            {
                Debug.Log("close!");
                ChangedStateSprite.SetActive(false);
                DoorProperty = DoorState.close;
            }

            else if (Property == InteractionProperty.unlocked && DoorProperty == DoorState.close)
            {
                Debug.Log("open!");
                ChangedStateSprite.SetActive(true);
                // this.gameObject.layer = 2;
                DoorProperty = DoorState.open;
            }
        }



    }




}
