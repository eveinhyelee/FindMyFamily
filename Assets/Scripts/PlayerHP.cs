using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    private float m_maxHP;
    private float m_curHP;

    private List<Image> imageBack = new List<Image>(); //백이미지 리스트로 관리 하기!
    private List<Image> imageHP = new List<Image>(); //프론트 이미지 리스트로 관리 하기!      
   
    void Awake()
    {  
        Transform trsBack = transform.GetChild(0);
        imageBack.AddRange(trsBack.GetComponentsInChildren<Image>());
        imageBack.RemoveAt(0);

        Transform trsHp = transform.GetChild(1);
        imageHP.AddRange(trsHp.GetComponentsInChildren<Image>());
        imageHP.RemoveAt(0);

        //image0 = transform.Find("PlayerHpBack/PlayerHpBack(1)").; 트랜스폼을 이름으로 찾아주는 방법                             
            
        m_curHP = m_maxHP; // HP초기화
        
    }

    // Update is called once per frame
    void Update()
    {   
        hit();
    }

    public void GetHPITem(float _value) //HP아이템을 먹었을 경우 아이템당 + 되는 value값!
    {
        m_curHP += _value;
    }
    public void SetCurHp(float _curHp) //Player 스크립트에 연동
    {
        m_curHP = _curHp;
    }
    public float GetCurHp() //Switching 스크립트에서 가져다 쓰기 위함
    {
        return m_curHP;
    }

    private void checkPlayerHP()
    {

    }
    private void hit()
    { 
     //다른 강아지나 사람에게 공격받았을때 playerHP 감소     
    }
}

