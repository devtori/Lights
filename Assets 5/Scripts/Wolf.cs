using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour {

    public GameObject wolf;
    public static float moveSpeed = 2.5f;
    // Use this for initialization
    void Start () {
       
        InvokeRepeating("SpawnWolf", 10, 10);
        StartCoroutine(this.speed());
    }
	
	// Update is called once per frame
	void Update () {

    }
    public IEnumerator speed()
    {
        while (true)
        {
            if (moveSpeed <= 6f)
            {
                moveSpeed += 0.1f;
                Debug.Log(moveSpeed);
                yield return new WaitForSeconds(8f);
            }
        }
    }
    void SpawnWolf()
    {
        float randomX = Random.Range(-6.07f, -1.62f);
        float randomY = Random.Range(-3.25f, 0.53f);
        GameObject Wolf =(GameObject)Instantiate(wolf, new Vector3(randomX, randomY, -0.15f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
        Wolf.gameObject.SetActive(true);   
    }

    
}
