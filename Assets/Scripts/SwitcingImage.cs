using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitcingImage : MonoBehaviour
{
    public enum SwicingType // 분류 하여 돌아가게 하기 위함!
    {
        Hp,
        FG
    }

    [SerializeField] SwicingType swicingType;
    [SerializeField] float switcingValue = 0;
    [SerializeField] float animactiveValue = 0;
    private PlayerHP playerHp;
    private PlayerFG playerFG;
    private Image img;
    private Animator anim;

    private void Awake()
    {
        playerHp = GetComponentInParent<PlayerHP>();
        playerFG = GetComponentInParent<PlayerFG>();
        img = GetComponent<Image>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        switch (swicingType) 
        {
            case SwicingType.Hp:
                HPDestroy();
                HPAnimActive();
                break;
            case SwicingType.FG:
                FGDestroy();
                FGAnimActive();
                break;
        }
    }
    private void HPDestroy() //체력 이미지 삭제
    {
        if (playerHp.GetCurHp() <= switcingValue)
        {
            img.enabled = false;
        }
        else
        {
            img.enabled = true;
        }
    }
    private void HPAnimActive() //체력 에니메이션 활성화
    {
        if (playerHp.GetCurHp() <= animactiveValue && playerHp.GetCurHp() > switcingValue) // ex 70 
        {
            anim.SetBool("lose", true);
        }
        else
        {
            anim.SetBool("lose", false);
        }
    }
    private void FGDestroy() //허기짐 이미지 삭제
    {
        if (playerFG.GetCurFG() <= switcingValue)
        {
            img.enabled = false;
        }
        else
        {
            img.enabled = true;
        }
    }
    private void FGAnimActive() //허기짐 에니메이션 활성화
    {
        if (playerFG.GetCurFG() <= animactiveValue && playerFG.GetCurFG() > switcingValue) // ex 70 
        {
            anim.SetBool("lose", true);
        }
        else
        {
            anim.SetBool("lose", false);
        }

    }
}
