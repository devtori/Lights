using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class b_books : MonoBehaviour, b_IInteractable {

	public bool goActive;

	public GameObject activeStateSprite;
	public GameObject deactivateSprite;


	private GameObject inventory;


	void Start()
	{
		activeStateSprite.SetActive (false);
		activeStateSprite.GetComponent<SpriteRenderer> ().color = new Color (activeStateSprite.GetComponent<SpriteRenderer> ().color.r, activeStateSprite.GetComponent<SpriteRenderer> ().color.g, activeStateSprite.GetComponent<SpriteRenderer> ().color.b, 0);
		inventory = GameObject.Find("Inventory");

	}

	public void b_Interact(b_DisplayImage currentDisplay){
		if (goActive == true) 
		{
			Debug.Log ("clicked");
			deactivateSprite.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
			activeStateSprite.GetComponent<SpriteRenderer> ().color = new Color (activeStateSprite.GetComponent<SpriteRenderer> ().color.r, activeStateSprite.GetComponent<SpriteRenderer> ().color.g, activeStateSprite.GetComponent<SpriteRenderer> ().color.b, 1);
			activeStateSprite.SetActive (true);
			this.GetComponent<BoxCollider2D> ().size = new Vector2 ((float)0.001, 0);
		}
	}
}