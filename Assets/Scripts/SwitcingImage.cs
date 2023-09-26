using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitcingImage : MonoBehaviour
{
    [SerializeField] float switcingValue = 0;
    [SerializeField] float animactiveValue = 0;
    private PlayerHP playerHp;
    private Image img;
    private Animator anim;    

    private void Awake()
    {
        playerHp = GetComponentInParent<PlayerHP>();
        img = GetComponent<Image>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        HPDestroy();
        AnimActive();
    }
    private void HPDestroy()
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
    private void AnimActive()
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
}
