using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_ChangeView : MonoBehaviour, b_IInteractable {

	public bool usable;

	public enum State { normal, zoom, firstzoom };
	public State changeCondition;

    public string SpriteName;
	public GameObject additionalActive;

	void Start ()
	{
	}


	public void b_Interact(b_DisplayImage currentDisplay)
    {
		

		if (usable == true &&
		((this.changeCondition == b_ChangeView.State.normal && currentDisplay.CurrentState == b_DisplayImage.State.normal) ||
			(this.changeCondition == b_ChangeView.State.firstzoom && currentDisplay.CurrentState == b_DisplayImage.State.firstzoom)||
				(this.changeCondition == b_ChangeView.State.zoom && currentDisplay.CurrentState == b_DisplayImage.State.zoom))
		) 
		{
			currentDisplay.PreviousState = currentDisplay.CurrentState;

			currentDisplay.GetComponent<SpriteRenderer>().sprite =
				Resources.Load<Sprite>("Sprites/" + SpriteName);

			currentDisplay.CurrentState = b_DisplayImage.State.ChangedView;

			if (this.name == "viewchangePhone") {
				this.GetComponent<b_Phone> ().haveSeen = true;
			} else {
			}



			if (additionalActive == null) {
			}
			else if (!additionalActive.activeInHierarchy) 
			{
				additionalActive.SetActive (true);
			}


   }

}
}
