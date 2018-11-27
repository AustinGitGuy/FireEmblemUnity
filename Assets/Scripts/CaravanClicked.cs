using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanClicked : MonoBehaviour {
	
	GameObject end;
	GameObject attack;
	GameObject heal;
	GameObject dance;
	GameObject trade;
	GameObject equip;

	GameObject godObject;

	GameObject caravanGUI;
	GameObject equipGUI;

	public bool clicked;

	void Start(){
		end = GameObject.Find("End(Clone)");
		attack = GameObject.Find("Attack(Clone)");
		heal = GameObject.Find("Heal(Clone)");
		dance = GameObject.Find("Dance(Clone)");
		godObject = GameObject.Find("GodObject");
		trade = GameObject.Find("Trade(Clone)");
		equip = GameObject.Find("Equip(Clone)");
	}

	void OnMouseDown(){
		gameObject.SetActive(false);
		end.SetActive(false);
		attack.SetActive(false);
		trade.SetActive(false);
		equip.SetActive(false);
		if(heal != null){
			heal.SetActive(false);
		}
		if(dance != null){
			dance.SetActive(false);
		}
		CaravanMenu();
	}

	void CaravanMenu(){
		if(clicked){
			return;
		}
		clicked = true;
		equipGUI = godObject.GetComponent<GUIManager>().equipGUI;
		caravanGUI = godObject.GetComponent<GUIManager>().caravan;
		equipGUI.SetActive(true);
		caravanGUI.SetActive(true);
		equipGUI.GetComponent<EquipGUI>().curUnit = this.transform.parent.gameObject;
	}

	public void BackToMenu(){
		clicked = false;
		equipGUI.SetActive(false);
		caravanGUI.SetActive(false);
		transform.parent.GetComponent<AfterMovementMenu>().ExitMenu();
		if(transform.parent.GetComponent<AfterMovementMenu>().Menu()){
			transform.parent.GetComponent<Movement>().DestroySquares();
		}
	}
}
