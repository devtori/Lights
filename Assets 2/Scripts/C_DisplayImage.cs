﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_DisplayImage : MonoBehaviour {

    public enum State
    {
        normal, zoom, ChangedView
    };

    public State CurrentState { get; set; }
    

    public int CurrentWall
    {
        get { return currentWall; }
        set
        {
            if (value == 5)
                currentWall = 1;
            else if (value == 0)
                currentWall = 4;
            else if (value == 15)
                currentWall = 11;
            else if (value == 10)
                currentWall = 14;
            else
                currentWall = value;

        }

    }
    private int currentWall;
    private int previousWall;

    void Start()
    {
        previousWall = 0;
        currentWall = 1;
        
    }

    void Update()
    {
        if (currentWall != previousWall )
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/c_wall" + currentWall.ToString());
        }

        previousWall = currentWall;
    }
}
