using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class w_pig : MonoBehaviour, w_IInteractable
{

    public string[] coin = new string[4];
    public GameObject key;
    public GameObject[] recoin = new GameObject[4];

    private GameObject inventory;
    private string spriteName;
    private string[] tmp = new string[4];
    int money = 0;
    int num = 0;

    public AudioSource plip;

    int i;

    void Start()
    {
        inventory = GameObject.Find("Inventory");
        key.SetActive(false);
        for (i = 0; i < 4; i++)
        {
            recoin[i].SetActive(false);
        }
    }

    public void Interact(w_DisplayImage currentDisplay)
    {
        spriteName = inventory.GetComponent<w_Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name;
        if (spriteName == coin[0] || spriteName == coin[1] || spriteName == coin[2] || spriteName == coin[3])
        {
            tmp[num] = spriteName;
            num++;
            money += int.Parse(spriteName);
            plip.Play();
            inventory.GetComponent<w_Inventory>().currentSelectedSlot.GetComponent<w_Slot>().ClearSlot();
            if(money == 650)
            {
                key.SetActive(true);
                for (int i = 0; i < 4; i++)
                    tmp[i] = "";
                money = 0;
                num = 0;
            }
            else if (money > 650)
            {
                for (int i = 0; i < 4; i++)
                {
                    switch (tmp[i])
                    {
                        case "500":
                            recoin[0].SetActive(true);
                            break;
                        case "100":
                            recoin[1].SetActive(true);
                            if (recoin[1].activeSelf)
                                recoin[2].SetActive(true);
                            break;
                        case "50":
                            recoin[3].SetActive(true);
                            break;
                        default:
                            break;

                    }
                    tmp[i] = "";
                }
                money = 0;
                num = 0;
            }
        }
    }
}
