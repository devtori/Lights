using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class A_GameClear : MonoBehaviour {

    

    void Start () {
        StartCoroutine(SomeCoroutine());
    }
	
	
    IEnumerator SomeCoroutine()
    {
        //yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/a_1");
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/a_2");
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/a_3");
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/a_4");
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/a_5");
        d_GameClear.num++;
        SceneManager.LoadScene(0);
        yield return null;

    }

}
