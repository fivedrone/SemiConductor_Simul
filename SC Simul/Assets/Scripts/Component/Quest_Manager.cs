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
    private Text prevLevel_UI; // 여유 되면 구현
    private Text currentLevel_UI;
    private Text nextLevel_UI; // 여유 되면 구현
    private GameObject Player;
    private int prevStage = 0;
    private int prevLevel = 0;
    public int Stage { get; set; } = 0; // 공정 단계 구분. Stage가 바뀔 때 Level은 자동으로 1로 설정하기.
    public int Level { get; set; } = 0; // 공정 단계 중 소단계 구분. StageText가 index0인거 기억하기. Level이 바뀔때는 그냥 Level+1하기
    public QuestState questState;

    
    // Start is called before the first frame update
    void Awake()
    {
        _uiManager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        _markerManager = GameObject.Find("Marker_Manager").GetComponent<MarkerManager>();
        prevLevel_UI = Stage_UI.GetComponentsInChildren<Text>()[0];
        currentLevel_UI = Stage_UI.GetComponentsInChildren<Text>()[1];
        nextLevel_UI = Stage_UI.GetComponentsInChildren<Text>()[2];
        Stage = PlayerPrefs.GetInt("Stage");
        Level = PlayerPrefs.GetInt("Level");
        UpdateQuestUI();
    }

    public bool IsQuestLocation(GameObject locCheck)
    {
        return QuestArr[Stage].stageArr[Level].questObject.Equals(locCheck);
    }

    // Update is called once per frame
    void Update()
    {
        if (Stage != prevStage || Level != prevLevel)
        {
            if (QuestArr[Stage].stageArr[Level] == null)
            {
                Stage += 1;
                Level = 0;
            }
            prevStage = Stage;
            prevLevel = Level;
            UpdateQuestUI();
        }

        // if (_markerManager._markerInstance != null)
        // {
        //     _markerManager.UpdateMarker(QuestArr[Stage].stageArr[Level].questObject.transform.position);
        //     Debug.Log("MarkerUpdate");
        // }
    }
    
    void UpdateQuestUI()
    {
        Stage_UI.text = QuestArr[Stage].name;
        currentLevel_UI.text = QuestArr[Stage].stageArr[Level].name;
        questState = QuestArr[Stage].stageArr[Level]._questState;
        // MarkQuestLocation();
        //  마지막에 여유 되면 prev next도 구현
    }
    
    void MarkQuestLocation()
    {
        // _markerManager.DestroyMarker();
        // _markerManager.MakeMarker(QuestArr[Stage].stageArr[Level].questObject.transform.position);
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