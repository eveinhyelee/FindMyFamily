using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float fg;
    private Vector2 moveDir; // (X.Y��)
    private float moveSpeed = 1.0f; // �÷��̾��� �������ǵ�
    [SerializeField] private bool checkGround;

    //������ٵ�
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] BoxCollider2D collLeg;

    //rigid.velocity = new Vector2(moveDir.x* moveSpeed, rigid.velocity.y);

    //���� �ִϸ��̼� ����


    //�߷¼��� + �������� �ӵ� ����
    private float vertialVelocity = 0f;
    private float gravity = 9.81f;
    private float fallingLimit = -10f;

    //����Ƽ���� �߷� ���ְ�, �����߷¼��� -> ������� & other



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
        moveDir.x = Input.GetAxisRaw("Horizontal"); //X�� ����Ű ����� -1 0 1
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
