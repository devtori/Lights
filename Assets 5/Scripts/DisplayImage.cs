using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayImage : MonoBehaviour {
    public Button startButton;
    public Button howtoButton;
    public GameObject display;
    public Canvas txt;
    public GameObject sheep;
    public Button BackButton;
	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_1");
        StartCoroutine("PayRun");


    }
IEnumerator PayRun()
    {
        yield return new WaitForSeconds(0.15f); //0.3초뒤에 실행. 
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_2");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_3");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_4");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_5");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_6");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_7");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_8");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_9");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_10");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_11");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_12");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_13");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_14");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_15");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_16");
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_17");
        yield return new WaitForSeconds(0.15f);
       
        startButton.gameObject.SetActive(true);
        howtoButton.gameObject.SetActive(true);


    }
    public void GameClear()
    {
        if (ScoreManager.score == 50)
        {
            display.gameObject.SetActive(true);
            txt.gameObject.SetActive(false); Destroy(sheep);
            display.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/clear");
            d_GameClear.num++;
            SceneManager.LoadScene(0);

        }
    }
    public void GameOver()
    {
        if (Sheep.gameOver || ScoreManager.score < 0)
        {
            display.gameObject.SetActive(true);
             txt.gameObject.SetActive(false); Destroy(sheep);
            display.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/over");
            d_GameClear.num++;
            SceneManager.LoadScene(0);
        }
    }

    public void changeDisplayImage()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_16");
    }
    public void changeHowToDisplayImage()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/HOW");
        BackButton.gameObject.SetActive(true);
    }
    public void changeBackDisplayImage()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/m_17");
    }
    // Update is called once per frame
    void Update () {
       GameClear();
       GameOver();
    }
}
