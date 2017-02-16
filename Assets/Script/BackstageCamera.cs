using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackstageCamera : MonoBehaviour {



	//THIS SCRIPT ALLOWS THE CAMERA TO FOLLOW PLAYER WHEN MOVING BACKSTAGE 


	public GameObject player;



	void OnTriggerEnter2D (Collider2D coll) {

		//camera becomes child of player object (and therefore moves with it)
		Camera.main.transform.parent = player.transform;
	}

	void OnTriggerExit2D (Collider2D coll) {

		//camera is unparented fromplayer gameobject
		Camera.main.transform.parent = null;
	}
}
