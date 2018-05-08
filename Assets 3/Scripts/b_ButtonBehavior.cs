using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class b_ButtonBehavior : MonoBehaviour {

    public enum ButtonId
    {
        roomChangeButton, returnButton, mainLight, kitchenLight
    }

    public ButtonId ThisButtonId;
	public GameObject itemDisplayer;

	private b_DisplayImage currentDisplay;

    private void Start()
    {
		currentDisplay = GameObject.Find("displayImage").GetComponent<b_DisplayImage>();
    }


    private void Update()
    {
        HideDisplay();
        Display();
	}


    void HideDisplay()
    {
		if (currentDisplay.CurrentState == b_DisplayImage.State.normal && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }

		if (currentDisplay.CurrentState != b_DisplayImage.State.normal && ThisButtonId == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }

		if ((currentDisplay.CurrentState != b_DisplayImage.State.normal || itemDisplayer.activeInHierarchy == true) && ThisButtonId == ButtonId.mainLight) 
		{
			GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
				GetComponent<Image>().color.b, 0);
			GetComponent<Button>().enabled = false;
		}

		if (!(currentDisplay.GetComponent<SpriteRenderer>().sprite.name == "b_kitchen" ||currentDisplay.GetComponent<SpriteRenderer>().sprite.name == "b_kitchen_off") 
			|| (currentDisplay.CurrentState == b_DisplayImage.State.zoom)) 
		{
			GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
				GetComponent<Image>().color.b, 0);
			GetComponent<Button>().enabled = false;
		}


    }
    

    void Display()
    {
		if (currentDisplay.CurrentState != b_DisplayImage.State.normal && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }

		if (currentDisplay.CurrentState == b_DisplayImage.State.normal && ThisButtonId == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                    GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }

		if (currentDisplay.CurrentState == b_DisplayImage.State.normal && itemDisplayer.activeInHierarchy == false && ThisButtonId == ButtonId.mainLight) 
		{
			GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
				GetComponent<Image>().color.b, 1);
			GetComponent<Button>().enabled = true;
		}

		if ((currentDisplay.GetComponent<SpriteRenderer>().sprite.name == "b_kitchen"||currentDisplay.GetComponent<SpriteRenderer>().sprite.name == "b_kitchen_off") && currentDisplay.CurrentState == b_DisplayImage.State.ChangedView
			&&ThisButtonId == ButtonId.kitchenLight ) 
		{
			GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
				GetComponent<Image>().color.b, 1);
			GetComponent<Button>().enabled = true;
		}

    }
}
