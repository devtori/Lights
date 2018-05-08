using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_Lights : MonoBehaviour {

	public enum Light{ lightsON, lightsOFF }
	public enum Item{ remain, destroyed }
	public enum Property { light, item };

	public Light currentLight { get; set;}
	public Item currentItem { get; set;}
	public Property itemProperty;

	public GameObject offImage;
	public GameObject isItem;

	private e_DisplayImage currentDisplay;



	void Start()
	{
		currentLight = Light.lightsON;
		currentDisplay = GameObject.Find ("displayImage").GetComponent<e_DisplayImage> ();
	}

	void Update(){
		if (itemProperty == e_Lights.Property.light)
			turnOffLights ();
		else if (itemProperty == e_Lights.Property.item)
			itemOffLights ();
	}

	public void turnOffLights()
	{
		if (currentLight == Light.lightsOFF && currentDisplay.CurrentWall > 10) 
		{
			offImage.SetActive (false);
		}
		else
			offImage.SetActive (true);
	}

	public void itemOffLights()
	{
		if (currentItem == Item.remain)
			offImage.SetActive (true);
		else 
		{
			offImage.SetActive (false);
		}
			
	}
}
