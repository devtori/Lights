using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w_DisplayImage : MonoBehaviour {

    public enum State
    {
        normal, zoom, ChangedView, idle
    };

    public State CurrentState { get; set; }

    public int CurrentRoom
    {
        get { return currentRoom; }
        set
        {
            if (value == 5)
                currentRoom = 1;
            else if (value == 0)
                currentRoom = 4;
            else if (value == 15)
                currentRoom = 11;
            else if (value == 10)
                currentRoom = 14;
            else
                currentRoom = value;
        }
    }

    private int currentRoom;
    private int previousRoom;

    void Start()
    {
        CurrentState = State.normal;
        previousRoom = 0;
        currentRoom = 1;
    }

    private void Update()
    {
        if(currentRoom != previousRoom)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/room" + currentRoom.ToString());
        }

        previousRoom = currentRoom;
    }

}
