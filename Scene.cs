using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour {
    public Canvas whiteCanvas;
    public Canvas introCanvas;

	// Use this for initialization
	void Start () {
        if (d_GameClear.num != 0)
        {
            whiteCanvas.gameObject.SetActive(false);
            introCanvas.gameObject.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
