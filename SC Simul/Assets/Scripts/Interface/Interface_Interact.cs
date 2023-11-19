using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface_Interact : MonoBehaviour
{
}

interface IInteractable
{
    // Interactable 인터페이스를 상속받은 오브젝트 중 장비들은 고유의 Stage값과 Level 값 필요. Stage값과 Level값을 플레이어 현재의 Stage 값과 Level 값과 비교해서 작동 여부 판별.
    void Interact(int stage, int level, QuestState _questState);
    string InteractText();
}

interface ICanGet
{
    
}