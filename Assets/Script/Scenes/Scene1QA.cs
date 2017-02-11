using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene1QA : MonoBehaviour {


	//does not refer to the ink story files but to the script that controls how we do the Talking and Choosening
	private InkTalking inkScript;
	private Player player;

	public GameObject textBox;
	public Text text;

	public Image fadeOut;




	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		inkScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<InkTalking>();
		StartCoroutine(FadeIn());
	}

	//Wait 1 second before starting the story so that the transition fills smoother!
	IEnumerator FadeIn() {
		yield return new WaitForSeconds(1f);
		inkScript.StartStory();
		yield break;
	}
	
	void Update () {

		if (inkScript.storyCannotPlay == true) {
			textBox.SetActive(false);
			text.enabled = false;
			player.enabled = false; //player should not move during fade out
			fadeOut.gameObject.SetActive(true);
			StartCoroutine(FadeOutAndChangeScene());
		}
	}

	private YieldInstruction fadeInstruction = new YieldInstruction();

	IEnumerator FadeOutAndChangeScene () {

		//Change Alpha of fadeOut image gradually
		float currentTime = 0f;
		Color temp = fadeOut.color;

		while (currentTime < 2f) {
			yield return fadeInstruction;
			currentTime += Time.deltaTime;
			temp.a = Mathf.Clamp01 (currentTime / 2f);
			fadeOut.color = temp;
		}

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
