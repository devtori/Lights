using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class t_pigeon : MonoBehaviour
{

    public enum PigeonNum { one, two }
    public PigeonNum num;
    
    public GameObject[] hat = new GameObject[5];
    public GameObject Change;
    private AudioSource Flap;

    private GameObject OpenWindow;
    private GameObject OpenCurtain;


    private bool[] isActive = new bool[5];

    void Start()
    {
        Flap = GameObject.Find("birdFlap").GetComponent<AudioSource>();
        for (int i = 0; i < 5; i++)
        {
            isActive[i] = false;
        }
        OpenWindow = GameObject.Find("openWindow");
        OpenCurtain = GameObject.Find("openCurtain");
        Change.SetActive(false);
    }
    void Update()
    {
        Pigeon();
    }

    void Pigeon()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!hat[i].activeSelf)
                isActive[i] = true;
        }
        if (num == PigeonNum.one)
        {
            if ( isActive[0] && isActive[1] && isActive[2] && isActive[3] && isActive[4] && 
                OpenWindow.activeSelf && OpenCurtain.activeSelf)
            {
                StartCoroutine(Delay());
            }
        }
        if(num == PigeonNum.two)
        {
            if (isActive[0] && isActive[1] && isActive[2] && isActive[3] && isActive[4] &&
                Change.activeSelf)
            {
                Flap.Play();
                gameObject.SetActive(false);
            }
        }
    }

    IEnumerator Delay()
    {
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g,
                                                   GetComponent<SpriteRenderer>().color.b, 0);
        Change.SetActive(true);
        yield return new WaitForSeconds(1f);
        Flap.Play();
        Change.SetActive(false);
        gameObject.SetActive(false);
        yield return null;
    }
}
