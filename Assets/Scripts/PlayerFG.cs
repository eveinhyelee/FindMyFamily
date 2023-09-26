using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFG : MonoBehaviour
{
    private float m_maxFG;
    private float m_curFG;

    private List<Image> backFG = new List<Image>();
    private List<Image> FG = new List<Image>();    
   
    void Awake()
    {
        Transform trsBack = transform.GetChild(0);
        backFG.AddRange(trsBack.GetComponentsInChildren<Image>());
        backFG.RemoveAt(0);

        Transform trsFG = transform.GetChild(1);
        FG.AddRange(trsFG.GetComponentsInChildren<Image>());
        FG.RemoveAt(0);

        m_curFG = m_maxFG;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCurFG(float _curFG) //Player 스크립트에 연동함수
    {
        _curFG -= Time.deltaTime; //1초당 5씩 감소 하게 만들기
        m_curFG = _curFG;
    }
    //public void SetPlayerFG(float _curFG, float _maxFG)
    //{
    //    _curFG -= 10 * Time.deltaTime );
    //}
    private void checkPlayerFG()         
    {
        
    }
}
