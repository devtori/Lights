using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Cat : MonoBehaviour, C_IInteractable
{
    private GameObject inventory;
    public GameObject Audio;
    private C_Puzzlecontrol puzzlecontrol;

    private GameObject cat1;
    private GameObject cat1_2;
    void Start()
    {
        inventory = GameObject.Find("Inventory");
        puzzlecontrol = GameObject.Find("puzzlecontrol").GetComponent<C_Puzzlecontrol>();
        cat1 = GameObject.Find("cat1");
        cat1_2 = GameObject.Find("cat1_2");
        
    }

    public void Interact(C_DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<C_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == "c_cat_food")
        {
            inventory.GetComponent<C_Inventory>().currentSelectedSlot.GetComponent<C_Slot>().ClearSlot();
            Audio.SetActive(false);
            StartCoroutine(Coroutine());
            this.gameObject.SetActive(false);
            puzzlecontrol.puzzle++;
            Debug.Log("Puzzle=" + puzzlecontrol.puzzle);
        }
    }

    IEnumerator Coroutine()
    {
        cat1.SetActive(true);
        yield return new WaitForSeconds(1f);
        cat1.SetActive(false);
        cat1_2.SetActive(true);
        yield return null;
        Debug.Log("End Coroutine!");
    }
}