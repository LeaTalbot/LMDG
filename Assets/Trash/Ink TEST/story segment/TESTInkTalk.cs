using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;

public class TESTInkTalk : MonoBehaviour {


	[SerializeField]
	private TextAsset inkJSONAsset;
	private Story story;

	//[SerializeField]
	//private Canvas canvas;
	public GameObject textBox;

	[SerializeField]
	private Text text;
	public bool reading {
		get {
			return textBox.activeSelf;
		}
	}
	//public string text;

	[SerializeField]
	public Button button1;
	public Button button2;
	public Button button3;

	void Awake () {
		StartStory();
	}

	void StartStory () {
		story = new Story (inkJSONAsset.text);
		RefreshView();
	}

	void RefreshView () {
		//RemoveChildren ();

		if (story.canContinue) {
			//text = story.Continue ().Trim();
			textBox.SetActive(true);
			text.text = story.Continue ().Trim();
			//CreateContentView(text);
		}

		if(story.currentChoices.Count > 0) {
			for (int i = 0; i < story.currentChoices.Count; i++) {
				//BLOCKS HERE
				Choice choice = story.currentChoices [i];
				Button button = CreateChoiceView (choice.text.Trim (), i);
				button.onClick.AddListener (delegate {
					//WE NEVER GET HERE
					OnClickChoiceButton (choice);
				});
			}
		} else {
			Button choice = CreateChoiceView("End of story.\nRestart?", 0);
			choice.onClick.AddListener(delegate{
				StartStory();
			});
		}
	}

	void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

//	void CreateContentView (string text) {
//		Text storyText = Instantiate (textPrefab) as Text;
//		storyText.text = text;
//		storyText.transform.SetParent (canvas.transform, false);
//	}

	Button CreateChoiceView (string text, int i) {

		if (i == 0) {
			Text choiceText = button1.GetComponentInChildren<Text> ();
			choiceText.text = text;
			return button1;
		} else if (i == 1) {
			Text choiceText = button2.GetComponentInChildren<Text> ();
			choiceText.text = text;
			return button2;
		} else {
			Text choiceText = button3.GetComponentInChildren<Text> ();
			choiceText.text = text;
			return button3;
		}


//		Button choice = Instantiate (buttonPrefab) as Button;
//		choice.transform.SetParent (canvas.transform, false);
//
//		Text choiceText = choice.GetComponentInChildren<Text> ();
//		choiceText.text = text;
//
//		HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
//		layoutGroup.childForceExpandHeight = false;
//
//		return choice;
	}

//	void RemoveChildren () {
//		int childCount = canvas.transform.childCount;
//		for (int i = childCount - 1; i >= 0; --i) {
//			GameObject.Destroy (canvas.transform.GetChild (i).gameObject);
//		}
//	}

	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			RefreshView();
		}
	}
}
