using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Slider = UnityEngine.UIElements.Slider;

public class UI_Manager : MonoBehaviour
{
    public Text ErrorText;
    private GameObject UI_Option;
    private AudioMixer _audioMixer;
    public Slider slider;

    private void Start()
    {
        if(ErrorText!=null) ErrorText.gameObject.SetActive(false);
        UI_Option = GameObject.Find("UI_Option");
        if (UI_Option != null) UI_Option.gameObject.SetActive(false);
    }

    public void Button_FromBeginning()
    {
        // PlayerPrefs로 어디서 시작하는지 변수 설정해줄 것.
        PlayerPrefs.SetInt("Stage", 0);
        PlayerPrefs.SetInt("Level", 0);
        SceneManager.LoadScene("GameScene");
    }
    // public void Button_FromSave()
    // {
    //     // 게임을 종료한 시점을 자동 저장, 그리고 이 버튼 눌렀을 때 그 곳에서 시작하게 하기
    //     // 구현 시간 없음
    // }
    public void Button_FromChapter()
    {
        // 대충 어느 시점부터 게임 시작할건지 결정하게 하기
        // PlayerPrefs.SetInt를 통해 stage와 level을 설정하고, 게임 씬에서 플레이어가 어디에 스폰될지 stage와 level을 통해 정하게 만들기
        // 구현 쉬움
    }
    public void Button_Option()
    {
        UI_Option.gameObject.SetActive(true);
    }
    public void Button_Close()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        clickObject.transform.parent.parent.gameObject.SetActive(false);
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

        StartCoroutine(WaitClose());
    }
    
    IEnumerator WaitClose()
    {
        yield return new WaitForSeconds(2.0f);
        ErrorText.gameObject.SetActive(false);
    }
}