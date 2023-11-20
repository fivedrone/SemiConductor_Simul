using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LocationCheck : MonoBehaviour
{
    private Quest_Manager _questManager;
    public GameObject extraEquip;

    public int stage;
    public int level;

    private void Awake()
    {
        _questManager = GameObject.Find("Player").GetComponent<Quest_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("IsTriggered LocCheck");
        if (_questManager.IsQuestLocation(gameObject))
        {
            Debug.Log("good");
            _questManager.Level += 1;
        }
        
        IInteractable interactable = extraEquip.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.Interact(0, 0, _questManager.questState);
        }
    }
}
