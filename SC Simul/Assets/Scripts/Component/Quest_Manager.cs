using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum QuestState { Location, InteractEquip, GetItem }
public class Quest_Manager : MonoBehaviour
{
    public StageData[] QuestArr;
    private UI_Manager _uiManager;
    private MarkerManager _markerManager;
    public Text Stage_UI;
    public Text Level_UI;
    private GameObject Player;
    public int prevStage = 0;
    public int prevLevel = 0;
    public int Stage { get; set; } = 0; // 공정 단계 구분.
    public int Level { get; set; } = 0; // 공정 단계 중 소단계 구분. StageText가 index0인거 기억하기. Level이 바뀔때는 그냥 Level+1하기
    public QuestState questState;
    public GameObject _markerInstance;

    
    // Start is called before the first frame update
    void Awake()
    {
        _uiManager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        _markerManager = GameObject.Find("Marker_Manager").GetComponent<MarkerManager>();
        Stage = PlayerPrefs.GetInt("Stage");
        Level = PlayerPrefs.GetInt("Level");
        UpdateQuestUI();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public bool IsQuestLocation(GameObject locCheck)
    {
        // locationcheck 프리팹을 위한 함수. locationcheck 프리팹이 자신을 반환하면
        // questmanager가 가지고 있는 stage 정보의 questobject와 비교해 bool값으로 돌려줌.
        return QuestArr[Stage].stageArr[Level].questObject.Equals(locCheck);
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 Stage값과 매니저가 가지고있는 prevStage 값이 다르다면 현재 값으로 prevstage를 초기화해주고, UI 업데이트 요청.
        if (Stage != prevStage || Level != prevLevel)
        {
            // 만약 현재 level의 이름이 Finish라면 다음 스테이지로 stage와 level을 변경.
            if (QuestArr[Stage].stageArr[Level].name.Equals("Finish"))
            {
                Debug.Log("P " + prevStage.ToString() + " " + prevLevel.ToString());
                Debug.Log("C " + Stage.ToString() + " " + Level.ToString());
                Stage += 1;
                Level = 0;
            }
            prevStage = Stage;
            prevLevel = Level;
            UpdateQuestUI();
        }

        // 플레이어 앞의 화살표 마커가 현재 가야할 곳을 알려줌.
        if(QuestArr[Stage].stageArr[Level].questObject.transform.position != null) _markerInstance.transform.LookAt(QuestArr[Stage].stageArr[Level].questObject.transform.position);
    }
    
    void UpdateQuestUI()
    {
        // 현재 stage와 level에 맞게 UI 조정.
        Stage_UI.text = QuestArr[Stage].name;
        Level_UI.text = QuestArr[Stage].stageArr[Level].name;
        // 기능 추가하려다 중단
        questState = QuestArr[Stage].stageArr[Level]._questState;
    }
}

[System.Serializable]
public class StageData
{
    public string name;
    public LevelData[] stageArr;
}

[System.Serializable]
public class LevelData
{
    public string name;
    public GameObject questObject;
    public QuestState _questState;
}