using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class w_mainLight : MonoBehaviour {

    public enum LightProperty { on, off }
    private w_DisplayImage currentDisplay;

    public LightProperty lightproperty;

    public GameObject phone;
    public GameObject TVon;
    public GameObject PCon;
    public GameObject basket;
    private w_mute PCmute;

    public GameObject Rbutton;
    public GameObject Lbutton;
    public GameObject inventory;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<w_DisplayImage>();
        PCmute = GameObject.Find("PCmute").GetComponent<w_mute>();
    }

    void Update()
    {
        Display();
        HideDisplay();
    }

    void HideDisplay()
    {
        if (!(currentDisplay.CurrentState == w_DisplayImage.State.normal))
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }
        if (currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/room1") || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/room3")
            || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/room4") || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/room11")
            || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/room13") || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/room14")
            || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/1") || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/2")
            || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/3") || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/4"))
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }

    }

    void Display()
    {
        if (currentDisplay.CurrentState == w_DisplayImage.State.normal && currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/room2"))
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }
        if (currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/room12"))
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }
    }

    public void OnClickMainLight()
    {
        if (currentDisplay.CurrentRoom < 10)
        {
            currentDisplay.CurrentRoom = currentDisplay.CurrentRoom + 10;
            lightproperty = LightProperty.off;
        }
        else
        {
            currentDisplay.CurrentRoom = currentDisplay.CurrentRoom - 10;
            lightproperty = LightProperty.on;
        }

        if (lightproperty == LightProperty.off && phone.activeSelf && (!TVon.activeSelf) && (!PCon.activeSelf) && basket.activeSelf )
        {
            if (PCmute.isMute)
            {
                Rbutton.SetActive(false);
                Lbutton.SetActive(false);
                inventory.SetActive(false);
                StartCoroutine(SomeCoroutine());
                Debug.Log("clear!");
                return;
            }
        }
    }
    IEnumerator SomeCoroutine()
    {
        yield return new WaitForSeconds(1f);
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/1");
        yield return new WaitForSeconds(1f);
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/2");
        yield return new WaitForSeconds(1f);
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/3");
        yield return new WaitForSeconds(1f);
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/2");
        yield return new WaitForSeconds(1f);
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/3");
        yield return new WaitForSeconds(1f);
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/4");
        yield return null;
    }

}
