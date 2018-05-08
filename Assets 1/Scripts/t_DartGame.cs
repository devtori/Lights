using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_DartGame : MonoBehaviour, t_IInteractable{

    public GameObject battery;
    public GameObject Hint;
    public GameObject[] dart =new GameObject[3];

    public GameObject[] Pin;
    public GameObject[] dartSpace;

    private GameObject[] putted = new GameObject[3];
    private bool[] isCorrect = new bool[3];
    private GameObject[] puttedPin = new GameObject[3];
    int num;
	void Start ()
    {
        battery.SetActive(false);
        Hint.SetActive(false);

        for (int i = 0; i < 3; i++)
        {
            dart[i].SetActive(false);
            isCorrect[i] = false;
        }
    }

    public void Interact(t_DisplayImage currentDisplay)
    {
        num = 0;
        for (int i=0; i<45; i++)
        {
            if (Pin[i].activeSelf)
            {
                putted[num] = dartSpace[i];
                puttedPin[num] = Pin[i];
                num++;
            }
        }

        if(num == 3)
        {
            for(int i=0; i<3; i++)
            {
                if (putted[i].GetComponent<t_dart>().state == t_dart.State.correct)
                    isCorrect[i] = true;
            }

            if(isCorrect[0] && isCorrect[1] && isCorrect[2])
            {
                battery.SetActive(true);
                Hint.SetActive(true);
            }
            else
            {
                for(int i=0; i<3; i++)
                {
                    puttedPin[i].SetActive(false);
                    dart[i].SetActive(true);
                }
            }
        }
    }
}
