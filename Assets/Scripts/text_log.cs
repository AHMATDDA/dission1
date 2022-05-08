
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
    Boolean justOne = false;
    public Text txt_Dialogue;
    public Button button_1;
    public GameObject panel;

    public Button tip_button_exit;

    // [SerializeField] �� �޸� ����Ƽ inspector â���� �ش� ������ ���� �� �� �ִ�.

    static public bool isDialogue = true;

    // ��ȭ�� �󸶳� ���� �Ǿ����� Ȯ��
    private int count = 0;

    static private String[] dialogue; // ��ȭ�� ���� �迭

    private void Awake()
    {
        dialogue = new String[100];
        // ȥ�㸻 ���� 
        dialogue[0] = "[���۾�����]\n\n������ �� ������..";
        dialogue[1] = "[���۾�����]\n\n2.	�� �Ϳ��� ���̿��µ�...";
        dialogue[3] = "end";
        
        //�Ƿ��ΰ��� ���� ģ�ϼ̳���?
        dialogue[4] = "[���۾�����]\n\n�ܰ�մ��̾��ܴ�.. ��å�� ������ ���� �鸣�� �߾���.. ";
        dialogue[5] = "end";
        //�׷�����.. Ȥ�� �Ƿ����� �ֺ��ο� ���� �ƽô� �� �����Ű���? 
        dialogue[6] = "[���۾�����]\n\n���� ��� ģ���� �� ���� �ٴϰ� �߾����� ";
        dialogue[7] = "[���۾�����]\n\nȥ�� �ִ� �� �ѹ��� �� �� ���� ���������ϡ� ";
        dialogue[8] = "[���۾�����]\n\n���� ���� ���̶�� �ϴ���.. ?";
        dialogue[9] = "end";
        //�� ��ģ�� ģ������ �����̱���.. Ȥ�� ��ҿ� �����ںа� ���̰� �� ���Ҵ� ���̳�, �����ڸ� �Ⱦ��ߴ� ���� �־�����?
        dialogue[10] = "[���۾�����]\n\n��.. �� ���̸� �Ⱦ��ϱ�� ���� ���� ���ε�..";
        dialogue[11] = "[���۾�����]\n\n�� �� �� �־�����..  ";
        dialogue[12] = "[���۾�����]\n\n���� �� ���� ���ܸ��� �ƹ� ���� ���� �� ���̸� �̿��ϰ� �߾���.. ";
        dialogue[13] = "[���۾�����]\n\n�� ��� ������ �� ���� ������ �� �������� ����ðԳ�.. ";
        dialogue[14] = "end";
        //

        Button_SetActive(false);
    }





    private void Start()
    {
        button_1.gameObject.SetActive(false);

        Debug.Log("dialogue.length = " + dialogue.Length);
        ShowDialogue(0);
    }

    public void ShowDialogue(int count_)
    {
        count = count_;
        NextDialogue();
    }
    public void talk_npc()
    {
        button_1.gameObject.SetActive(true);

        count = 4;
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
        Button_SetActive(false);
        count = 4;
        npc_talk_int = 0;
        if (count < dialogue.Length)
            NextDialogue();

    }
    public void onClick_q2() // ���� 2
    {
        Button_SetActive(false);
        npc_talk_int = 0;
        txt_Dialogue.text = "";
        panel.SetActive(true);

    }
    public void onClick_tip_1() // �÷��̾� �̵� & ����ֱ�
    {
        panel.SetActive(false);
        isDialogue = true;
        count = 26;
        npc_talk_int = 0;
        if (count < dialogue.Length)
            NextDialogue();
    }

    public void onClick_tip_2() // �� & ������ ����ϱ�
    {
        panel.SetActive(false);
        isDialogue = true;
        count = 29;
        npc_talk_int = 0;
        if (count < dialogue.Length)
            NextDialogue();
    }
    public void onClick_tip_exit() // �н��ϱ� â���� ������ Ŭ��
    {
        panel.SetActive(false);
        npc_talk_int = 1;
    }



    public void Button_SetActive(bool set)
    {
        button_1.gameObject.SetActive(set);
        button_2.gameObject.SetActive(set);
        button_3.gameObject.SetActive(set);
    }

    void Update()
    {
        if (npc_talk_int == 1 && justOne == false)
        {
            talk_npc();
            justOne = true;
        }
        else if (npc_talk_int == 2)
        {

            button_1.gameObject.SetActive(false);

            justOne = false;
        }
        // count �� 4�� ������ ��ȭ �������̶� ���� �д�.
        if (isDialogue && count != 4)
        {
            if (dialogue[count].Equals("end"))
            {
                npc_talk_int = 1;
            }
            //if (OVRInput.GetDown(OVRInput.Button.One))
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (count < dialogue.Length)
                    NextDialogue();
            }
        }
    }
}


