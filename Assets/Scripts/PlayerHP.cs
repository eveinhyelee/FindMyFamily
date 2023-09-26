using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    private float m_maxHP;
    private float m_curHP;

    private Image image1;
    private Image image2;
    private Image image3;
    private Image image4;
    private Image image5;
        
    private Player player;
    private Animator anim;

    private int[] arrayBlingHP = new int[5] { 90, 70, 50, 30, 10 };
    private int[] arrayDestroyHP = new int[5] { 80, 60, 40, 20, 0 };
        
    void Awake()
    {
        player = GetComponentInParent<Player>(); //플레이어 스크립트
                        
        image1 = transform.GetChild(0).GetComponent<Image>();
        image2 = transform.GetChild(1).GetComponent<Image>();
        image3 = transform.GetChild(2).GetComponent<Image>();
        image4 = transform.GetChild(3).GetComponent<Image>();
        image5 = transform.GetChild(4).GetComponent<Image>();               

        anim = GetComponent<Animator>();
        
        m_curHP = m_maxHP; // HP초기화
        
    }

    // Update is called once per frame
    void Update()
    {
        setArrayHP();
        checkPlayerHP();
        hit();
    }
    
    private void setArrayHP()
    {   
        //빛이 나는 넘버를 순서대로 위 배열되어있는 순서대로 애니메이션이 깜빡이게 하기
        int count = arrayBlingHP.Length; 
        for (int iNum = 0; iNum < count; iNum++)
        {
            arrayBlingHP[iNum] = (int)m_curHP;
            anim.SetInteger("lose", (int)m_curHP);
        }
        

        int count2 = arrayDestroyHP.Length;
        for (int iNum = 0; iNum < count2; iNum++)
        {
            arrayDestroyHP[iNum] = (int)m_curHP;
            // ?? setActive(false);
            // 오른쪽 부터 순서대로 삭제? (어레이 0번째 부터 삭제)
        }
    }

    private void checkPlayerHP()
    {

        if (m_curHP == 100)
        {
            //전체 HP표시
        }
        else if (m_curHP == 90)
        {
            image5.color = Color.blue;
        }
        else if (m_curHP == 80)
        {
            Destroy(image5);
        }
        else if (m_curHP == 70)
        {
            image4.color = Color.blue;
        }
        else if (m_curHP == 60)
        {
            Destroy(image4);
        }
        else if (m_curHP == 50)
        {
            image3.color = Color.blue;
        }
        else if (m_curHP == 40)
        {
            Destroy(image3);
        }
        else if (m_curHP == 30)
        {
            image2.color = Color.blue;
        }
        else if (m_curHP == 20)
        {
            Destroy(image2);
        }
        else if (m_curHP == 10)
        {
            image1.color = Color.blue;
        }
        else if (m_curHP == 0)
        {
            Destroy(image1);
        }


    }
    private void hit()
    { 
     //다른 강아지나 사람에게 공격받았을때 playerHP 감소     
    }
}

