using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickObjects : MonoBehaviour {



	//=================================================================

	// INTERACTIONS: CLICK OBJECTS AND DIALOGUES

	//=================================================================



	public GameObject dialogueBox;
	public GameObject playerImage;
	public Text dialogueText;

	private bool isDialogueBoxActive = false;

	//private bool pressSpaceToContinue = false;
	private bool pressSpaceToClose = false;




	//=================================================================

	// CUSTOM METHODS:


	// Update call for the dialogue box
	private void UpdateDialogueBox() {

		dialogueBox.SetActive(isDialogueBoxActive);
		playerImage.SetActive(isDialogueBoxActive);
	}
		

	// Alternates between showing and hiding dialogue boxe
	public void ToggleDialogueBox() {

		isDialogueBoxActive = !isDialogueBoxActive;
		UpdateDialogueBox();
	}

	//=================================================================



	void Start () {

		UpdateDialogueBox();
	}


	void Update () {


		//disabling right-click when in a dialogue

		if (isDialogueBoxActive) {
			if (Input.GetMouseButtonDown(0)) {
				return;
			}
		}


		//Press Space to close the dialogue

		if (pressSpaceToClose) {

			if (Input.GetKeyDown(KeyCode.Space)) {

				pressSpaceToClose = !pressSpaceToClose;
				ToggleDialogueBox();
			}
		}


		//raycasting + clicking on objects to get text

		if (Input.GetMouseButtonDown(0)) {

			Debug.DrawLine (Camera.main.transform.position, Input.mousePosition);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit, 1000f)) {

				if (hit.collider.tag == "Object") {

					ToggleDialogueBox();

					//----------------------------------------------

					if (hit.collider.name == "Mirror") {

						pressSpaceToClose = true;
						dialogueText.text = "Something something";

						//things here are only taking place in one click, so we can't really do anything sequential.
						//hence the use of the bool to take things outside of the click but still in Update
						//This is kind of messy code and I apologize, I'll try to clean up ASAP
					}

				} else {
					return;
				}
			}
		}
	}
}
