using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfManager : MonoBehaviour {
    public GameObject wolf;
    // Use this for initialization


    void Start () {
       InvokeRepeating("SubScore", 0, 2);
        StartCoroutine("ChangeImage");
    }
	void SubScore()
    {
        ScoreManager.instance.subScore(1);
    }
    void OnMouseDown()
    {// 게임오브젝트를 다운 했을때
        Destroy(wolf);
    }
    // Update is called once per frame
    void Update () {
        
    }
    IEnumerator ChangeImage()
    {
        yield return new WaitForSeconds(0.3f); //0.3초뒤에 실행. 
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wolf_2");
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wolf_1");
        StartCoroutine("ChangeImage");


    }
}
