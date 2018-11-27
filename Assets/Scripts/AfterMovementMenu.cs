using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterMovementMenu : MonoBehaviour {

	public GameObject attackPrefab;
	GameObject attack;

	public GameObject endPrefab;
	GameObject end;

	public GameObject equipPrefab;
	GameObject equip;

	public GameObject tradePrefab;
	GameObject trade;

	public GameObject healPrefab;
	GameObject heal;

	public GameObject dancePrefab;
	GameObject dance;

	public GameObject caravanPrefab;
	GameObject caravan;

	bool fifthUsed;

	public bool Menu(){
		RenderMenu();
		return true;
	}

	public void RenderMenu(){
		attack = Instantiate(attackPrefab, transform) as GameObject;
		attack.transform.localPosition = new Vector3(1, .5f, -1.5f);

		end = Instantiate(endPrefab, transform) as GameObject;
		end.transform.localPosition = new Vector3(1, 0f, -1.5f);

		equip = Instantiate(equipPrefab, transform) as GameObject;
		equip.transform.localPosition = new Vector3(1f, -.5f, -1.5f);

		trade = Instantiate(tradePrefab, transform) as GameObject;
		trade.transform.localPosition = new Vector3(1f, -1f, -1.5f);

		if(GetComponent<ClassManager>().unitClass.pType[(int)Class.PrefType.Staff] != '.'){
			fifthUsed = true;
			heal = Instantiate(healPrefab, transform) as GameObject;
			heal.transform.localPosition = new Vector3(1f, -1.5f, -1.5f);
		}
		else if(GetComponent<ClassManager>().unitClass.name == "Dancer"){
			fifthUsed = true;
			dance = Instantiate(dancePrefab, transform) as GameObject;
			dance.transform.localPosition = new Vector3(1f, -1.5f, -1.5f);
		}
		if(GetComponent<ClassManager>().unitClass.name == "Lance Lord" || GetComponent<ClassManager>().unitClass.name == " Great Lance Lord" ){
			caravan = Instantiate(caravanPrefab, transform) as GameObject;
			if(fifthUsed){
				caravan.transform.localPosition = new Vector3(1, -2.0f, -1.5f);
			} 
			else {
				caravan.transform.localPosition = new Vector3(1, -1.5f, -1.5f);
				fifthUsed = true;
			}
		}
	}

	public void ExitMenu(){
		Destroy(attack);
		Destroy(end);
		Destroy(equip);
		Destroy(dance);
		Destroy(heal);
		Destroy(trade);
		Destroy(caravan);
		fifthUsed = false;
	}
}
