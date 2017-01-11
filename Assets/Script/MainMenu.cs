using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {



	public void OnClickStartButton() {

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}


	public void OnClickQuitButton() {

		Application.Quit();
	}
}
