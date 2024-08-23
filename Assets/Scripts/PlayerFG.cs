using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFG : MonoBehaviour
{
    private float m_maxFG;
    private float m_curFG;
    private float m_FGTimer = 30f;// 30초
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

    void Update()
    {        
        downPerTimeFG(); // 초당 줄어드는 배고픔게이지
    }
    private void GetFGITem(float _value) //FG아이템을 먹었을 경우 아이템당 +되는 value값!
    {
        m_curFG += _value;
    }

    private void downPerTimeFG()
    {
        GetFGITem(-Time.deltaTime); // GetFGITem 함수 = 밸류값에 의한 +되는 값과 시간당 줄어드는 걸 + 함!
    }

    public void SetCurFG(float _curFG) //Player 스크립트에 FG값 연동함수
    {
        m_curFG = _curFG;        
    }
    public float GetCurFG() //Switching 스크립트에서 가져다 쓰기 위함
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
