using UnityEngine;
using System.Collections;

public class SetResolution : MonoBehaviour {


	//Don't know if this works, but this is pretty self-explanatory.


	void Start () {

		Screen.SetResolution (800, 600, false);
	}
}
