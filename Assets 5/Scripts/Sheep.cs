using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Sheep : MonoBehaviour
{

   
    bool check = true;
    bool check2 = true;
    bool check3;
   
    private Transform _transform;
    private bool _isJumping;
    private float _posY;        //오브젝트의 초기 높이
    private float _gravity;     //중력가속도
    private float _jumpPower;   //점프력
    private float _jumpTime;    //점프 이후 경과시간
    private bool isFirst=true;
    public GameObject sheep ;
    public GameObject save1, save2, save3;
    int number;
    int sucess;
    public static bool gameOver = false;
    void Start()
    {
        _transform = transform;
        _isJumping = false;
        _posY = transform.position.y;
        _gravity = 30f;
        _jumpPower = 16.5f;
        _jumpTime = 0.0f;
        StartCoroutine("ChangeImage");
        number = 0;
        sucess = 0;
        
        check3 = false;

    }


    
    void Update()
    {

        moveControl();
        DestorySheep();
        Move();
        AddScore();
       checkColider();
        

    }

    // 움직이는 기능을 하는 메소드
    private void Move()
    {
        
        if (Input.GetKeyDown(KeyCode.D) && check == true && sheep.transform.position.y > -1 && sheep.transform.position.y < 0 )  // ↓ 방향키를 누를 때
        {

            this.gameObject.transform.Translate(0, -1.9f, 0);
            sucess = 1;
            check = false;
            number = 1;
            
        }
        if (Input.GetKeyDown(KeyCode.E) && check == true && sheep.transform.position.y < -3.5 )  //  방향키를 누를 때
        {
            this.gameObject.transform.Translate(0, 1.9f, 0);
            sucess = 3;
            check = false;
            number = 3;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping && check && sheep.transform.position.y > -3 && sheep.transform.position.y < -1 && sucess != 2 && sheep.transform.position.x > 0 && sheep.transform.position.x < 3.8)
        {
            _isJumping = true;
           // check = false;
            _posY = _transform.position.y;
            number = 2;

            
        }

        if (_isJumping)
        {
            Jump();
        }
        

    }
    private void AddScore()
    {
        if (sheep.transform.position.x < 0.6 && check2 && number==1 )
        {
            ScoreManager.instance.AddScore(1);
            
            check2 = false; 
        }
        if (sheep.transform.position.x < 0.6 && check2 && number == 3)
        {
            ScoreManager.instance.AddScore(1);
            
            check2 = false; 
        }
        if(sheep.transform.position.x > -0.53 && sheep.transform.position.x < 0.5 && sheep.transform.position.y > 1.63 && sheep.transform.position.y < 2 && check2 && number == 2)
        {
            ScoreManager.instance.AddScore(1);
            check2 = false; check3 = true; sucess = 2; 
        }


    }

    void DestorySheep()
    {
          
        if (sheep.transform.position.x < 1 && sheep.transform.position.x > -5 && sucess ==0 && sheep.transform.position.y > -3 && sheep.transform.position.y < -1)
        {
                Destroy(sheep); checkSavePoint();
        }
        if(sheep.transform.position.x > -10 && sheep.transform.position.x <-9)
            Destroy(sheep);
    }
    void Jump()
    {
       
        float height = (_jumpTime * _jumpTime * (-_gravity) / 2) + (_jumpTime * _jumpPower);
        _transform.position = new Vector3(_transform.position.x, _posY + height, _transform.position.z);
        //점프시간을 증가시킨다.
        _jumpTime += Time.deltaTime;

        //처음의 높이 보다 더 내려 갔을때 => 점프전 상태로 복귀한다.
        if (height < 0.0f)
        {
            _isJumping = false;
            _jumpTime = 0.0f;
            _transform.position = new Vector3(_transform.position.x, _posY, _transform.position.z);
        }
    }



    void moveControl()
    {
            float distanceX = -Wolf.moveSpeed * Time.deltaTime;
            //움직일 거리를 계산해줍니다.

            this.gameObject.transform.Translate(distanceX, 0, 0);
    
    }
   void checkColider()
    {
        if(sheep.transform.position.x <2.1 && sheep.transform.position.y > -0.5 && !_isJumping)
        {
            Destroy(sheep);
            checkSavePoint();
        }
        if (sheep.transform.position.x < 0.4 && sheep.transform.position.y < -4 && !_isJumping)
        {
            Destroy(sheep);
            checkSavePoint();
        }

    }
    void checkSavePoint()
    {

        if (save1.gameObject.activeSelf)
            save1.gameObject.SetActive(false);
        else if (!save1.gameObject.activeSelf && save2.gameObject.activeSelf)
            save2.gameObject.SetActive(false);
        else if (!save1.gameObject.activeSelf && !save2.gameObject.activeSelf && save3.gameObject.activeSelf)
        {
            save3.gameObject.SetActive(false);
            Debug.Log("gameover"); gameOver = true;
        }
    }
    

    IEnumerator ChangeImage()
    {
        yield return new WaitForSeconds(0.1f); //0.3초뒤에 실행. 
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/sheep_2");
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/sheep_1");
        StartCoroutine("ChangeImage");


    }

}


