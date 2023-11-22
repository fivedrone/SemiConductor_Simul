using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator doorAnim;
    private AudioSource doorSound;
    public AudioClip[] soundArr;
    private UI_Manager UIManager;

    private bool IsLock;
    private string inter_Text = "E를 눌러 열기";
    private bool IsDoorOpen = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        UIManager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
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

    public void Interact(int stage, int level)
    {
        if (IsLock)
        {
            UIManager.GetError("감압을 먼저 해주세요.");
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
        StartCoroutine(WaitClose());
    }

    public void Close()
    {
        IsDoorOpen = !IsDoorOpen;
        inter_Text = "E를 눌러 열기";
        doorAnim.SetBool("IsOpen", IsDoorOpen);
        
    }

    public void OpenSound()
    {
        if (soundArr != null)
        {
            doorSound.clip = soundArr[0];
            doorSound.Play();            
        }
    }

    public void CloseSound()
    {
        if (soundArr != null)
        {
            doorSound.clip = soundArr[1];
            doorSound.Play();
        }
    }
}