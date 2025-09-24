using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public struct Sentence
{
	[Tooltip("Text to be shown at one time.")]
	public string text;
	[Tooltip("Wheter or not player is given options to choose from.")]
	public bool options;
	public string option1;
	public string option2;
}

public class Interactable_Dialogue : Interactable
{
	public GameObject dialogueUI;
	public GameObject speakerPosition;
	public GameObject dialogueObj;
	private TMP_Text textDialogue;
	public GameObject titleObj;
	private TMP_Text textTitle;

	public GameObject button1obj;
	private Button button1;
	private TMP_Text button1Text;

	public GameObject button2obj;
	private Button button2;
	private TMP_Text button2Text;

	public Dialogue dialogue;

	private GameObject speakerPortrait;
	private bool clicked = false;

	public UnityEvent onDialogueEnd;

	private bool hasProgress = false;
	private DialogueProgress progress;

	private void Start()
	{
		button1Text = button1obj.GetComponentInChildren<TMP_Text>();
		button1 = button1obj.GetComponent<Button>();
		button1obj.SetActive(false);

		button2Text = button2obj.GetComponentInChildren<TMP_Text>();
		button2 = button2obj.GetComponent<Button>();
		button2obj.SetActive(false);

		textDialogue = dialogueObj.GetComponent<TMP_Text>();
		textTitle = titleObj.GetComponent<TMP_Text>();

		dialogueUI.SetActive(false);

		hasProgress = TryGetComponent<DialogueProgress>(out progress);
	}

	protected override void Interact()
	{
		if (hasProgress)
		{
			progress.CheckProgress();
		}

		Movement.single.canMove = false;

		dialogueUI.SetActive(true);

		speakerPortrait = (GameObject)Instantiate(dialogue.speakerPrefab, speakerPosition.transform);

		StartCoroutine(Speak());
	}

	private IEnumerator Speak()
	{
		textTitle.text = dialogue.speakerName;

		for (int i = 0; i < dialogue.sentences.Count; i++)
		{
			textDialogue.text = dialogue.sentences[i].text;
			yield return WaitForInput(dialogue.sentences[i]);
		}

		Destroy(speakerPortrait);
		dialogueUI.SetActive(false);

		Movement.single.canMove = true;

		onDialogueEnd?.Invoke();
	}

	public IEnumerator WaitForInput(Sentence sentence)
	{
		if (sentence.options)
		{
			button1obj.SetActive(true);
			button1Text.text = sentence.option1;
			button1.onClick.AddListener(() => this.clicked = true);

			button2obj.SetActive(true);
			button2Text.text = sentence.option2;
			button2.onClick.AddListener(() => this.clicked = true);

			while(!clicked)
			{
				yield return null;
			}

			button1obj.SetActive(false);
			button2obj.SetActive(false);

			clicked = false;
		}
		else
		{
			while (!Input.anyKeyDown)
			{
				yield return null;
			}

			yield return new WaitForEndOfFrame();
		}
	}
}
