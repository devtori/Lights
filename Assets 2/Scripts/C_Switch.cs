using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Switch : MonoBehaviour, C_IInteractable
{
    [HideInInspector]
    public enum LightProperty { on, off }
    [HideInInspector]
    public LightProperty lightproperty;

    private C_DoorInteraction door;
    private C_DisplayImage displayimage;

    public GameObject first;
    public GameObject last;
    public GameObject canvas;

    private C_Puzzlecontrol puzzlecontrol;
    void Start () {
        
        displayimage = GameObject.Find("displayImage").GetComponent<C_DisplayImage>();
        door = GameObject.Find("door interact").GetComponent<C_DoorInteraction>();
        puzzlecontrol = GameObject.Find("puzzlecontrol").GetComponent<C_Puzzlecontrol>();
       
    }

    public void Interact(C_DisplayImage currentDisplay)
    {
        if (displayimage.CurrentWall < 10)
        {
            
            Debug.Log("turn off");
            displayimage.CurrentWall += 10;
            if(door.cat.activeSelf == true)
            {
                Invoke("Catlight", 3);
            }
            lightproperty = LightProperty.off;
            if (puzzlecontrol.puzzle > 10 && door.DoorProperty == C_DoorInteraction.DoorState.close)
            {
                last.gameObject.SetActive(true);
                first.gameObject.SetActive(false);
                canvas.gameObject.SetActive(false);
                Debug.Log("clear!");
                
            }
        }
        else if (displayimage.CurrentWall > 10)
        {
            Debug.Log("turn on");
            displayimage.CurrentWall -= 10;
            lightproperty = LightProperty.on;

        }
    }

    public void Catlight()
    {
        if(displayimage.CurrentWall > 10)
        {
            Debug.Log("cat turn light on!");
            displayimage.CurrentWall -= 10;
            lightproperty = LightProperty.on;
        }
        
        
    }

    
   


}
