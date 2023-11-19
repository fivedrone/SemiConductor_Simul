using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory_Manager : MonoBehaviour
{
    public Item[] itemArr = new Item[2];
    private Quest_Manager _questManager;

    private void Awake()
    {
        _questManager = GetComponent<Quest_Manager>();
    }

    public int InventoryCheck()
    {
        int index = 0;
        foreach (var item in itemArr)
        {
            if (item == null) return index;
            index++;
        }
        return -1;
    }

    

}
