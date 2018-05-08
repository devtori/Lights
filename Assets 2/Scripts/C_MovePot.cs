using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_MovePot : MonoBehaviour, C_IInteractable
{

    public GameObject pot;
    public GameObject movedpot;
    private C_Puzzlecontrol puzzlecontrol;
    
    void Start()
    {
        pot.SetActive(true);
        movedpot.SetActive(false);
        puzzlecontrol = GameObject.Find("puzzlecontrol").GetComponent<C_Puzzlecontrol>();
        
       
    }


    public void Interact(C_DisplayImage currentDisplay)
    {
        pot.SetActive(false);
        movedpot.SetActive(true);
        this.gameObject.layer = 2;
        puzzlecontrol.puzzle++;
        Debug.Log("Puzzle=" + puzzlecontrol.puzzle);

    }
}
