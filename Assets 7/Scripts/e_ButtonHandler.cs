using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class e_ButtonHandler : MonoBehaviour
{

    private e_DisplayImage currentDisplay;

    private float initialCameraSize;
    private Vector3 initialCameraPosition;

    private e_Switch switchOpen;

    private string isPassword;
    public e_ChangeView changeView;
    private InputField PasswordField;

    private GameObject monitorImage;
    private GameObject monitorChangeView;
    private GameObject monitorInteraction;


    // Use this for initialization
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<e_DisplayImage>();
        switchOpen = GameObject.Find("switchview").GetComponent<e_Switch>();
        monitorImage = GameObject.Find("monitor_on");
        monitorChangeView = GameObject.Find("viewchangemonitor");
        monitorInteraction = GameObject.Find("if monitor light off interation");

        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;
    }

    public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
    }

    public void OnClickReturn()
    {
        if (currentDisplay.CurrentState == e_DisplayImage.State.ChangedView)
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/e_wall" + currentDisplay.CurrentWall);
            currentDisplay.CurrentState = currentDisplay.PreviousState;
            switchOpen.input = "";
            if (changeView.additionalActive.activeInHierarchy)
                changeView.additionalActive.SetActive(false);
        }

        else
        {
            GameObject.Find("displayImage").GetComponent<e_DisplayImage>().CurrentState = e_DisplayImage.State.normal;
            var zoomInObjects = FindObjectsOfType<e_ZoominObject>();
            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }
            var firstZoomInObjects = FindObjectsOfType<e_ZoominFirst>();
            foreach (var firstzoomInObject in firstZoomInObjects)
            {
                firstzoomInObject.gameObject.layer = 0;
            }
            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }
    }


    public void OnClickEnter()
    {
        isPassword = GameObject.Find("PasswordText").GetComponent<Text>().text;
        if (isPassword == GameObject.Find("PasswordText").GetComponent<e_Password>().PW)
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/e_wall" + currentDisplay.CurrentWall);
            currentDisplay.CurrentState = currentDisplay.PreviousState;

            monitorImage.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            monitorImage.SetActive(false);
            monitorChangeView.SetActive(false);
            monitorChangeView.GetComponent<e_ChangeView>().additionalActive.SetActive(false);

            monitorInteraction.GetComponent<e_Lights>().currentLight = e_Lights.Light.lightsOFF;
            monitorInteraction.GetComponent<e_Lights>().offImage.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            GameObject.Find("lightsManager").GetComponent<e_LightsManage>().numberOfLights = GameObject.Find("lightsManager").GetComponent<e_LightsManage>().numberOfLights - 1;
            Debug.Log("monitor OFF/ " + GameObject.Find("lightsManager").GetComponent<e_LightsManage>().numberOfLights + " lights left");


        }
        else
        {
            PasswordField = GameObject.Find("PasswordField").GetComponent<InputField>();
            PasswordField.Select();
            PasswordField.text = "";
            Debug.Log("incorrect password");
        }
    }
}
