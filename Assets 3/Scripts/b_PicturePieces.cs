using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class b_PicturePieces : MonoBehaviour, b_IInteractable {

	public GameObject puzzleBoard;
	private b_Puzzle Puzzle;

	private Sprite first;
	private Sprite second;
	//private GameObject temp;

	// Use this for initialization
	void Start () {
		Puzzle = puzzleBoard.GetComponent<b_Puzzle> ();

	}

	public void b_Interact(b_DisplayImage currentDisplay)
	{
		//Debug.Log ("clicked");


		if (Puzzle.secondSelectedPuzzle == null && Puzzle.firstSelectedPuzzle == null) 
		{
			Puzzle.firstSelectedPuzzle = this.gameObject;
			//Debug.Log (Puzzle.firstSelectedPuzzle.name);
		} 

		else if (Puzzle.secondSelectedPuzzle == null && Puzzle.firstSelectedPuzzle != null) 
		{
			Puzzle.secondSelectedPuzzle = this.gameObject;
			//Debug.Log (Puzzle.secondSelectedPuzzle.name);
		} 
	}




	void swap()
	{

		first = Puzzle.firstSelectedPuzzle.GetComponent<SpriteRenderer> ().sprite;
		second = Puzzle.secondSelectedPuzzle.GetComponent<SpriteRenderer> ().sprite;
			
		Puzzle.firstSelectedPuzzle.GetComponent<SpriteRenderer> ().sprite = second;
		Puzzle.secondSelectedPuzzle.GetComponent<SpriteRenderer> ().sprite = first;

		Puzzle.firstSelectedPuzzle = null;
		Puzzle.secondSelectedPuzzle = null;

	}
	
	// Update is called once per frame
	void Update () {
		if (Puzzle.secondSelectedPuzzle != null && Puzzle.firstSelectedPuzzle != null) 
		{
			swap ();
		}
	}
}
