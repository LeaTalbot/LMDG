using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TESTClickWithInk : MonoBehaviour {



	// DROP ON EACH INTERACTABLE OBJECT AND MANUALLY FILL PATH NAME (FOR EX: MIRROR.INTERACT)



	public TESTinkStory storyScript;
	public string inkPath = "";


	public void Interact() {

		storyScript.story.ChoosePathString(inkPath);
		storyScript.RefreshView();
	}
}
