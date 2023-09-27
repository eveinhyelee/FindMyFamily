using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFG : MonoBehaviour
{
    private float m_maxFG;
    private float m_curFG;
    private float m_FGTimer = 30f;// 30�ʴ�
    private float FGTime = 10f;

    private List<Image> backFG = new List<Image>();
    private List<Image> FG = new List<Image>();

    private Player player;

    void Awake()
    {
        Transform trsBack = transform.GetChild(0);
        backFG.AddRange(trsBack.GetComponentsInChildren<Image>());
        backFG.RemoveAt(0);

        Transform trsFG = transform.GetChild(1);
        FG.AddRange(trsFG.GetComponentsInChildren<Image>());
        FG.RemoveAt(0);

        m_curFG = m_maxFG;

        player = FindAnyObjectByType<Player>();
        if (player == null)
        {
            Debug.Log("�÷��̾ �������� ����");
        }
    }

    // Update is called once per frame
    void Update()
    {        
        downPerTimeFG(); // �ʴ� �پ��� ����İ�����
    }
    private void GetFGITem(float _value) //FG�������� �Ծ��� ��� �����۴� +�Ǵ� value��!
    {
        m_curFG += _value;
    }

    private void downPerTimeFG()
    {
        GetFGITem(-Time.deltaTime); // GetFGITem �Լ� = ������� ���� +�Ǵ� ���� �ð��� �پ��� �� + ��!
    }

    public void SetCurFG(float _curFG) //Player ��ũ��Ʈ�� FG�� �����Լ�
    {
        m_curFG = _curFG;        
    }
    public float GetCurFG() //Switching ��ũ��Ʈ���� ������ ���� ����
    {
        return m_curFG;
    }
    
    
    //public void SetPlayerFG(float _curFG, float _maxFG)
    //{
    //    _curFG -= 10 * Time.deltaTime );
    //}
    private void checkPlayerFG()         
    {
        
    }
}
