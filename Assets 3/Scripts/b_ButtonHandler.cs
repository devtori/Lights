using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class b_ButtonHandler : MonoBehaviour {

	private b_DisplayImage currentDisplay;

    private float initialCameraSize;
    private Vector3 initialCameraPosition;


	private string isPassword;
	private InputField PasswordField;

	private GameObject monitorImage;
	private GameObject monitorChangeView;
	private GameObject monitorInteraction;



	public GameObject lamp;
	public GameObject lampLight;
	public Color lampLightColor;

	public GameObject firstGame;
	public GameObject secondGame;
	public GameObject thirdGame;

	public GameObject mainLight;
	public GameObject kitchenLight;

	public GameObject test1;
	public GameObject test2;
	public GameObject test3;
	public GameObject locker;


	public GameObject[] ObjectsToManage;





	// Use this for initialization
	void Start () {
		currentDisplay = GameObject.Find("displayImage").GetComponent<b_DisplayImage>();
		monitorImage = GameObject.Find ("monitor_on");
		monitorChangeView = GameObject.Find ("viewchangemonitor");
		monitorInteraction = GameObject.Find ("if monitor light off interation");

		initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;

	}

    public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
		if (currentDisplay.CurrentWall == 1 || currentDisplay.CurrentWall == 11) {
			mainLight.SetActive (true);
		} else {
			mainLight.SetActive (false);
		}
		if (currentDisplay.CurrentWall == 2) {
			locker.SetActive (true);
		} else {
			locker.SetActive (false);
		}
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
		if (currentDisplay.CurrentWall == 1 || currentDisplay.CurrentWall == 11) {
			mainLight.SetActive (true);
		} else {
			mainLight.SetActive (false);
		}
		if (currentDisplay.CurrentWall == 2) {
			locker.SetActive (true);
		} else {
			locker.SetActive (false);
		}
    }

    public void OnClickReturn()
    {

		if (currentDisplay.CurrentState == b_DisplayImage.State.zoom && currentDisplay.PreviousState == b_DisplayImage.State.ChangedView)
		{
			GameObject.Find("displayImage").GetComponent<b_DisplayImage>().CurrentState = b_DisplayImage.State.ChangedView;
			currentDisplay.PreviousState = b_DisplayImage.State.normal;
			var zoomInObjects = FindObjectsOfType<b_ZoominObject>();
			foreach (var zoomInObject in zoomInObjects)
			{
				zoomInObject.gameObject.layer = 0;
			}
			var firstZoomInObjects = FindObjectsOfType<b_ZoominFirst>();
			foreach (var firstzoomInObject in firstZoomInObjects)
			{
				firstzoomInObject.gameObject.layer = 0;
			}
			Camera.main.orthographicSize = initialCameraSize;
			Camera.main.transform.position = initialCameraPosition;
		}

		else if (currentDisplay.CurrentState == b_DisplayImage.State.ChangedView && currentDisplay.GetComponent<SpriteRenderer>().sprite.name == "b_kitchen_off"){
			currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/b_wall" + currentDisplay.CurrentWall);
			currentDisplay.CurrentState = currentDisplay.PreviousState;
			Debug.Log ("good");
			test1.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
			test1.SetActive (false);
			test2.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
			test3.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
		}


		else if (currentDisplay.CurrentState == b_DisplayImage.State.ChangedView && currentDisplay.GetComponent<SpriteRenderer>().sprite.name != "b_kitchen_off") {

			currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/b_wall" + currentDisplay.CurrentWall);
			currentDisplay.CurrentState = currentDisplay.PreviousState;

			DeactivateObjects();

			firstGame.GetComponent<b_gameFirst> ().firstGameCount = 0;
			firstGame.GetComponent<b_gameFirst> ().firstGameText.text = "! Click !";

			secondGame.GetComponent<b_gameSecond> ().secondGameCount = 0;
			secondGame.GetComponent<b_gameSecond> ().secondGameText.text = "! Click !";

			thirdGame.GetComponent<b_gameThird> ().password = "";
			thirdGame.GetComponent<b_gameThird> ().thirdGameText.text = "Press ↑";

			lamp.GetComponent<b_Lamp> ().input = "";
			lampLight.GetComponent<SpriteRenderer> ().color = lampLightColor;
		}



        else
        {
			//GameObject.Find ("displayImage").GetComponent<b_DisplayImage> ().CurrentState = currentDisplay.PreviousState;
			//currentDisplay.PreviousState = b_DisplayImage.State.normal;
			GameObject.Find("displayImage").GetComponent<b_DisplayImage>().CurrentState = b_DisplayImage.State.normal;
			var zoomInObjects = FindObjectsOfType<b_ZoominObject>();
            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }
			var firstZoomInObjects = FindObjectsOfType<b_ZoominFirst>();
            foreach (var firstzoomInObject in firstZoomInObjects)
            {
                firstzoomInObject.gameObject.layer = 0;
            }
            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }

    }
		


	public void DeactivateObjects()
	{
		for (int i = 0; i < ObjectsToManage.Length; i++)
		{
			ObjectsToManage[i].SetActive(false);
			}
		}
	}

