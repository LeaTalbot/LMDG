using UnityEngine;
using UnityEngine.UI;
using System.Collections;



//This script is called by the InkTalking script to create buttons. Just grabbed it from the Ink demos. 


public class InkCreateButton : MonoBehaviour {

	public Button button;
	public Text text;

	public enum ButtonType {
		A,
		B,
		C,
		D
	}
	public ButtonType buttonType;

	void Start() {

	}

	void Update() {

	}
}
