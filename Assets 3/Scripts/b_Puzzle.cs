using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_Puzzle : MonoBehaviour {

	public GameObject firstSelectedPuzzle;
	public GameObject secondSelectedPuzzle;

	public GameObject ifAllRightActivate;
	public GameObject ifAllRightDeactivate;

	public GameObject book1;
	public GameObject book2;

	public GameObject[] Puzzle;


	private int numberRight;




	// Update is called once per frame
	void Update () {
		checkIfRight ();		
	}

	void checkIfRight()
	{
		if (
			(Puzzle [0].name == Puzzle [0].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [1].name == Puzzle [1].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [2].name == Puzzle [2].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [3].name == Puzzle [3].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [4].name == Puzzle [4].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [5].name == Puzzle [5].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [6].name == Puzzle [6].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [7].name == Puzzle [7].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [8].name == Puzzle [8].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [9].name == Puzzle [9].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [10].name == Puzzle [10].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [11].name == Puzzle [11].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [12].name == Puzzle [12].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [13].name == Puzzle [13].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [14].name == Puzzle [14].GetComponent<SpriteRenderer> ().sprite.name) &&
			(Puzzle [15].name == Puzzle [15].GetComponent<SpriteRenderer> ().sprite.name))
		{
			ifAllRightActivate.GetComponent<BoxCollider2D> ().size = new Vector2 ((float)13.67, (float)7.78);
			ifAllRightActivate.GetComponent<SpriteRenderer> ().color = new Color (ifAllRightActivate.GetComponent<SpriteRenderer> ().color.r, ifAllRightActivate.GetComponent<SpriteRenderer> ().color.g, ifAllRightActivate.GetComponent<SpriteRenderer> ().color.b, 1);
			ifAllRightDeactivate.SetActive (false);
			book1.GetComponent<b_books> ().goActive = true;
			book2.GetComponent<b_books> ().goActive = true;
		}
		
		else{
			
		}
			
	}
}
