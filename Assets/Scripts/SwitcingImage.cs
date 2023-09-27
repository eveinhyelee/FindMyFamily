using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitcingImage : MonoBehaviour
{
    public enum SwicingType // �з� �Ͽ� ���ư��� �ϱ� ����!
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
    private void HPDestroy() //ü�� �̹��� ����
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
    private void HPAnimActive() //ü�� ���ϸ��̼� Ȱ��ȭ
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
    private void FGDestroy() //����� �̹��� ����
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
    private void FGAnimActive() //����� ���ϸ��̼� Ȱ��ȭ
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
