using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {



	//=================================================================

	// MOVEMENT AND ANIMATION FOR THE PLAYER

	//=================================================================




	Rigidbody2D myBody; 

	private Animator animator;

	public float playerSpeed = 5;

	public float currentXSpeed;
	public float currentYSpeed;




	void Start () {
	
		myBody = GetComponent<Rigidbody2D>();
		myBody.velocity = new Vector2(0, 0);

		animator = GetComponent<Animator>();
	}




	void Update () {


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
	}
}
