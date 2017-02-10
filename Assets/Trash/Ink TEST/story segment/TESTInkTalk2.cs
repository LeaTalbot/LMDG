using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;

public class TESTInkTalk2 : MonoBehaviour {

		[SerializeField]
	private TextAsset inkJSONAsset;
	private Story story;

	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private Image lucy;
//	[SerializeField]
//	private Image robert;
//	[SerializeField]
//	private Image narrator;
	private Image currentSpeaker;

	[SerializeField]
	private Text text;
	[SerializeField]
	private InkCreateButton[] buttons;

	public GameObject textBox;
//	public bool reading {
//		get {
//			return textBox.activeSelf;
//		}
//	}

	private bool waitingOnInput;

	void Awake () {
		StartStory();
	}

	void StartStory () {
		InitSpeakers();
		story = new Story (inkJSONAsset.text);
		RefreshView();
	}

	void Update () {

		if (text.enabled == true) {
			textBox.SetActive(true);
		} else {
			textBox.SetActive(false);
		}

		if(!waitingOnInput && Input.GetMouseButtonDown(0)) {
			if(story.canContinue) {
				RefreshView();
			} else if(story.currentChoices.Count > 0) {
				RefreshView();
			} else {
				Debug.Log("Reached end of story.");
//				StartStory();
			}
		}
	}
	void RefreshView () {
		if (story.canContinue) {
			HideChoices();
			//textBox.SetActive(true);
			text.gameObject.SetActive(true);
			string rawText = story.Continue ().Trim();
			text.text = ParseContent(rawText);
		} 
		else if(story.currentChoices.Count > 0) {
			ChangeSpeaker("Lucy");
			for (int i = 0; i < Mathf.Min(story.currentChoices.Count, buttons.Length); i++) {
				InkCreateButton button = buttons[i];
				Choice choice = story.currentChoices[i];
				button.gameObject.SetActive(true);
				button.text.text = choice.text;
				button.button.onClick.AddListener(delegate{
					OnClickChoiceButton(choice);
				});
			}
			waitingOnInput = true;
		}
	}

	public string ParseContent (string rawContent) {
		string subjectID = "";
		string content = "";
		if(!TrySplitContentBySearchString(rawContent, ": ", ref subjectID, ref content)) return rawContent;
		ChangeSpeaker(subjectID);
		return content;
	}

	public bool TrySplitContentBySearchString (string rawContent, string searchString, ref string left, ref string right) {
		int firstSpecialCharacterIndex = rawContent.IndexOf(searchString);
		if(firstSpecialCharacterIndex == -1) return false;
		
		left = rawContent.Substring(0, firstSpecialCharacterIndex).Trim();
		right = rawContent.Substring(firstSpecialCharacterIndex+searchString.Length, rawContent.Length-firstSpecialCharacterIndex-searchString.Length).Trim();
		return true;
	}

	void ShowContentView (string text) {
		
	}

	void ShowChoiceView (string text) {
		
	}

	void HideChildren () {
		
	}

	void HideContent () {
		text.gameObject.SetActive(false);
	}

	void HideChoices () {
		foreach(var button in buttons) {
			button.gameObject.SetActive(false);
		}
	}

	public void OnClickChoiceButton (Choice choice) {
		for (int i = 0; i < Mathf.Min(story.currentChoices.Count, buttons.Length); i++) {
			InkCreateButton button = buttons[i];
			button.button.onClick.RemoveAllListeners();
		}
		waitingOnInput = false;
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

	private void InitSpeakers () {
		lucy.enabled = false;
		//robert.enabled = false;
		//dog.enabled = false;
		ChangeSpeaker("Lucy");
	}

	private void ChangeSpeaker (string speaker) {
		if(currentSpeaker != null) {
			currentSpeaker.enabled = false;
		//}
		//if(speaker == "Robert") {
		//	currentSpeaker = robert;
		//} else if(speaker == "Dog") {
		//	currentSpeaker = dog;
		} else {
			currentSpeaker = lucy;
		}
		currentSpeaker.enabled = true;
	}
}
