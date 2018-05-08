using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Switch : MonoBehaviour, A_IInteractable
{
    [HideInInspector]
    public enum LightProperty { on, off }
    [HideInInspector]
    public LightProperty lightproperty;

    private A_DisplayImage displayimage;

    public GameObject first;
    public GameObject last;
    public GameObject canvas;

    private A_Puzzlecontrol puzzlecontrol;
    void Start()
    {

        displayimage = GameObject.Find("displayImage").GetComponent<A_DisplayImage>();
        puzzlecontrol = GameObject.Find("puzzlecontrol").GetComponent<A_Puzzlecontrol>();

    }

    public void Interact(A_DisplayImage currentDisplay)
    {
        if (displayimage.CurrentWall < 10)
        {
            Debug.Log("turn off");
            displayimage.CurrentWall += 10;
            
            lightproperty = LightProperty.off;
            if (puzzlecontrol.puzzle == 6 )
            {
                Debug.Log("clear!");
                last.gameObject.SetActive(true);
                first.gameObject.SetActive(false);
                canvas.gameObject.SetActive(false);
            }
        }
        else if (displayimage.CurrentWall > 10)
        {
            Debug.Log("turn on");
            displayimage.CurrentWall -= 10;
            lightproperty = LightProperty.on;

        }
    }

    





}
