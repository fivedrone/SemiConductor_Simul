using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject, IInteractable
{
    public string ItemName;
    public Sprite ItemImage;
    public GameObject Prefab;
    private Inventory_Manager _inventoryManager;


    private void Awake()
    {
        _inventoryManager = GameObject.Find("Player").GetComponent<Inventory_Manager>();
    }

    public void Interact(int stage, int level, QuestState _questState)
    {
        int index = _inventoryManager.InventoryCheck();
        if (index>=0)
        {
            _inventoryManager.itemArr[index] = this;
            Destroy(this);
        }
        
        
    }

    public string InteractText()
    {
        return ItemName + " 습득";
    }
}
