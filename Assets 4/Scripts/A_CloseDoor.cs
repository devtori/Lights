using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_CloseDoor : MonoBehaviour, A_IInteractable {

    private A_OpenDoor opendoor;
    private A_DoorLight doorlight;
    public GameObject close_closet_nolight;

    void Start () {
        opendoor = GameObject.Find("open door").GetComponent<A_OpenDoor>();
        //close_closet_nolight.SetActive(false);
        doorlight = GameObject.Find("door light").GetComponent<A_DoorLight>();
    }

    public void Interact(A_DisplayImage currentDisplay)
    {
        if(opendoor.isOpen == true)
        {
            if(doorlight.isLight)
            {
                opendoor.opend_door_light.SetActive(false);
                opendoor.isOpen = false;
            }
            else if(doorlight.isLight == false)
            {
                doorlight.open_door_lightoff.SetActive(false);
                close_closet_nolight.SetActive(true);
                opendoor.isOpen = false;
            }
        }
    }

}
