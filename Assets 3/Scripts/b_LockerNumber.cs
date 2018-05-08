using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_LockerNumber : MonoBehaviour, b_IInteractable
{



    public void b_Interact(b_DisplayImage currentDisplay)
    {
        transform.parent.GetComponent<b_NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()]++;

        if (transform.parent.GetComponent<b_NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()] > 9)
            transform.parent.GetComponent<b_NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()] = 0;

        this.gameObject.GetComponent<SpriteRenderer>().sprite =
            transform.parent.GetComponent<b_NumberLock>().numberSprites[transform.parent.GetComponent<b_NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()]];
    }


}
