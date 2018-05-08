using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_DoorLight : MonoBehaviour, A_IInteractable {

    private A_OpenDoor opendoor;
    [HideInInspector]
    public bool isLight;
    public GameObject open_door_lightoff;
    private A_Puzzlecontrol puzzlecontrol;

    void Start () {
        opendoor = GameObject.Find("open door").GetComponent<A_OpenDoor>();
        open_door_lightoff.SetActive(false);
        isLight = true;
        puzzlecontrol = GameObject.Find("puzzlecontrol").GetComponent<A_Puzzlecontrol>();
    }
    public void Interact(A_DisplayImage currentDisplay)
    {
        if(opendoor.isOpen == true && isLight == true)
        {
            opendoor.opend_door_light.SetActive(false);
            open_door_lightoff.SetActive(true);
            isLight = false;
            puzzlecontrol.puzzle++;
        }
    }

}
