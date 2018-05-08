using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class w_password : MonoBehaviour {

    public GameObject ScreenPanel;
    //public GameObject ObtainItem;

    public bool isCorrectPassword = false;

    private GameObject displayImage;

    public string CorrectPassword;

    private string inputPassword;

    void Start()
    {
        displayImage = GameObject.Find("displayImage");

        //ObtainItem.SetActive(false);
        ScreenPanel.SetActive(false);
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        VerifyPassword();
        HideDisplay();
    }
    void VerifyPassword()
    {
        if (isCorrectPassword) return;

        if (Input.GetKey(KeyCode.Return))
        {
            inputPassword = ScreenPanel.transform.Find("Text").GetComponent<Text>().text;

            ScreenPanel.transform.Find("Text").GetComponent<Text>().text = "";


            if (inputPassword == CorrectPassword)
            {
                isCorrectPassword = true;
                Destroy(GameObject.Find("password"));
                Destroy(ScreenPanel);
            }
        }


    }

    void HideDisplay()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
        }

        if (displayImage.GetComponent<w_DisplayImage>().CurrentState == w_DisplayImage.State.normal)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isCorrectPassword) return;
        ScreenPanel.SetActive(false);
    }

}
