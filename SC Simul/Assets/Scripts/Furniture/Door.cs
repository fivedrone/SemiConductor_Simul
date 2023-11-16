using System.Collections;
using System.Collections.Generic;
using Furniture;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator doorAnim;
    private AudioSource doorSound;
    public AudioClip[] soundArr;
    public GameObject UImanager;

    private bool IsLock;
    private string inter_Text = "E를 눌러 열기";
    private bool IsDoorOpen = false;

    // Start is called before the first frame update
    void Awake()
    {
        doorAnim = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();
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
            Close();
        }
    }

    public void Interact()
    {
        if (IsLock)
        {
            UImanager.GetComponent<UI_Manager>().GetError("감압을 먼저 해주세요.");
            doorSound.clip = soundArr[2];
            doorSound.Play();
            return;
        }
        if (!IsDoorOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    public string InteractText()
    {
        return inter_Text;
    }

    public void Open()
    {
        IsDoorOpen = !IsDoorOpen;
        inter_Text = "E를 눌러 닫기";
        doorAnim.SetBool("IsOpen", IsDoorOpen);
        doorSound.clip = soundArr[0];
        doorSound.Play();
        StartCoroutine(WaitClose());
    }

    public void Close()
    {
        IsDoorOpen = !IsDoorOpen;
        inter_Text = "E를 눌러 열기";
        doorAnim.SetBool("IsOpen", IsDoorOpen);
        doorSound.clip = soundArr[1];
        doorSound.Play();
    }
}