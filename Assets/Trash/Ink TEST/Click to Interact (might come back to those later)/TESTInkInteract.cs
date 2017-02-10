using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;



// DROP ON GAME MANAGER


public class TESTInkInteract : MonoBehaviour {



	[SerializeField]
	private TextAsset inkJSONAsset;
	public Story story;

	//[SerializeField]
	//private RectTransform textBox;

	public GameObject textBox;

	[SerializeField]
	private Text text;
	public bool reading {
		get {
			return textBox.activeSelf;
		}
	}
	//public bool displayTop;

	void Awake () {
		StartStory();
	}

	void StartStory () {
		story = new Story (inkJSONAsset.text);
		RefreshView();
	}

	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			RefreshView();
		}

		//float anchor = displayTop ? 1 : 0;
		//textBox.pivot = new Vector2(textBox.pivot.x, anchor);
		//textBox.anchorMin = new Vector2(textBox.anchorMin.x, anchor);
		//textBox.anchorMax = new Vector2(textBox.anchorMin.x, anchor);
	}

	public void RefreshView () {
		if (story.canContinue) {
			textBox.SetActive(true);
			text.text = story.Continue ().Trim();
		} else {
			HideView();
		}
	}

	void HideView () {
		textBox.SetActive(false);
	}
}
