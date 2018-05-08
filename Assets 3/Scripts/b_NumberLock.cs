using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_NumberLock : MonoBehaviour
{

    public string Password;
	public GameObject ifOpen;

    //public GameObject OpenLockerSprite;
    [HideInInspector]
    private GameObject displayImage;

    public Sprite[] numberSprites;
    [HideInInspector]
    public int[] currentIndividualIndex = { 0, 0, 0, 0 };
    [HideInInspector]

    public bool isOpen;

    void Start()
    {
        displayImage = GameObject.Find("displayImage");
        //OpenLockerSprite.SetActive(false);
        isOpen = false;
        LoadAllNumberSprites();


    }

    void Update()
    {
        OpenLocker();
    }

    public void LoadAllNumberSprites()
    {
        numberSprites = Resources.LoadAll<Sprite>("Sprites/b_numbers");
    }




    public bool VerifyCorrectCode()
    {
        bool correct = true;

        for (int i = 0; i < 4; i++)
        {
            if (Password[i] != transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Substring(transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Length -1)[0])
            {
                correct = false;
            }
        }

        return correct;
    }


    public void OpenLocker()
    {
        if (isOpen) return;

        if (VerifyCorrectCode())
        {
            Debug.Log("Correct Password!");
            isOpen = true;
            //OpenLockerSprite.SetActive(true);
			ifOpen.GetComponent<BoxCollider2D>().size = new Vector2 (2, (float)0.8);
            for (int i = 0; i < 4; i++)
            {
                transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;

            }
        }
    }



}
