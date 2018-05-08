using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("fence2") )
        { //부딪힌 객체가 적인지 검사합니다.
            Destroy(this.gameObject); //부딪힌 자신을 지웁니다.
           
        }
    }
}
