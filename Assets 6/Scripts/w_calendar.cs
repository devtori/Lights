using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class w_calendar : MonoBehaviour {

    public string month;

    public Sprite[] calendarSprites;
    public int currentIndividualIndex = 0;

    void Start()
    {
        LoadAllCalendarSprites();
    }

    void LoadAllCalendarSprites()
    {
        calendarSprites = Resources.LoadAll<Sprite>("Sprites/calendar");
    }
    
}
