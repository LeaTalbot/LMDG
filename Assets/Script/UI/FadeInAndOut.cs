using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInAndOut : MonoBehaviour {



	//FADING IN AND OUT FOR SMOOTHER TRNASITIONS



	private InkTalking inkScript;
	private Player playerScript;
	private GameObject player;

	public GameObject textBox;
	public Text text;

	public Image fadeOut;




	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.GetComponent<Player>();
		inkScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<InkTalking>();
	}



	// =========================================================================

	// GENERAL USE

	// =========================================================================




	public void FadingIn() {
		fadeOut.enabled = false;
		StartCoroutine(FadeIn());
	}

	IEnumerator FadeIn() {
		playerScript.enabled = false;
		yield return new WaitForSeconds(1f);
		inkScript.StartStory();
		yield break;
	}



	private YieldInstruction fadeInstruction = new YieldInstruction();

	public void FadingOut () {
		fadeOut.enabled = true;
		StartCoroutine(FadeOutAndChangeScene());
	}

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



	// =========================================================================

	// SPECIFIC USES

	// =========================================================================



	public void FadeToKitchen() {
		fadeOut.enabled = true;
		StartCoroutine(FadeOutToKitchen());
	}

	IEnumerator FadeOutToKitchen() {

		float currentTime = 0f;
		Color temp = fadeOut.color;

		while (currentTime < 2f) {
			yield return fadeInstruction;
			currentTime += Time.deltaTime;
			temp.a = Mathf.Clamp01 (currentTime / 2f);
			fadeOut.color = temp;
		}

		fadeOut.enabled = false;
		Camera.main.transform.position = new Vector3 (15f, 0f, -10f);
		//player.transform.position = ...
		//player scale = ...
		yield break;
	}



	public void FadeToMainMenu() {
		fadeOut.enabled = true;
		StartCoroutine(FadeOutToMainMenu());
	}

	IEnumerator FadeOutToMainMenu() {

		float currentTime = 0f;
		Color temp = fadeOut.color;

		while (currentTime < 2f) {
			yield return fadeInstruction;
			currentTime += Time.deltaTime;
			temp.a = Mathf.Clamp01 (currentTime / 2f);
			fadeOut.color = temp;
		}

		fadeOut.enabled = false;

		SceneManager.LoadScene(0);
	}
}