using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LocationCheck : MonoBehaviour
{
    private Quest_Manager _questManager;

    private void Awake()
    {
        _questManager = GameObject.Find("Player").GetComponent<Quest_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_questManager.IsQuestLocation(gameObject))
        {
            _questManager.Level += 1;
        }
    }
}
