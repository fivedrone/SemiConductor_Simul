using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectFinder : MonoBehaviour
{
    public Camera getCamera;
    private RaycastHit _hit;
    public Text howInteract;
    private Quest_Manager _questManager;

    private void Awake()
    {
        _questManager = GetComponent<Quest_Manager>();
    }

    void Update()
    {
        if (Physics.Raycast(getCamera.transform.position, getCamera.transform.forward, out _hit, 3))
        {
            IInteractable interactable = _hit.collider.GetComponentInParent<IInteractable>();
            if (interactable != null)
            {
                howInteract.text = interactable.InteractText();
            }
            else
            {
                howInteract.text = "";
            }
        }
        
        
        if (Input.GetButtonDown("Interaction"))
        {
            Debug.DrawRay(getCamera.transform.position, getCamera.transform.forward * _hit.distance, Color.red, 5.0f);
            TryInteract(_hit);
        }
    }

    void TryInteract(RaycastHit _rhit)   
    {
        IInteractable interactable = _rhit.collider.GetComponentInParent<IInteractable>();
        // Debug.Log(_rhit.collider.gameObject.name);
        // Debug.Log("2");
        if (interactable != null)
        {
            // Debug.Log(_questManager.Stage);
            // Debug.Log(_questManager.Level);
            interactable.Interact(_questManager.Stage, _questManager.Level, _questManager.questState);
        }
    }
}