using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_MouseColor : MonoBehaviour {
	public Color startColor;
	public Color mouseOverColor;
	bool mouseOver = false;

	void OnMouseEnter()
	{
		mouseOver = true;
		GetComponent<SpriteRenderer> ().color = mouseOverColor;
	}

	void OnMouseExit()
	{
		mouseOver = false;
		GetComponent<SpriteRenderer> ().color = startColor;
	}
}
