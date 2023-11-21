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
    public int Stage;
    public int Level;
    private Quest_Manager _questManager;
    
    private void Awake()
    {
        _questManager = GameObject.Find("Player").GetComponent<Quest_Manager>();
        _inventoryManager = GameObject.Find("Player").GetComponent<Inventory_Manager>();
    }

    public void Interact(int stage, int level)
    {
        int index = _inventoryManager.InventoryCheck();
        if (index>=0)
        {
            _inventoryManager.itemArr[index] = DeepCopy();
            if (Stage == _questManager.Stage && Level == _questManager.Level) _questManager.Level += 1;
            Destroy(this);
        }
        
        
    }

    public string InteractText()
    {
        return ItemName + " 습득";
    }

    public Item DeepCopy()
    {
        Item item = ScriptableObject.CreateInstance<Item>();
        item.ItemName = ItemName;
        item.ItemImage = ItemImage;
        item.Prefab = Prefab;
        item._inventoryManager = _inventoryManager;
        item.Stage = Stage;
        item.Level = Level;
        return item;
    }
}
