using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;

public class InkTalking : MonoBehaviour {

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

	private Player player;

	public GameObject textBox;

	private bool waitingOnInput;

	public bool storyCannotPlay = false;




	//void Awake () {
	//	StartStory();
	//}

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	public void StartStory () {
		InitSpeakers();
		story = new Story (inkJSONAsset.text);
		RefreshView();
	}

	void Update () {

		//While story is still going, we should not be able to move or hit esc (or interact with stuff)
		if (story.canContinue || story.currentChoices.Count > 0) {
			player.enabled = false;
		} else {
			player.enabled = true;
		}

		//Have the textbox when we have text
		if (text.enabled == true) {
			textBox.SetActive(true);
		} else {
			textBox.SetActive(false);
		}

		if(!waitingOnInput && (Input.GetMouseButtonDown(0)) || Input.GetKeyDown(KeyCode.Space)) {
			if(story.canContinue) {
				RefreshView();
			} else if(story.currentChoices.Count > 0) {
				RefreshView();
			} else {
				Debug.Log("Reached end of story.");
				//				StartStory();
				// If we don't have any more story... Well, let's turn this component off.
				// Have another script that changes the json script and turn the thing on to continue when needed
				storyCannotPlay = true;
			}
		}
	}
	void RefreshView () {
		if (story.canContinue) {
			HideChoices();
			text.gameObject.SetActive(true);
			string rawText = story.Continue ().Trim();
			text.text = ParseContent(rawText);
		} 
		else if(story.currentChoices.Count > 0) {
			ChangeSpeaker("Lucy");
			HideContent();
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
		//narrator.enabled = false;
		ChangeSpeaker("Lucy");
	}

	private void ChangeSpeaker (string speaker) {
		if(currentSpeaker != null) {
			currentSpeaker.enabled = false;
			//}
			//if(speaker == "Robert") {
			//	currentSpeaker = robert;
			//} else if(speaker == "Narrator") {
			//	currentSpeaker = narrator;
		} else {
			currentSpeaker = lucy;
		}
		currentSpeaker.enabled = true;
	}
}
