using System.Collections;
using System.Collections.Generic;
using Furniture;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator doorAnim;

    private bool IsDoorOpen = false;
    // Start is called before the first frame update
    void Awake()
    {
        doorAnim = GetComponent<Animator>();
    }

    IEnumerator WaitClose()
    {
        yield return new WaitForSeconds(4.0f);
        if (IsDoorOpen == true)
        {
            IsDoorOpen = !IsDoorOpen;
            doorAnim.SetBool("IsOpen", IsDoorOpen);
        }
    }

    public void Interact()
    {
        IsDoorOpen = !IsDoorOpen;
        doorAnim.SetBool("IsOpen", IsDoorOpen);
        StartCoroutine(WaitClose());
    }
}
