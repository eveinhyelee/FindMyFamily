using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eHitType
{ 
    HPItem,
    FGItem,
    Sign,
    Enemy,
    Family
}
public class HItBox : MonoBehaviour
{
    [SerializeField] private eHitType hitType;
    private Player player; //�θ��� ��ũ��Ʈ�� �־��ֱ����ؼ� ������

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.TriggerEnter(hitType, collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.TriggerExit(hitType, collision);
    }
}
