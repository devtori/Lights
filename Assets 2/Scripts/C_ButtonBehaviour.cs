using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_ButtonBehaviour : MonoBehaviour {

    public enum ButtonId
    {
        roomChangeButton, returnButton
    }

    public ButtonId ThisButtonId;

    private C_DisplayImage currentDisplay;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<C_DisplayImage>();
    }

    void Update()
    {
        HideDisplay();
        Display();
    }
    void HideDisplay()
    {
        if (currentDisplay.CurrentState == C_DisplayImage.State.normal && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }

        if (!(currentDisplay.CurrentState == C_DisplayImage.State.normal) && ThisButtonId == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }
    }

    void Display()
    {
        if (!(currentDisplay.CurrentState == C_DisplayImage.State.normal) && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                   GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }

        if (currentDisplay.CurrentState == C_DisplayImage.State.normal && ThisButtonId == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }
    }
}
