using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_LockerNumber : MonoBehaviour, C_IInteractable
{



    public void Interact(C_DisplayImage currentDisplay)
    {
        transform.parent.GetComponent<C_NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()]++;

        if (transform.parent.GetComponent<C_NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()] > 9)
            transform.parent.GetComponent<C_NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()] = 0;

        this.gameObject.GetComponent<SpriteRenderer>().sprite =
            transform.parent.GetComponent<C_NumberLock>().numberSprites[transform.parent.GetComponent<C_NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()]];
    }


}
