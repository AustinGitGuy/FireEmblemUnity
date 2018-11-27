using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnitMenu : MonoBehaviour {

	int curBarrackNum;
	GameObject charManager;
	public Image[] barracks;
	public GameObject[] barracksUnits;

	public bool menu;

	public GameObject clickUText;

	public GameObject tradeUnit;
	public GameObject otherUnit;

	GameObject tradeGUI;

	void Start(){
		clickUText = GameObject.Find("ClickUText");
		clickUText.SetActive(false);
		charManager = GameObject.Find("PlayerCharacters");
		barracks = new Image[48];
		barracksUnits = new GameObject[48];
		for(int i = 1; i < barracks.Length + 1; i++){
			barracks[i - 1] = GameObject.Find("ChooseV" + i).GetComponent<Image>();
			barracks[i - 1].gameObject.SetActive(false);
		}
	}

	void Update(){
		CheckBackToMenu();
		CheckMenuClose();
		curBarrackNum = 0;
		for(int i = 0; i < charManager.GetComponent<CharacterManager>().characters.Length; i++){
			if(charManager.GetComponent<CharacterManager>().unlocked[i]){
				barracks[curBarrackNum].gameObject.SetActive(true);
				barracks[curBarrackNum].sprite = charManager.GetComponent<CharacterManager>().characters[i].GetComponent<SpriteRenderer>().sprite;
				barracksUnits[curBarrackNum] = charManager.GetComponent<CharacterManager>().characters[i];
				curBarrackNum++;
			}
		}
		CheckTrade();
	}

	void CheckMenuClose(){
		if(Input.GetKeyDown(KeyCode.Escape) && menu){
			for(int i = 0; i < barracks.Length; i++){
				barracks[i].GetComponent<ViewUnitMenu>().ExitMenu();
				otherUnit = null;
				tradeUnit = null;
			}
			menu = false;
		}
	}

	void CheckBackToMenu(){
		if(Input.GetKeyDown(KeyCode.Escape) && !menu){
			GameObject.Find("GodObject").GetComponent<GUIManager>().barracks.SetActive(true);
			this.gameObject.SetActive(false);
			otherUnit = null;
			tradeUnit = null;
		}
	}

	void CheckTrade(){
		if(otherUnit != null && tradeUnit != null){
			clickUText.SetActive(false);
			tradeGUI = GameObject.Find("GodObject").GetComponent<GUIManager>().tradeGUI;
			tradeGUI.SetActive(true);
			tradeGUI.GetComponent<TradeGUI>().curUnit = tradeUnit;
			tradeGUI.GetComponent<TradeGUI>().nUnit = otherUnit;
		}
	}
}
