using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene2DressingRoom : MonoBehaviour {


	private Player player;
	public FadeInAndOut gameManagerFade;

	public GameObject textBox;
	public Text text;


		

	void OnCollisionEnter2D (Collision2D coll) {

		Debug.Log ("Mip");
		//textBox.SetActive(true);
		//text.enabled = true;
		//player.enabled = false;

		//Ink story: go out? Yes / No

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		//gameManagerFade.FadingOut();
	}
}
