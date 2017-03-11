using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransitions : MonoBehaviour {


	//THIS SCRIPT TELEPORTS PLAYER AND CAMERA AROUND IN THE SAME SCENE

	public Transform destination;
	public Transform cameraDestination;



	void Start() {

		// Each teleport trigger has a empty child object named destination, which acts as an anchor of sorts. 

		// Needs more work!

		//string getDestination = "/" + this.name + "/destination";
		//destination = GameObject.Find(getDestination).transform;

		//same for camera
	}



	void OnCollisionEnter2D (Collision2D coll) {

		if (coll.gameObject.tag == "Player") {
			coll.transform.position = destination.position;
			Camera.main.transform.position = cameraDestination.position;
		}
	}
}
