using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_NumberLock : MonoBehaviour
{

    public string Password;
    public GameObject OpenLockerSprite;
    [HideInInspector]
    public GameObject MovedCat;
    private GameObject displayImage;
    private GameObject hintpaper;
    private GameObject locker;

    private C_DoorInteraction door;
    [HideInInspector]
    public Sprite[] numberSprites;
    [HideInInspector]
    public int[] currentIndividualIndex = { 0, 0, 0, 0 };
    [HideInInspector]
    public bool isOpen;

    private C_Puzzlecontrol puzzlecontrol;
    void Start()
    {
        MovedCat = GameObject.Find("cat3_moved");
        MovedCat.SetActive(false);
        displayImage = GameObject.Find("displayImage");
        OpenLockerSprite.SetActive(false);
        isOpen = false;
        LoadAllNumberSprites();

        door = GameObject.Find("door interact").GetComponent<C_DoorInteraction>();
        puzzlecontrol = GameObject.Find("puzzlecontrol").GetComponent<C_Puzzlecontrol>();
        hintpaper = GameObject.Find("changeViewPoint(hint paper)");
        locker = GameObject.Find("changeViewPoint(locker)");

    }

    void Update()
    {
        OpenLocker();
        LayerManager();
    }

    public void LoadAllNumberSprites()
    {
        numberSprites = Resources.LoadAll<Sprite>("Sprites/c_numbers");
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
            OpenLockerSprite.SetActive(true);
            hintpaper.SetActive(false);
            locker.SetActive(false);
            for (int i = 0; i < 4; i++)
            {
                transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
                
            }
            if (door.Property == C_DoorInteraction.InteractionProperty.unlocked)
            {
                door.cat.SetActive(false);
                MovedCat.SetActive(true);
                puzzlecontrol.puzzle++;
                Debug.Log("Puzzle=" + puzzlecontrol.puzzle);
            }
            
            
        }
    }

    public void LayerManager()
    {
        if (isOpen) return;

        if (displayImage.GetComponent<C_DisplayImage>().CurrentState == C_DisplayImage.State.normal)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.layer = 2;
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.layer = 0;
            }
        }
    }

}
