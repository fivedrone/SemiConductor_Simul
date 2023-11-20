using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour, IInteractable
{
    private Animator equipAnim;
    public int stage;
    public int level;
    // private AudioSource equipSound;
    // public AudioClip[] soundArr;
    private UI_Manager UIManager;
    private bool isActivated = false;

    public string interact_Text; // 에디터에서 결정할 것.
    
    // Start is called before the first frame update
    private void Awake()
    {
        UIManager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        // equipSound = GetComponent<AudioSource>();
    }
    public void Interact(int pStage, int pLevel, QuestState questState)
    {
        Debug.Log("Equipment Interact");
        if (isActivated)
        {
            return;
        }
        Debug.Log(pStage.ToString() + " " + pLevel.ToString());
        Debug.Log(stage.ToString() + " " + level.ToString());
        if (stage != pStage || level != pLevel)
        {
            Debug.Log("Equipment Error");
            UIManager.GetError("지금 해야 할 작업이 아닙니다.");
            return;
        }
        
        equipAnim.SetBool("isActivated", true);
        Debug.Log(interact_Text);
        isActivated = true;
        
        
    }
    
    public string InteractText()
    {
        return interact_Text;
    }
}
