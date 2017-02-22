using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInAndOut : MonoBehaviour {



	//FADING IN AND OUT FOR SMOOTHER TRNASITIONS



	private InkTalking inkScript;
	private Player player;

	public GameObject textBox;
	public Text text;

	public Image fadeOut;





	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		inkScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<InkTalking>();
	}
		



	public void FadingIn() {
		fadeOut.enabled = false;
		StartCoroutine(FadeIn());
	}

	IEnumerator FadeIn() {
		player.enabled = false;
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
}
