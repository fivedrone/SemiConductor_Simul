using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Manager : MonoBehaviour
{
    private string[,] QuestText = new string[9,5]
    {
        {"실험실 입장", "클린룸 입장", "", "", ""},
        {"웨이퍼 제조", "잉곳 생성&가공", "잉곳 커팅", "", ""},
        {"산화 공정", "산화 공정", "Furnace", "RTP", ""},
        {"포토 공정", "", "", "", ""},
        {"식각 공정", "", "", "", ""},
        {"증착&이온주입 공정", "", "", "", ""},
        {"금속 배선 공정", "설명 참조", "", "", ""},
        {"EDS 공정", "설명 참조", "", "", ""},
        {"패키징 공정", "설명 참조", "", "", ""}
    };

    private UI_Manager UIManager;
    public Text Stage_UI;
    public Text Level_UI;
    private GameObject Player;
    private int prevStage = 0;
    private int prevLevel = 0;

    public int Stage { get; set; } = 0; // 공정 단계 구분. Stage가 바뀔 때 Level은 자동으로 1로 설정하기.
    public int Level { get; set; } = 0; // 공정 단계 중 소단계 구분. StageText가 index0인거 기억하기. Level이 바뀔때는 그냥 Level+1하기

    
    // Start is called before the first frame update
    void Awake()
    {
        Stage = 1;
        Level = 1;
        Stage_UI.text = "";
        Level_UI.text = "";
        UIManager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Stage != prevStage || Level != prevLevel)
        {
            prevStage = Stage;
            prevLevel = Level;
            UpdateQuestUI();
        }
    }

    void UpdateQuestUI()
    {
        if (QuestText[Stage, Level].Equals(""))
        {
            Stage += 1;
            Level = 1;
        }
        else
        {
            Stage_UI.text = QuestText[Stage, 0];
            Level_UI.text = QuestText[Stage, Level];
        }
    }
}
