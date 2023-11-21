using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LocationCheck : MonoBehaviour
{
    private Quest_Manager _questManager;
    public GameObject extraEquip;
    private IInteractable interactable;

    public int stage;
    public int level;

    private void Awake()
    {
        _questManager = GameObject.Find("Player").GetComponent<Quest_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("IsTriggered LocCheck");
        if (other.gameObject.tag == "Player")
        {
            if (_questManager.IsQuestLocation(gameObject))
            {
                Debug.Log("good");
                _questManager.Level += 1;
            }
        
            if(extraEquip != null) interactable = extraEquip.GetComponent<IInteractable>();
            Debug.Log("interactable check");
            if (interactable != null)
            {
                Debug.Log("Good");
                interactable.Interact(0, 0);
            }
            Debug.Log("Bad");
        }
    }
}
