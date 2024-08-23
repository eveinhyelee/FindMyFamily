﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class Player : MonoBehaviour
{
    [Header("Player스")]
    [SerializeField] private float m_maxHP;
    [SerializeField] private float m_curHP;
    
    [SerializeField] private float m_maxFG;
    [SerializeField] private float m_curFG;
    
    private Vector2 moveDir; // (X.Y값)
    [SerializeField] private float moveSpeed = 1.0f; // 플레이어의 무빙스피드

    [Header("HP연출")]
    [SerializeField] private PlayerHP playerHP; //플레이어HP스크립트 정의
    [Header("FG연출")]
    [SerializeField] private PlayerFG playerFG; //플레이어FG스크립트 정의


    [SerializeField] BoxCollider2D collLeg; //다리로 땅을 인식하는 콜라이더
    [SerializeField] private bool isGround; //땅에서 있는지

    //각각 애니메이션 설정


    //중력설정 + 떨어지는 속도 제한
    [SerializeField] Rigidbody2D rigid; //중력설정을 위해 리지드 바디를 가져옴
    [SerializeField] private float verticalVelocity = 0f; //수직으로 받고 있는 힘
    private float gravity = 9.81f;  //기본중력
    private float fallingLimit = -10.0f;
    [SerializeField] private float groundRatio = 0.05f; //터널링방지
    private Animator anim;

    [Header("1단점프")]
    private bool isJump = false;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool _doJump = false; //애니메이션
    private bool doJump
    {
        get => _doJump = true;
        set
        {
            anim.SetBool("Jump", value);
            _doJump = value;
        }
    }

    [Header("2단점프")]
    [SerializeField] private bool isNotGround = false; //2단 점프를 할수 있는지?
    [SerializeField] private bool doubleJump = false; //2단 점프 중인지?

    [Header("아이템")]
    [SerializeField] private bool HpItem = false;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        m_curHP = m_maxHP; //최대 HP를 현재 HP로 초기checkHP(); //HP스크립트에서 curHP가져오기 위한 함수!
        checkFG(); //FG스크립트에서 curFG가져오기 위한 함수!
        m_curFG = m_maxFG; //최대 FG를 현재 FG로 초기화
    }
    
    void Update()
    {
        checkGround();
        checkGravity();

        moving();
        jumping();

        doubleJumpSt();
        doAnim();
        eatingItem();

        checkHP(); //HP스크립트에서 curHP가져오기 위한 함수!
        checkFG(); //FG스크립트에서 curFG가져오기 위한 함수!
    }

    private void checkGround() //캐릭터의 발 위치에서 레이케스트를 아래로 쏴서 바닥을 판단하는 함수
    {
        bool beforeGround = isGround;
        isGround = false;

        if (verticalVelocity <= 0f) //수직으로 받고있는힘이 0이하일때만 raycast 발사
        {
            RaycastHit2D hit = Physics2D.BoxCast(collLeg.bounds.center, collLeg.bounds.size,
                0f, Vector2.down, groundRatio, LayerMask.GetMask("Ground"));

            if (hit) // 무언가 데이터가 들어와있다면 isGround는 true;
            {
            

                if (beforeGround == false && doJump == true) //점프 실행 후 에니메이션 꺼줌기능
                {
                    doJump = false;
                }
                isGround = true;
                isNotGround = false; //그라운드일때 false처리
                doubleJump = false;                

            }
        }
        else if (verticalVelocity > 0f) //점프중일때 verticalVelocity값이 +가 됨!
        {
            isNotGround = true;
            doJump = true; // 점프중일때 한번더 에니메이션 실행을 위함
        }
    }
    private void checkGravity()
    {
        if (!isGround) //공중에 떠있음
        {
            verticalVelocity -= gravity * Time.deltaTime; //중력은 -가되면 떨어지는것임 +일경우 떠오름

            if (verticalVelocity < fallingLimit)
            {
                verticalVelocity = fallingLimit;
            }            
            isNotGround = true;
        }

        else // 땅에 닿았을때, 중력값을 꺼내 놓으면 낙하데미지를 넣을수 있음 vertialVelocity를 통해서!
        {
            if (isJump == true) //점프했을때, 바로 점프를 false로 변경해주고(한번만 실행하기 위함?)
            {
                isJump = false;
                doJump = true; //애니메이션 SetBool동작기능
                verticalVelocity = jumpForce;
            }
            else
            {
                verticalVelocity = 0f;//땅에 닿았을 경우
            }
        }
        rigid.velocity = new Vector2(rigid.velocity.x, verticalVelocity);
    }
    private void moving() //좌우방향키설정
    {
        moveDir.x = Input.GetAxisRaw("Horizontal"); //X축 방향키 사용기능 -1 0 1
        rigid.velocity = new Vector2(moveDir.x * moveSpeed, rigid.velocity.y);
        //리지드바디 이용시 Time.deltaTime을 사용할 필요가없다.
    }
    private void doAnim() //방향키에 따라 바라보는 방향설정
    {
        anim.SetInteger("Walk", (int)moveDir.x); //애니메이터내에 파라미터적용

        if (moveDir.x > 0f && transform.localScale.x != -1.0f) //왼쪽을 보고있어 기본설정을 -1로 해둠
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (moveDir.x < 0f && transform.localScale.x != 1.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
    private void jumping()
    {
        if (isGround == false)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
            doubleJump = false;
        }
    }

    private void doubleJumpSt()
    {
        if (!doubleJump && isNotGround && doJump && Input.GetKeyDown(KeyCode.Space))
            //더블 점프가 아닐때, 더블점프 트루가 되는 경우
        {
            doubleJump = true;
            verticalVelocity = jumpForce;
            rigid.velocity = new Vector2(rigid.velocity.x, verticalVelocity);
            doJump = false;
        }              
    }

    
    private void eatingItem()
    {

    }

    private void checkHP()
    {
        playerHP.SetCurHp(m_curHP);
    }
    private void checkFG()
    { 
        playerFG.SetCurFG(m_curFG);
    }
   

    public void TriggerEnter(eHitType _type, Collider2D _coll)
    { 
        switch (_type) 
        {
            case eHitType.HPItem:
                HpItem = true;
                break;
            case eHitType.FGItem:                
                break;
            case eHitType.Sign:                
                break;
            case eHitType.Enemy:                
                break;
            case eHitType.Family:                
                break;

        }
    }
    public void TriggerExit(eHitType _type, Collider2D _coll)
    {
        switch (_type)
        {
            case eHitType.HPItem:
                HpItem = false;
                break;
            case eHitType.FGItem:                
                break;
            case eHitType.Sign:                
                break;
            case eHitType.Enemy:                
                break;
            case eHitType.Family:                
                break;
        }

    }

}
