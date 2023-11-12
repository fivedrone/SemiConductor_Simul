using System.Collections;
using System.Collections.Generic;
using Furniture;
using UnityEngine;

public class ObjectFinder : MonoBehaviour
{
    public Camera getCamera;

    private RaycastHit hit;

    void Update()
    {
        if (Input.GetButtonDown("Interaction"))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        if (Physics.Raycast(getCamera.transform.position, getCamera.transform.forward, out hit, 1000))
        {
            Debug.DrawRay(getCamera.transform.position, getCamera.transform.forward * hit.distance, Color.red, 10.0f);

            Debug.Log(hit.collider.gameObject.name);
            // IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
