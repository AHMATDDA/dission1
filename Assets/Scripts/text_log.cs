
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
[System.Serializable]
public class Dialogue
{
    // �������� �� �� �ְ� ���ش�.
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

    // [SerializeField] �� �޸� ����Ƽ inspector â���� �ش� ������ ���� �� �� �ִ�.

    static public bool isDialogue = true;

    // ��ȭ�� �󸶳� ���� �Ǿ����� Ȯ��
    private int count = 0;

    static private String[] dialogue; // ��ȭ�� ���� �迭

    private void Awake()
    {
        dialogue = new String[100];
        // ȥ�㸻 ���� //�÷��̾ �ٰ����� ��,,
        dialogue[0] = "[���۾�����]\n\n������ �� ������..";
        dialogue[1] = "[���۾�����]\n\n	�� �Ϳ��� ���̿��µ�...";
        dialogue[2] = "end";
                //main  
        dialogue[3] = "[���۾�����]\n\n�� ã�� �Ŷ� �ֳ�? ";

        //�Ƿ��ΰ��� ���� ģ�ϼ̳���?
        dialogue[4] = "[���۾�����]\n\n�ܰ�մ��̾��ܴ�.. ��å�� ������ ���� �鸣�� �߾���.. ";
        dialogue[5] = "";
        dialogue[6] = "end1";
        //�׷�����.. Ȥ�� �Ƿ����� �ֺ��ο� ���� �ƽô� �� �����Ű���? 
        dialogue[7] = "[���۾�����]\n\n���� ��� ģ���� �� ���� �ٴϰ� �߾����� ";
        dialogue[8] = "[���۾�����]\n\nȥ�� �ִ� �� �ѹ��� �� �� ���� ���������ϡ� ";
        dialogue[9] = "[���۾�����]\n\n���� ���� ���̶�� �ϴ���.. ?";
        dialogue[10] = "end2";
        //�� ��ģ�� ģ������ �����̱���.. Ȥ�� ��ҿ� �����ںа� ���̰� �� ���Ҵ� ���̳�, �����ڸ� �Ⱦ��ߴ� ���� �־�����?
        dialogue[11] = "[���۾�����]\n\n��.. �� ���̸� �Ⱦ��ϱ�� ���� ���� ���ε�..";
        dialogue[12] = "[���۾�����]\n\n�� �� �� �־�����..  ";
        dialogue[13] = "[���۾�����]\n\n���� �� ���� ���ܸ��� �ƹ� ���� ���� �� ���̸� �̿��ϰ� �߾���.. ";
        dialogue[14] = "[���۾�����]\n\n�� ��� ������ �� ���� ������ �� �������� ����ðԳ�.. ";
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

    public void onClick_q1()  // ���� 1
    {
        isDialogue = true;
        //Button_SetActive(false);
        button_1.gameObject.SetActive(false);
       // panel1.SetActive(true);
        count = 4;
        npc_talk_int = 0;
        if (count < dialogue.Length)
            NextDialogue();
        txt_Dialogue.text = ""; //�ؽ�Ʈ ����
        //panel1.SetActive(false);
        button_2.gameObject.SetActive(true);

    }
    public void onClick_q2() // ���� 2
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
    public void onClick_q3() //���� 3
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
        // ���� 1 Ŭ����
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (button_1.gameObject.activeSelf == true)
            {
                button_1.onClick.Invoke();
                count = 4;
            }
        }
        // ���� 2 Ŭ���� 
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (button_2.gameObject.activeSelf == true && npc_talk_int != 1)
            {
                button_2.onClick.Invoke();

            }
        }
        // ���� 3 Ŭ����
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (button_3.gameObject.activeSelf == true && npc_talk_int != 1)
            {
                button_3.onClick.Invoke();

            }
        }
        // ������
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
            talk_npc();//���δ��� ���ư�
        }
        else if (npc_talk_int == 2)
        {
            isDialogue = false;
            talk_npc2();
        }


        // ������ ��������� ������ ��ȭ �������̶� ���� �д�.
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
            if (Input.GetKey(KeyCode.G))//g ��ư�� ������ ���� ���� �Ѿ
            {
                if (count < dialogue.Length)
                    NextDialogue();
            }
        }
    }
}


