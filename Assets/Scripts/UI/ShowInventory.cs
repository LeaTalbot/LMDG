using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowInventory : MonoBehaviour {



	// this image is the row of blank inventory space
	public Image imageInvUI;

	private bool inventoryIsActive = false;


	// Switch visibility of the inventory
	public void OnClick () {

		if (inventoryIsActive == true) {
			
			imageInvUI.enabled = false;
			inventoryIsActive = false;

		} else if (inventoryIsActive == false) {
			
			imageInvUI.enabled = true;
			inventoryIsActive = true;
		}
	}
}
