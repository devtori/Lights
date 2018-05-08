using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class d_GameClear : MonoBehaviour {
   public static int num = 0;
    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/d_1");
        StartCoroutine("ChangeRun");
    }
    IEnumerator ChangeRun()
    {
        yield return new WaitForSeconds(1f); //0.3초뒤에 실행. 
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/d_2");
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/d_3");
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/d_4");
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/d_5");
        yield return new WaitForSeconds(1f);
        num++;
        SceneManager.LoadScene(0);

    }
    // Update is called once per frame
    void Update () {
		
	}
}
