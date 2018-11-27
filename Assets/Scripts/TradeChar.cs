using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TradeChar : MonoBehaviour {

	GameObject[] characters;
	GameObject otherUnit;
	GameObject player;

	GameObject tradeGUI;

	void Start(){
		player = transform.parent.gameObject;
		characters = GameObject.FindGameObjectsWithTag("Character");
		for(int i = 0; i < characters.Length; i++){
			characters[i] = characters[i].transform.parent.gameObject;
		}
	}

	void OnMouseDown(){
		TradeInit();
	}

	void TradeInit(){
		for(int i = 0; i < characters.Length; i++){
			if(characters[i].transform.position == this.gameObject.transform.position){
				otherUnit = characters[i];
			}
		}
		tradeGUI = GameObject.Find("GodObject").GetComponent<GUIManager>().tradeGUI;
		tradeGUI.SetActive(true);
		tradeGUI.GetComponent<TradeGUI>().curUnit = player;
		tradeGUI.GetComponent<TradeGUI>().nUnit = otherUnit;
	}
}
