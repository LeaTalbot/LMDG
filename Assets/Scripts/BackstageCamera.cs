using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackstageCamera : MonoBehaviour {



	//THIS SCRIPT ALLOWS THE CAMERA TO FOLLOW PLAYER WHEN MOVING BACKSTAGE 

	private float cameraPosY;
	private float originalPosY;



	public GameObject player;


	void OnTriggerEnter2D (Collider2D coll) {

		//camera becomes child of player object (and therefore moves with it)
		Camera.main.transform.parent = player.transform;

		//TODO: find a way to freeze camera y position!
	}
		

	void OnTriggerExit2D (Collider2D coll) {

		//camera is unparented fromplayer gameobject
		Camera.main.transform.parent = null;
	}
}
