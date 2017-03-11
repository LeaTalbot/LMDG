using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene3Kitchen : MonoBehaviour {



	//Copy-pasted from QA script, just in case it needs specific scene-based changes...


	//does not refer to the ink story files but to the script that controls how we do the Talking and Choosening
	private InkTalking inkScript;
	private Player player;
	private FadeInAndOut fade;

	public GameObject textBox;
	public Text text;

	public bool hasBeenInKitchen = false;
	public bool goBackToMainstage = false;


	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		inkScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<InkTalking>();
		fade = this.gameObject.GetComponent<FadeInAndOut>();
		fade.FadingIn();
	}


	void Update () {
		
		if (inkScript.storyCannotPlay == true) {
		
//			We will probably need the textboxes to appear sometimes during the kitchen challenge even though we do not have ink files
//			textBox.SetActive(false);
//			text.enabled = false;
			player.enabled = false; 

			//if the player just finished the first QA before the challenge:
			if (hasBeenInKitchen == false) {
				hasBeenInKitchen = true;
				fade.FadeToKitchen();
				StartCoroutine(KitchenPuzzleSkip());

			//if the player finished the challenge, go back to mainstage
			} else if (hasBeenInKitchen && goBackToMainstage) {
				goBackToMainstage = false;
				fade.FadingOut();

			} else {
				//do nothing
			}
		}
	}



	IEnumerator KitchenPuzzleSkip() {


		yield return new WaitForSeconds(2f);

		textBox.SetActive(true);
		text.enabled = true;
		player.enabled = false; //we never know

		text.text = "To come: a cool puzzle!";

		yield return new WaitForSeconds(3f);

		text.text = "";

		textBox.SetActive(false);
		text.enabled = false;
		goBackToMainstage = true;

		yield break;
	}
}
