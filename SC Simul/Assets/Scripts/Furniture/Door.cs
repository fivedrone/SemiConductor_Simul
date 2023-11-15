using System.Collections;
using System.Collections.Generic;
using Furniture;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator doorAnim;
    public GameObject UImanager;

    private bool IsLock;
    private string inter_Text = "E를 눌러 열기";
    private bool IsDoorOpen = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        doorAnim = GetComponent<Animator>();
    }

    public void SetLock()
    {
        IsLock = true;
    }

    public void OpenLock()
    {
        IsLock = false;
    }

    IEnumerator WaitClose()
    {
        yield return new WaitForSeconds(4.0f);
        if (IsDoorOpen == true)
        {
            IsDoorOpen = !IsDoorOpen;
            inter_Text = "E를 눌러 열기";
            doorAnim.SetBool("IsOpen", IsDoorOpen);
        }
    }

    public void Interact()
    {
        if (IsLock)
        {
            UImanager.GetComponent<UI_Manager>().GetError("감압을 먼저 해주세요.");
            return;
        }
        IsDoorOpen = !IsDoorOpen;
        if (IsDoorOpen)
        {
            inter_Text = "E를 눌러 닫기";
        }
        else
        {
            inter_Text = "E를 눌러 열기";
        }
        doorAnim.SetBool("IsOpen", IsDoorOpen);
        StartCoroutine(WaitClose());
    }

    public string InteractText()
    {
        return inter_Text;
    }
}
