using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;
	public Dialogue1 dialogue;
	public int count = 0;
	//public Animator animator;

	private Queue<string> sentences;
	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();


	}

	public void StartDialogue(Dialogue1 dialogue)
	{
		//animator.SetBool("IsOpen", true);


		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{

		if (sentences.Count == 7)
		{
			GameObject.Find("TestButton").GetComponentInChildren<Text>().text = "�׷�����.. Ȥ�� �Ƿ��� �ֺ��ο� ���� �ƽô� �� �����Ű���? ";

		}
		if (sentences.Count == 4)
		{
			GameObject.Find("TestButton").GetComponentInChildren<Text>().text = "�� ��ģ�� ģ������ �����̱���... Ȥ�� ��ҿ� �����ںа� ���̰� �� ���Ҵ� ���̳�, �����ڸ� �Ⱦ��ߴ� ���� �ƽó���? ";

		}



		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));

	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	//void EndDialogue()
	//{

	//GameObject.Find("TestButton").GetComponentInChildren<Text>().text = "�׷�����.. Ȥ�� �Ƿ��� �ֺ��ο� ���� �ƽô� �� �����Ű���? ";
	//StartDialogue(dialogue);

	//}

	//void RealEndDialogue()
	//{
	//GameObject.Find("TestButton").GetComponentInChildren<Text>().text = "�� ��ģ�� ģ������ �����̱���... Ȥ�� ��ҿ� �����ںа� ���̰� �� ���Ҵ� ���̳�, �����ڸ� �Ⱦ��ߴ� ���� �ƽó���? ";

	//}
}
