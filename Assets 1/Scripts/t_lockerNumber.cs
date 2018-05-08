using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_lockerNumber : MonoBehaviour, t_IInteractable
{



    public void Interact(t_DisplayImage currentDisplay)
    {
        transform.parent.GetComponent<t_NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()]++;

        if (transform.parent.GetComponent<t_NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()] > 9)
            transform.parent.GetComponent<t_NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()] = 0;

        this.gameObject.GetComponent<SpriteRenderer>().sprite =
            transform.parent.GetComponent<t_NumberLock>().numberSprites[transform.parent.GetComponent<t_NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()]];
    }


}