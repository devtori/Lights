using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_GameClear : MonoBehaviour {

    

    void Start () {
        StartCoroutine(SomeCoroutine());
    }
	
	
    IEnumerator SomeCoroutine()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/c_1");
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/c_2");
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/c_3");
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/c_4");
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/c_5");
        yield return new WaitForSeconds(1f);
        d_GameClear.num++;
        SceneManager.LoadScene(0);
    }

}
