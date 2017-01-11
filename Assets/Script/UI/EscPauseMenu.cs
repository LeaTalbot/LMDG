using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EscPauseMenu : MonoBehaviour {



	public GameObject escMenu;
	public bool escMenuIsActive = false;

	public Button resumeButton;
	public Button quitButton;



	//TODO: disable mouse click OUTSIDE of the menu box?



	void Update () {
	
		// Switch menu on and off when hitting esc
		if (Input.GetKeyDown(KeyCode.Escape)) {
			
			if (escMenuIsActive) {
				escMenu.SetActive(false);
				escMenuIsActive = false;
				resumeButton.enabled = false;
				quitButton.enabled = false;
			} else {
				escMenu.SetActive(true);
				escMenuIsActive = true;
				resumeButton.enabled = true;
				quitButton.enabled = true;
			}
		}
	}


	//RESUME button effect
	public void OnClickResume() {
		escMenu.SetActive(false);
		escMenuIsActive = false;
		resumeButton.enabled = false;
		quitButton.enabled = false;
	}


	//QUIT button effect
	public void OnClickQuit() {
		Application.Quit();
	}
}
