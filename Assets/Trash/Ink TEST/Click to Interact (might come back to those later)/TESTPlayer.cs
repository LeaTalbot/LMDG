using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TESTPlayer : MonoBehaviour {

	//=================================================================

	// MOVEMENT AND ANIMATION FOR THE PLAYER + CLICKING?

	//=================================================================


	public TESTInkInteract storyScript;
	public TESTClickWithInk targetObject;

	Rigidbody2D myBody; 

	private Animator animator;

	public float playerSpeed = 5;

	public float currentXSpeed;
	public float currentYSpeed;

	//public GameObject dialogueBox;
	public GameObject playerImage;
	//public Text dialogueText;

	private bool isDialogueBoxActive = false;

	//private bool pressSpaceToContinue = false;
	private bool pressSpaceToClose = false;




	void Start () {

		myBody = GetComponent<Rigidbody2D>();
		myBody.velocity = new Vector2(0, 0);

		animator = GetComponent<Animator>();

		UpdateDialogueBox();
	}




	void Update () {





		// Some copy paste from the Unite demo files

		//storyScript.displayTop = Camera.main.WorldToViewportPoint(transform.position).y < 0.5f;
		if(!storyScript.reading) {
			if(targetObject != null) {
				targetObject.Interact();
			}
		}

		if (storyScript.reading) {
			return;
		}






		//MOVEMENT IMPLEMENTATION (NO DIAGONALS ALLOWED!)

		//ARROW MOVEMENTS:
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {

			currentYSpeed = 0;
			currentXSpeed = -playerSpeed;
		}
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {

			currentYSpeed = 0;
			currentXSpeed = playerSpeed;
		}
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {

			currentXSpeed = 0;
			currentYSpeed = playerSpeed;
		}
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {

			currentXSpeed = 0;
			currentYSpeed = -playerSpeed;
		}

		//release the keys 
		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) {

			if (currentXSpeed < 0) {
				currentXSpeed = 0;
			}
		}
		if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) {

			if (currentXSpeed > 0) {
				currentXSpeed = 0;
			}
		}
		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) {

			if (currentYSpeed > 0) {
				currentYSpeed = 0;
			}
		}
		if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) {

			if (currentYSpeed < 0) {
				currentYSpeed = 0;
			}
		}


		//=================================================================


		// POINT AND CLICK MOVEMENTS (AND MOVEMENTS ONLY)

		//TODO
		//Setting up a raycast
		//A* Pathfinding!


		//=================================================================

		//actually moving:
		myBody.velocity = new Vector2(currentXSpeed, currentYSpeed);


		//=================================================================

		//WALKING AND IDLE ANIMATION

		if (currentXSpeed == 0 && currentYSpeed == 0) {

			animator.Play("idle");
		} 
		else if (currentXSpeed < 0 && currentYSpeed == 0) {

			animator.Play("walkLeft");
		}
		else if (currentXSpeed > 0 && currentYSpeed == 0) {

			animator.Play("walkRight");
		}
		else if (currentYSpeed < 0 && currentXSpeed == 0) {

			animator.Play("walkDown");
		}
		else if (currentYSpeed > 0 && currentXSpeed == 0) {

			animator.Play("walkUp");
		}




		//=================================================================


















		// EXPERIMENTING ; DON'T MIND ME
















		//=================================================================





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

					TESTClickWithInk currentTargetObject = hit.collider.transform.GetComponent<TESTClickWithInk>();
					if(currentTargetObject != null) {
						targetObject = currentTargetObject;
					}

					ToggleDialogueBox();


					//probably will not work because it needs to take place AFTER the click and not during it. And we are in the click code.
					if (isDialogueBoxActive == false) {
						if(targetObject == null) 
							return;
						TESTClickWithInk currentTargetNPC = hit.collider.transform.GetComponent<TESTClickWithInk>();
						if(currentTargetNPC == targetObject)
							targetObject = null;
					}

				} else {
					return;
				}
			}
		}

		//clearing target object should happen here, I think
	}



	//=================================================================

	// CUSTOM METHODS:


	// Update call for the dialogue box
	private void UpdateDialogueBox() {

		//dialogueBox.SetActive(isDialogueBoxActive);
		playerImage.SetActive(isDialogueBoxActive);
	}


	// Alternates between showing and hiding dialogue boxe
	public void ToggleDialogueBox() {

		isDialogueBoxActive = !isDialogueBoxActive;
		UpdateDialogueBox();
	}

	//=================================================================
}
