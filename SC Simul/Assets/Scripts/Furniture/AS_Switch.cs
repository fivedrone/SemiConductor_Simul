using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_Switch : MonoBehaviour, IInteractable
{
    public Door Door1;
    public Door Door2;
    
    public AS[] arr_AS;
    private bool isAct = false;
    
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(12.0f);
        
        foreach (AS air in arr_AS)
        {
            air.GetWashPlace().Stop();
            Debug.Log("작동 중..");
        }
        
        Debug.Log("AS 재생 종료, 문 잠금 해제.");
        Door1.OpenLock();
        Door2.OpenLock();
        isAct = false;
    }
    
    private void Awake()
    {
        Door2.SetLock();
    }
    
    public void Interact()
    {
        
    }


    public void Interact(int stage, int level)
    {
        if (isAct) return;
        isAct = true;
        Door1.Close();
        Door1.SetLock();
        Door2.SetLock();
    
        foreach (AS air in arr_AS)
        {
            air.GetWashPlace().Play();
            Debug.Log("AS 작동");
        }
    
        StartCoroutine(WaitForIt());
    }

    public string InteractText()
    {
        return "";
    }
}