using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{   
    private float playerHP = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GetComponentInParent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP > 0)
        {
            
        }
        else if (playerHP <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
