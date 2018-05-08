using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //points는 배열로 담을 수 있도록 한다.
    public Transform[] points;
   
    public GameObject monster;
    // 3초마다 몬스터를 만든다.
    public float createTime = 2.0f;
    

    // Use this for initialization
    void Start()
    {
        // points를 게임시작과 함께 배열에 담기
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        
        StartCoroutine(this.CreateMonster());
        StartCoroutine(this.createSpeed());
    }

    IEnumerator CreateMonster()
    {
        // 계속해서 createTime동안 monster생성
        while (true)
        {
            int idx = Random.Range(1, points.Length);

            GameObject Sheep = (GameObject)Instantiate(monster, points[idx].position, Quaternion.identity);
            Sheep.gameObject.SetActive(true);
            yield return new WaitForSeconds(createTime);
        }
    }
    public IEnumerator createSpeed()
    {
        while (true)
        {
            if (createTime >= 0.8f)
            {
                createTime -= 0.1f;
                yield return new WaitForSeconds(14f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }



}
