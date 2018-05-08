using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class game : MonoBehaviour {

    public Button Window;
    public Button cushionButton;
    public Image book;
    public Button computerExitButton;
    public Button plugButton;
    public Image frame;
    public GameObject last;
    public Canvas inventory, wall3;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // endgame();
	}

   public void endgame()
    {
        if(!Window.gameObject.activeSelf && cushionButton.gameObject.activeSelf && book.gameObject.activeSelf && 
            computerExitButton.gameObject.activeSelf && !plugButton.gameObject.activeSelf && frame.gameObject.activeSelf)
        {
            last.gameObject.SetActive(true);
            inventory.gameObject.SetActive(false);
            wall3.gameObject.SetActive(false);

        }
    }
}
