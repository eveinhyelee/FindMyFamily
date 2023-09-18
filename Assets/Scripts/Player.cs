using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float fg;
    private Vector2 moveDir; // (X.Y값)
    private float moveSpeed = 1.0f; // 플레이어의 무빙스피드
    [SerializeField] private bool checkGround;

    //리지드바디
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] BoxCollider2D collLeg;

    //rigid.velocity = new Vector2(moveDir.x* moveSpeed, rigid.velocity.y);

    //각각 애니메이션 설정


    //중력설정 + 떨어지는 속도 제한
    private float vertialVelocity = 0f;
    private float gravity = 9.81f;
    private float fallingLimit = -10f;

    //유니티내에 중력 없애고, 직접중력설정 -> 점프기능 & other



    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void Update()
    {
        moving();
        jumping();
        eatingItem();
    }

    private void moving()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal"); //X축 방향키 사용기능 -1 0 1
        //if (moveDir.x == 1)
        //{
            
        //}
        //else if (moveDir.x == -1)
        //{
        //    moveDir.x = 
        //}

    }
    private void jumping()
    {

    }
    private void eatingItem()
    {


    }

}
