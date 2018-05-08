using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w_calendarNumber : MonoBehaviour, w_IInteractable
{
    public void Interact(w_DisplayImage currentDisplay)
    {
        transform.parent.GetComponent<w_calendar>().currentIndividualIndex++;

        if (transform.parent.GetComponent<w_calendar>().currentIndividualIndex > 11)
            transform.parent.GetComponent<w_calendar>().currentIndividualIndex = 0;

        this.gameObject.GetComponent<SpriteRenderer>().sprite =
            transform.parent.GetComponent<w_calendar>().calendarSprites[transform.parent.GetComponent<w_calendar>().currentIndividualIndex];

    }
}
