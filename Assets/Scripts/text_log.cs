
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
[System.Serializable]
public class Dialogue
{
    // 여러줄을 쓸 수 있게 해준다.
    [TextArea]
    public string dialogue;
}

public class text_log : MonoBehaviour
{
    static public int npc_talk_int = 0;
    //Boolean justOne = false;
    public Text txt_Dialogue;
    public Button button_1;
    public Button button_2;
    public Button button_3;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;


    public Button tip_button_exit;

    // [SerializeField] 을 달면 유니티 inspector 창에서 해당 변수를 조작 할 수 있다.

    static public bool isDialogue = true;

    // 대화가 얼마나 진행 되었는지 확인
    private int count = 0;

    static private String[] dialogue; // 대화가 들어가는 배열

    private void Awake()
    {
        dialogue = new String[100];
        // 혼잣말 띄우기 //플레이어가 다가가면 뜸,,
        dialogue[0] = "[슈퍼아저씨]\n\n오늘은 안 오려나..";
        dialogue[1] = "[슈퍼아저씨]\n\n	참 귀여운 아이였는데...";
        dialogue[2] = "end";
                //main  
        dialogue[3] = "[슈퍼아저씨]\n\n뭐 찾는 거라도 있나? ";

        //의뢰인과는 많이 친하셨나요?
        dialogue[4] = "[슈퍼아저씨]\n\n단골손님이었단다.. 산책을 끝내고 자주 들르곤 했었지.. ";
        dialogue[5] = "";
        dialogue[6] = "end1";
        //그랬군요.. 혹시 의뢰인의 주변인에 대해 아시는 것 있으신가요? 
        dialogue[7] = "[슈퍼아저씨]\n\n같이 사는 친구와 꼭 같이 다니곤 했었지… ";
        dialogue[8] = "[슈퍼아저씨]\n\n혼자 있는 걸 한번도 본 적 없는 정도였으니… ";
        dialogue[9] = "[슈퍼아저씨]\n\n가족 같은 사이라고 하더군.. ?";
        dialogue[10] = "end2";
        //아 절친한 친구분이 있으셨군요.. 혹시 평소에 피해자분과 사이가 안 좋았던 분이나, 피해자를 싫어했던 분이 있었나요?
        dialogue[11] = "[슈퍼아저씨]\n\n음.. 그 아이를 싫어하기는 쉽지 않은 일인데..";
        dialogue[12] = "[슈퍼아저씨]\n\n아 한 명 있었구려..  ";
        dialogue[13] = "[슈퍼아저씨]\n\n저기 저 옆집 아줌마가 아무 이유 없이 그 아이를 미워하곤 했었어.. ";
        dialogue[14] = "[슈퍼아저씨]\n\n이 골목만 지나면 그 집이 나오니 그 여자한테 물어보시게나.. ";
        dialogue[15] = "end";



        //Button_SetActive(false);
        button_1.gameObject.SetActive(false);

    }





    private void Start()
    {
        button_1.gameObject.SetActive(false);
        button_2.gameObject.SetActive(false);
        button_3.gameObject.SetActive(false);
        Debug.Log("dialogue.length = " + dialogue.Length);
        

        NextDialogue();
    }



    public void talk_npc()
    {
        button_1.gameObject.SetActive(true);
        //button_2.gameObject.SetActive(true);
        //button_3.gameObject.SetActive(true);
        count = 3;
        //Button_SetActive(true);
        txt_Dialogue.text = dialogue[count];
    }
    public void talk_npc2()
    {
        button_2.gameObject.SetActive(true);
        //button_2.gameObject.SetActive(true);
        //button_3.gameObject.SetActive(true);
        count = 7;
        //Button_SetActive(true);
        txt_Dialogue.text = dialogue[count];
    }

    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count];
        count++;
    }

    public void onClick_q1()  // 질문 1
    {
        isDialogue = true;
        //Button_SetActive(false);
        button_1.gameObject.SetActive(false);
       // panel1.SetActive(true);
        count = 4;
        npc_talk_int = 0;
        if (count < dialogue.Length)
            NextDialogue();
        txt_Dialogue.text = ""; //텍스트 비우기
        //panel1.SetActive(false);
        button_2.gameObject.SetActive(true);

    }
    public void onClick_q2() // 질문 2
    {
        //Button_SetActive(false);
        //panel1.SetActive(false);
        //panel2.SetActive(true);
        button_2.gameObject.SetActive(false);
        isDialogue = true;
        count = 7;
        npc_talk_int = 0;
        //button_2.gameObject.SetActive(false);
        //txt_Dialogue.text = "";
        if (count < dialogue.Length)
            NextDialogue();
        //panel2.SetActive(true);
        button_3.gameObject.SetActive(true);

    }
    public void onClick_q3() //질문 3
    {
        panel2.SetActive(false);
        //panel3.SetActive(true);
        button_3.gameObject.SetActive(false);
        
        isDialogue = true;
        count = 11;
        npc_talk_int = 0;
        if (count < dialogue.Length)
            NextDialogue();
    }





    public void Button_SetActive(bool set)
    {
        button_1.gameObject.SetActive(set);
        button_2.gameObject.SetActive(set);
        button_3.gameObject.SetActive(set);
    }

    void Update()
    {
        // 질문 1 클릭시
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (button_1.gameObject.activeSelf == true)
            {
                button_1.onClick.Invoke();
                count = 4;
            }
        }
        // 질문 2 클릭시 
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (button_2.gameObject.activeSelf == true && npc_talk_int != 1)
            {
                button_2.onClick.Invoke();

            }
        }
        // 질문 3 클릭시
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (button_3.gameObject.activeSelf == true && npc_talk_int != 1)
            {
                button_3.onClick.Invoke();

            }
        }
        // 나가기
        /*else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            if (tip_button_exit.gameObject.activeSelf == true)
            {
                tip_button_exit.onClick.Invoke();

            }
        }*/

        if (npc_talk_int == 1)
        {
            isDialogue = false;
            talk_npc();//메인대사로 돌아감
        }
        else if (npc_talk_int == 2)
        {
            isDialogue = false;
            talk_npc2();
        }


        // 내용이 비어있으면 선택지 대화 진행중이라 막아 둔다.
        if (isDialogue && dialogue[count] != null)
        {
            if (dialogue[count].Equals("end"))
            {
                npc_talk_int = 1;
            }
            if (dialogue[count].Equals("end1"))
            {
                npc_talk_int = 2;
            }
            if (dialogue[count].Equals("end2"))
            {
                npc_talk_int = 3;
            }
            //if (OVRInput.GetDown(OVRInput.Button.One))
            if (Input.GetKey(KeyCode.G))//g 버튼을 누르면 다음 대사로 넘어감
            {
                if (count < dialogue.Length)
                    NextDialogue();
            }
        }
    }
}


