using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TESTCreateButton : MonoBehaviour {

	public Button button;
	//public Text buttonText;
	public Text text;

	public enum ButtonType {
		A,
		B,
		C,
		D
	}
	public ButtonType buttonType;

	void Start () {
		
	}

	void Update () {
		//buttonText.text = buttonType.ToString();
	}
}
