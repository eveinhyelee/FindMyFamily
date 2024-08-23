using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eItemType
{
    HPItem10,
    HPItem20,
    FGItem10,
    FGItem20,
    HPFGItem10,
    HPFGItem20,
    AddictionFood
}

public class Item : MonoBehaviour
{
    [SerializeField] private eItemType ItemType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
