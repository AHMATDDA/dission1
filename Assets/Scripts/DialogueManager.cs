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
			GameObject.Find("TestButton").GetComponentInChildren<Text>().text = "그랬군요.. 혹시 의뢰인 주변인에 대해 아시는 것 있으신가요? ";

		}
		if (sentences.Count == 4)
		{
			GameObject.Find("TestButton").GetComponentInChildren<Text>().text = "아 절친한 친구분이 있으셨군요... 혹시 평소에 피해자분과 사이가 안 좋았던 분이나, 피해자를 싫어했던 분은 아시나요? ";

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

	//GameObject.Find("TestButton").GetComponentInChildren<Text>().text = "그랬군요.. 혹시 의뢰인 주변인에 대해 아시는 것 있으신가요? ";
	//StartDialogue(dialogue);

	//}

	//void RealEndDialogue()
	//{
	//GameObject.Find("TestButton").GetComponentInChildren<Text>().text = "아 절친한 친구분이 있으셨군요... 혹시 평소에 피해자분과 사이가 안 좋았던 분이나, 피해자를 싫어했던 분은 아시나요? ";

	//}
}
