using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFG : MonoBehaviour
{
    private float m_maxFG;
    private float m_curFG;

    private Image[] checkin;
    //private Image image1;
    //private Image image2;
    //private Image image3;
    //private Image image3;
    //private Image image4;
    //private Image image5;    

    private Player player;
    void Awake()
    {
        player = GetComponentInParent<Player>(); //플레이어 스크립트
        //image1 = transform.GetChild(0).GetComponent<Image>();
        //image2 = transform.GetChild(1).GetComponent<Image>();
        //image3 = transform.GetChild(2).GetComponent<Image>();
        //image4 = transform.GetChild(3).GetComponent<Image>();
        //image5 = transform.GetChild(4).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void SetPlayerFG(float _curFG, float _maxFG)
    //{
    //    _curFG -= 10 * Time.deltaTime );
    //}
    private void checkPlayerHP()         
    {
        //20의 배수일때만 오른쪽에서 부터 Destroy하게 하기?
    }
}
