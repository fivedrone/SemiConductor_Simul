using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public Animator buttonAnimator;
    public PanelColorChange panelColorChange;

    private void Start()
    {
        buttonAnimator = GetComponent<Animator>();
    }

    /*private void OnMouseDown()
    {
        StartCoroutine(AnimateButtonAndPanel());
    }
    private IEnumerator AnimateButtonAndPanel()
    {
        buttonAnimator.SetTrigger("button");

        // 기다리고자 하는 버튼 애니메이션의 길이
        yield return new WaitForSeconds(buttonAnimator.GetCurrentAnimatorStateInfo(0).length);

        panelColorChange.StartColorChangeAnimation();
    }*/
    public void Onclick()
    {
        buttonAnimator.SetTrigger("On");
    }
   /* private void OnMouseDown()
    {
        // 버튼의 애니메이션 트리거를 활성화하여 색 변화 애니메이션을 시작
     

        // 패널의 색 변화 애니메이션 시작
        panelColorChange.StartColorChangeAnimation();
    }*/

}