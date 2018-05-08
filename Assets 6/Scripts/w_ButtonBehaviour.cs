using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class w_ButtonBehaviour : MonoBehaviour
{
    public enum ButtonId
    {
        roomChangeButton, returnButton, remoteMute, remotePower, computerMute, computerPower
    }

    public ButtonId ThisButtonId;
    private w_DisplayImage currentDisplay;
    private w_password PW;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<w_DisplayImage>();
        PW = GameObject.Find("password").GetComponent<w_password>();
    }

    void Update()
    {
        HideDisplay();
        Display();
    }
    void HideDisplay()
    {
        if ((currentDisplay.CurrentState == w_DisplayImage.State.normal || currentDisplay.CurrentState == w_DisplayImage.State.idle) && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }
        if (!(currentDisplay.CurrentState == w_DisplayImage.State.normal) && ThisButtonId == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }
        if (currentDisplay.GetComponent<SpriteRenderer>().sprite != Resources.Load<Sprite>("Sprites/room5") && (ThisButtonId == ButtonId.remoteMute || ThisButtonId == ButtonId.remotePower))
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
        }
        if (currentDisplay.GetComponent<SpriteRenderer>().sprite != Resources.Load<Sprite>("Sprites/monitorZoomIn") && (ThisButtonId == ButtonId.computerMute || ThisButtonId == ButtonId.computerPower))
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
        }
    }

    void Display()
    {
        if (!(currentDisplay.CurrentState == w_DisplayImage.State.normal) && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }

        if (currentDisplay.CurrentState == w_DisplayImage.State.normal && ThisButtonId == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }
        if (currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/room5") && (ThisButtonId == ButtonId.remoteMute || ThisButtonId == ButtonId.remotePower))
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }
        if (currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/monitorZoomIn") && (ThisButtonId == ButtonId.computerMute || ThisButtonId == ButtonId.computerPower))
        {
            if (PW.isCorrectPassword)
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 1);
                GetComponent<Button>().enabled = true;
            }
        }
    }
}