using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float fg;
    private Vector2 moveDir; // (X.Y��)
    [SerializeField] private float moveSpeed = 1.0f; // �÷��̾��� �������ǵ�


    [SerializeField] BoxCollider2D collLeg; //�ٸ��� ���� �ν��ϴ� �ݶ��̴�
    [SerializeField] private bool isGround;//������ �ִ���

    //���� �ִϸ��̼� ����


    //�߷¼��� + �������� �ӵ� ����
    [SerializeField] Rigidbody2D rigid; //�߷¼����� ���� ������ �ٵ� ������
    private float verticalVelocity = 0f; //�������� �ް� �ִ� ��
    private float gravity = 9.81f;  //�⺻�߷�
    private float fallingLimit = -10.0f;
    [SerializeField] private float groundRatio = 1.0f;//�ͳθ�����
    private Animator anim;

    private bool isJump = false;
    [SerializeField] private float jumpForce = 5f;
    private bool _doJump = false; //�ִϸ��̼�
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

    private void checkGround() //ĳ������ �� ��ġ���� �����ɽ�Ʈ�� �Ʒ��� ���� �ٴ��� �Ǵ��ϴ� �Լ�
    {
        bool beforeground = isGround;
        isGround = false;

        if (verticalVelocity <= 0f) //�������� �ް��ִ����� 0�����϶��� raycast �߻�
        {
            RaycastHit2D hit = Physics2D.BoxCast(collLeg.bounds.center, collLeg.bounds.size,
                0f, Vector2.down, groundRatio, LayerMask.GetMask("Ground"));

            if (hit) // ���� �����Ͱ� �����ִٸ� isGround�� true;
            {
                if (doJump == true) //���� ���� �� ���ϸ��̼� ���ܱ��
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
        if (isGround == false) //���߿� ������
        {
            verticalVelocity -= gravity * Time.deltaTime; //�߷��� -���Ǹ� �������°��� +�ϰ�� ������
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
        else // �߷°��� ���� ������ ���ϵ������� ������ ���� vertialVelocity�� ���ؼ�!
        {
            if (isJump == true)
            {
                isJump = false;
                doJump = true; // ?
                verticalVelocity = jumpForce;
            }
            else
            {
                verticalVelocity = 0f;//���� ����� ���
            }
        }
        rigid.velocity = new Vector2(rigid.velocity.x, verticalVelocity);
    }
    private void moving() //�¿����Ű����
    {
        moveDir.x = Input.GetAxisRaw("Horizontal"); //X�� ����Ű ����� -1 0 1
        rigid.velocity = new Vector2(moveDir.x * moveSpeed, rigid.velocity.y);
        //moveDir.y = rigid.velocity.y;
        //rigid.velocity = moveDir * moveSpeed;//������ٵ� �̿�� Time.deltaTime�� ����� �ʿ䰡����.

    }
    private void doAnim() //����Ű�� ���� �ٶ󺸴� ���⼳��
    {
        anim.SetInteger("Walk", (int)moveDir.x); //�ִϸ����ͳ��� �Ķ��������

        if (moveDir.x > 0f && transform.localScale.x != -1.0f) //������ �����־� �⺻������ -1�� �ص�
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
        //    verticalVelocity = 0f;//���� ����� ���
        //}   

    }
    private void eatingItem()
    {


    }

}
