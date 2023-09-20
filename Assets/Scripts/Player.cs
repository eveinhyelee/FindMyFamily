using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float fg;
    private Vector2 moveDir; // (X.Y값)
    [SerializeField] private float moveSpeed = 1.0f; // 플레이어의 무빙스피드


    [SerializeField] BoxCollider2D collLeg; //다리로 땅을 인식하는 콜라이더
    [SerializeField] private bool isGround;//땅에서 있는지

    //각각 애니메이션 설정


    //중력설정 + 떨어지는 속도 제한
    [SerializeField] Rigidbody2D rigid; //중력설정을 위해 리지드 바디를 가져옴
    private float verticalVelocity = 0f; //수직으로 받고 있는 힘
    private float gravity = 9.81f;  //기본중력
    private float fallingLimit = -10.0f;
    [SerializeField] private float groundRatio = 1.0f;//터널링방지
    private Animator anim;

    private bool isJump = false;
    [SerializeField] private float jumpForce = 5f;
    private bool _doJump = false; //애니메이션
    private bool doJump
    {
        get => _doJump = true;
        set
        {
            anim.SetBool("Jump", value);
            _doJump = value;
        }
    }



    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        checkGround();
        checkGravity();

        moving();
        jumping();
        doAnim();
        eatingItem();
    }

    private void checkGround() //캐릭터의 발 위치에서 레이케스트를 아래로 쏴서 바닥을 판단하는 함수
    {
        bool beforeground = isGround;
        isGround = false;

        if (verticalVelocity <= 0f) //수직으로 받고있는힘이 0이하일때만 raycast 발사
        {
            RaycastHit2D hit = Physics2D.BoxCast(collLeg.bounds.center, collLeg.bounds.size,
                0f, Vector2.down, groundRatio, LayerMask.GetMask("Ground"));

            if (hit) // 무언가 데이터가 들어와있다면 isGround는 true;
            {
                if (doJump == true) //점프 실행 후 에니메이션 꺼줌기능
                {

                    if (isJump == true)
                    {
                        dobleJumpst();
                    }
                    else
                    {
                        doJump = false;
                    }

                }
                else if (beforeground == false && doJump == true)
                {
                    doJump = false;
                }
            isGround = true;
            }
        }
    }
    private void checkGravity()
    {
        if (isGround == false) //공중에 떠있음
        {
            verticalVelocity -= gravity * Time.deltaTime; //중력은 -가되면 떨어지는것임 +일경우 떠오름
            if (verticalVelocity < fallingLimit)
            {
                verticalVelocity = fallingLimit;
            }
            else if (isJump == true)
            {
                doJump = true;                
                verticalVelocity = 0f;
                
            }
        }
        else // 중력값을 꺼내 놓으면 낙하데미지를 넣을수 있음 vertialVelocity를 통해서!
        {
            if (isJump == true)
            {
                isJump = false;
                doJump = true; // ?
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
        //moveDir.y = rigid.velocity.y;
        //rigid.velocity = moveDir * moveSpeed;//리지드바디 이용시 Time.deltaTime을 사용할 필요가없다.

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
        }
    }
    private void dobleJumpst()
    {
        if (isJump == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
            verticalVelocity = jumpForce;
            rigid.AddForce(Vector2.up * verticalVelocity);
            doJump = false;
        }
        //else if (isGround == true)
        //{
        //    verticalVelocity = 0f;//땅에 닿았을 경우
        //}   

    }
    private void eatingItem()
    {


    }

}
