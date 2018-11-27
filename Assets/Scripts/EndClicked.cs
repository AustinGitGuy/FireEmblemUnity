using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndClicked : MonoBehaviour {

	void OnMouseDown(){
		transform.parent.GetComponent<Movement>().inMenu = false;
		transform.parent.GetComponent<Movement>().turnEnd = true;
		transform.parent.GetComponent<AfterMovementMenu>().ExitMenu();
	}
}
