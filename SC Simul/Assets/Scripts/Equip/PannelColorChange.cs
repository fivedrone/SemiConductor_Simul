using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelColorChange : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    /* public void StartColorChangeAnimation()
     {
         // �г��� �ִϸ��̼� Ʈ���Ÿ� Ȱ��ȭ�Ͽ� �� ��ȭ �ִϸ��̼��� ����
         animator.SetTrigger("button");
         StartCoroutine(WaitForPanelAnimation());
     }
     private IEnumerator WaitForPanelAnimation()
     {
         // ��ٸ����� �ϴ� �г� �ִϸ��̼��� ����
         yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

         // ���⿡ �г� �ִϸ��̼��� ���� �� �����ϰ��� �ϴ� �ڵ� �߰�
     }*/
    /*public void StartColorChangeAnimation()
    {
        // �г��� �ִϸ��̼� Ʈ���Ÿ� Ȱ��ȭ�Ͽ� �� ��ȭ �ִϸ��̼��� ����
        animator.SetTrigger("button");

        // �߰��� �ٸ� ������ �����Ϸ��� ���⿡ ������ �߰��� �� �ֽ��ϴ�.
    }*/
    public void StartColorChangeAnimation()
    {
        // �г��� �ִϸ��̼� Ʈ���Ÿ� Ȱ��ȭ�Ͽ� �� ��ȭ �ִϸ��̼��� ����
        animator.SetTrigger("colorchange");

        // ��ư �ִϸ��̼��� ���̸� �ľ��Ͽ� �ڷ�ƾ���� ��ٸ� �� �г� �ִϸ��̼� ����
        float buttonAnimationLength = GetAnimationLength("button_hot"); // �ִϸ��̼� Ŭ���� �̸����� ����
        StartCoroutine(StartPanelAnimationAfterDelay(buttonAnimationLength));
    }

    IEnumerator StartPanelAnimationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // �г� �ִϸ��̼� ����
        animator.GetBool("colorchange");
    }

    float GetAnimationLength(string Button_hot)
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (var clip in clips)
        {
            if (clip.name == Button_hot)
            {
                return clip.length;
            }
        }
        return 0f;
    }


}

