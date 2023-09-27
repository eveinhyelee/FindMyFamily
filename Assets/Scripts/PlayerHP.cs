using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    private float m_maxHP;
    private float m_curHP;

    private List<Image> imageBack = new List<Image>(); //���̹��� ����Ʈ�� ���� �ϱ�!
    private List<Image> imageHP = new List<Image>(); //����Ʈ �̹��� ����Ʈ�� ���� �ϱ�!      
   
    void Awake()
    {  
        Transform trsBack = transform.GetChild(0);
        imageBack.AddRange(trsBack.GetComponentsInChildren<Image>());
        imageBack.RemoveAt(0);

        Transform trsHp = transform.GetChild(1);
        imageHP.AddRange(trsHp.GetComponentsInChildren<Image>());
        imageHP.RemoveAt(0);

        //image0 = transform.Find("PlayerHpBack/PlayerHpBack(1)").; Ʈ�������� �̸����� ã���ִ� ���                             
            
        m_curHP = m_maxHP; // HP�ʱ�ȭ
        
    }

    // Update is called once per frame
    void Update()
    {   
        hit();
    }

    public void GetHPITem(float _value) //HP�������� �Ծ��� ��� �����۴� + �Ǵ� value��!
    {
        m_curHP += _value;
    }
    public void SetCurHp(float _curHp) //Player ��ũ��Ʈ�� ����
    {
        m_curHP = _curHp;
    }
    public float GetCurHp() //Switching ��ũ��Ʈ���� ������ ���� ����
    {
        return m_curHP;
    }

    private void checkPlayerHP()
    {

    }
    private void hit()
    { 
     //�ٸ� �������� ������� ���ݹ޾����� playerHP ����     
    }
}

