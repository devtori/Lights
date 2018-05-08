using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_ChangeView : MonoBehaviour, e_IInteractable {

	public enum State { normal, zoom, firstzoom };
	public State changeCondition;

    public string SpriteName;
	public GameObject additionalActive;

	void Start ()
	{
	}


	public void Interact(e_DisplayImage currentDisplay)
    {
		if ((this.changeCondition == e_ChangeView.State.normal && currentDisplay.CurrentState == e_DisplayImage.State.normal) ||
			(this.changeCondition == e_ChangeView.State.firstzoom && currentDisplay.CurrentState == e_DisplayImage.State.firstzoom)||
			(this.changeCondition == e_ChangeView.State.zoom && currentDisplay.CurrentState == e_DisplayImage.State.zoom)) 
		{
			currentDisplay.PreviousState = currentDisplay.CurrentState;

			currentDisplay.GetComponent<SpriteRenderer>().sprite =
				Resources.Load<Sprite>("Sprites/" + SpriteName);

			currentDisplay.CurrentState = e_DisplayImage.State.ChangedView;


			if (additionalActive == null) {
			}

			else if (!additionalActive.activeInHierarchy) 
			{
				additionalActive.SetActive (true);
			}
		}


   }

}
