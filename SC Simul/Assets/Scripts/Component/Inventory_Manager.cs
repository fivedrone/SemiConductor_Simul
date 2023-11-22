using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory_Manager : MonoBehaviour
{
    // 인벤토리 함수. 애니메이션 중간 중간에 인벤토리의 아이템을 적절히 사용할 것을 기획했으나, 작업량이 너무 많아져 중단.
    public Item[] itemArr = new Item[3];
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
