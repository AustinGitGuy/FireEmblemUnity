using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipClicked : MonoBehaviour {

	GameObject end;
	GameObject attack;
	GameObject heal;
	GameObject dance;
	GameObject trade;
	GameObject caravan;

	GameObject godObject;
	GameObject equipGUI;

	public bool clicked;

	void Start(){
		end = GameObject.Find("End(Clone)");
		attack = GameObject.Find("Attack(Clone)");
		heal = GameObject.Find("Heal(Clone)");
		dance = GameObject.Find("Dance(Clone)");
		godObject = GameObject.Find("GodObject");
		trade = GameObject.Find("Trade(Clone)");
		caravan = GameObject.Find("Caravan(Clone)");
	}

	void OnMouseDown(){
		gameObject.SetActive(false);
		end.SetActive(false);
		attack.SetActive(false);
		trade.SetActive(false);
		if(heal != null){
			heal.SetActive(false);
		}
		if(dance != null){
			dance.SetActive(false);
		}
		if(caravan != null){
			caravan.SetActive(false);
		}
		EquipMenu();
	}

	void EquipMenu(){
		if(clicked){
			return;
		}
		clicked = true;
		equipGUI = godObject.GetComponent<GUIManager>().equipGUI;
		equipGUI.SetActive(true);
		equipGUI.GetComponent<EquipGUI>().curUnit = this.transform.parent.gameObject;
		//equipGUI.GetComponent<EquipGUI>().Start();
	}


	public void BackToMenu(){
		clicked = false;
		equipGUI.SetActive(false);
		transform.parent.GetComponent<AfterMovementMenu>().ExitMenu();
		if(transform.parent.GetComponent<AfterMovementMenu>().Menu()){
			transform.parent.GetComponent<Movement>().DestroySquares();
		}
	}
}
