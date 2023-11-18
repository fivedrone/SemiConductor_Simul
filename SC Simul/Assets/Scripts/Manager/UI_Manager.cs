using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Text ErrorText;
    public void Button_FromBeginning()
    {
        // PlayerPrefs로 어디서 시작하는지 변수 설정해줄 것.
        
        SceneManager.LoadScene("GameScene");
    }
    public void Button_FromSave()
    {
        // 게임을 종료한 시점을 자동 저장, 그리고 이 버튼 눌렀을 때 그 곳에서 시작하게 하기
    }
    public void Button_FromChapter()
    {
        // 대충 어느 시점부터 게임 시작할건지 결정하게 하기
    }
    public void Button_Option()
    {
        // 옵션 UI 여는 버튼
    }
    public void Button_Close()
    {
        // 이 버튼이 위치한 empty 오브젝트를 찾고 그것을 비활성화하는 버튼
    }
    public void Button_Exit()
    {
        // 종료
        Application.Quit();
    }

    public void GetError(string error)
    {
        ErrorText.text = error;
        ErrorText.gameObject.SetActive(true);

    }
    
    IEnumerator WaitClose()
    {
        yield return new WaitForSeconds(2.0f);
        ErrorText.gameObject.SetActive(false);
    }
}