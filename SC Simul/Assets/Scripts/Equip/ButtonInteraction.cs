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

        // ��ٸ����� �ϴ� ��ư �ִϸ��̼��� ����
        yield return new WaitForSeconds(buttonAnimator.GetCurrentAnimatorStateInfo(0).length);

        panelColorChange.StartColorChangeAnimation();
    }*/
    public void Onclick()
    {
        buttonAnimator.SetTrigger("On");
    }
   /* private void OnMouseDown()
    {
        // ��ư�� �ִϸ��̼� Ʈ���Ÿ� Ȱ��ȭ�Ͽ� �� ��ȭ �ִϸ��̼��� ����
     

        // �г��� �� ��ȭ �ִϸ��̼� ����
        panelColorChange.StartColorChangeAnimation();
    }*/

}