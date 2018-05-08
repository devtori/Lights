using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class t_mainLight : MonoBehaviour
{

    public enum LightProperty { on, off }
    private t_DisplayImage currentDisplay;

    public LightProperty lightproperty;

    public GameObject Rbutton;
    public GameObject Lbutton;
    public GameObject inventory;
    public GameObject moodOff;
    public GameObject lantern;
    public GameObject bedOpen;
    public GameObject window;
    public GameObject curtain;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<t_DisplayImage>();
    }

    void Update()
    {
        Display();
        HideDisplay();
    }

    void HideDisplay()
    {
        if (!(currentDisplay.CurrentState == t_DisplayImage.State.normal))
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }
        if (currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/t_room1") || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/t_room2")
            || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/roomt_3") || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/t_room11")
            || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/roomt_12") || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/t_room13")
            || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/t_1") || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/t_2")
            || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/t_3") || currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/t_,,4"))
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }

    }

    void Display()
    {
        if (currentDisplay.CurrentState == t_DisplayImage.State.normal && currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/t_room4"))
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                                    GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }
        if (currentDisplay.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Sprites/t_room14"))
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

        if (lightproperty == LightProperty.off && moodOff.activeSelf && lantern.activeSelf && bedOpen.activeSelf
            && curtain.activeSelf && window.activeSelf)
        {
                Rbutton.SetActive(false);
                Lbutton.SetActive(false);
                inventory.SetActive(false);
                StartCoroutine(SomeCoroutine());
                Debug.Log("clear!");
                return;
        }
    }
    IEnumerator SomeCoroutine()
    {
        
      
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/t_1");
        yield return new WaitForSeconds(1f);
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/t_2");
        yield return new WaitForSeconds(1f);
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/t_3");
        yield return new WaitForSeconds(1f);
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/t_4");
        yield return new WaitForSeconds(1f);
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/t_5");
        yield return new WaitForSeconds(1f);
        d_GameClear.num++;
        SceneManager.LoadScene(0);
        yield return null;
    }

}
