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
         // 패널의 애니메이션 트리거를 활성화하여 색 변화 애니메이션을 시작
         animator.SetTrigger("button");
         StartCoroutine(WaitForPanelAnimation());
     }
     private IEnumerator WaitForPanelAnimation()
     {
         // 기다리고자 하는 패널 애니메이션의 길이
         yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

         // 여기에 패널 애니메이션이 끝난 후 실행하고자 하는 코드 추가
     }*/
    /*public void StartColorChangeAnimation()
    {
        // 패널의 애니메이션 트리거를 활성화하여 색 변화 애니메이션을 시작
        animator.SetTrigger("button");

        // 추가로 다른 동작을 수행하려면 여기에 로직을 추가할 수 있습니다.
    }*/
    public void StartColorChangeAnimation()
    {
        // 패널의 애니메이션 트리거를 활성화하여 색 변화 애니메이션을 시작
        animator.SetTrigger("colorchange");

        // 버튼 애니메이션의 길이를 파악하여 코루틴으로 기다린 후 패널 애니메이션 시작
        float buttonAnimationLength = GetAnimationLength("button_hot"); // 애니메이션 클립의 이름으로 변경
        StartCoroutine(StartPanelAnimationAfterDelay(buttonAnimationLength));
    }

    IEnumerator StartPanelAnimationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 패널 애니메이션 시작
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

