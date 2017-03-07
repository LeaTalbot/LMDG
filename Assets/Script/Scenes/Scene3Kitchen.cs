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




	void Start () {
		Debug.Log("Started");
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		inkScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<InkTalking>();
		fade = this.gameObject.GetComponent<FadeInAndOut>();
		fade.FadingIn();
	}


	void Update () {

		Debug.Log("Updating");
		if (inkScript.storyCannotPlay == true) {
			textBox.SetActive(false);
			text.enabled = false;
			player.enabled = false; //player should not move during fade out
			//fade.FadingOut();
		}
	}
}
