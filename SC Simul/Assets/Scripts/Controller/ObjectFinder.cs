using System.Collections;
using System.Collections.Generic;
using Furniture;
using UnityEngine;
using UnityEngine.UI;

public class ObjectFinder : MonoBehaviour
{
    public Camera getCamera;
    private RaycastHit hit;
    public Text howInteract;

    void Update()
    {
        if (Physics.Raycast(getCamera.transform.position, getCamera.transform.forward, out hit, 3))
        {
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();
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
            Debug.DrawRay(getCamera.transform.position, getCamera.transform.forward * hit.distance, Color.red, 5.0f);
            TryInteract(hit);
        }
    }

    void TryInteract(RaycastHit rhit)   
    {
        IInteractable interactable = rhit.collider.GetComponentInParent<IInteractable>();
        if (interactable != null)
        {
            interactable.Interact();
        }
    }
}
