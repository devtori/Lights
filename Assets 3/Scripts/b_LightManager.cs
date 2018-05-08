using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_LightManager : MonoBehaviour {

	public int lightNumbers;
	public GameObject mainLight;

	void Update()
	{
		if (lightNumbers == 0) {
			mainLight.GetComponent<b_MainLight> ().currentState = b_MainLight.State.clear;
		}
	}

}
