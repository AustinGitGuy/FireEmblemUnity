using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GUIManager : MonoBehaviour {

	public GameObject combatGUI;
	public GameObject battleBackground;
	public GameObject levelUp;
	public GameObject equipGUI;
	public GameObject statsGUI;
	public GameObject prepMenu;
	public GameObject prepLevelInput;
	public GameObject prepPromoteInput;
	public GameObject promoteBG;
	public GameObject healGUI;
	public GameObject tradeGUI;
	public GameObject chooseUnits;
	public GameObject talkScene;
	public GameObject barracks;
	public GameObject viewSupport;
	public GameObject victory;
	public GameObject caravan;
	public GameObject merchant;

	public bool caravanOpen;
	public bool equipOpen;
	public bool shopOpen;

	void Start(){
		levelUp = GameObject.Find("LevelUp");
		levelUp.SetActive(false);
		combatGUI = GameObject.Find("CombatGUI");
		combatGUI.SetActive(false);
		battleBackground = GameObject.Find("BattleBackground");
		battleBackground.SetActive(false);
		equipGUI = GameObject.Find("EquipGUI");
		equipGUI.SetActive(false);
		statsGUI = GameObject.Find("StatsGUI");
		statsGUI.SetActive(false);
		prepMenu = GameObject.Find("PrepMenu");
		prepLevelInput = GameObject.Find("PrepLevelInput");
		prepLevelInput.SetActive(false);
		prepPromoteInput = GameObject.Find("PrepPromoteInput");
		prepPromoteInput.SetActive(false);
		promoteBG = GameObject.Find("PromoteBG");
		promoteBG.SetActive(false);
		healGUI = GameObject.Find("HealGUI");
		healGUI.SetActive(false);
		tradeGUI = GameObject.Find("TradeGUI");
		tradeGUI.SetActive(false);
		chooseUnits = GameObject.Find("ChooseUnits");
		chooseUnits.SetActive(false);
		talkScene = GameObject.Find("TalkScene");
		talkScene.SetActive(false);
		barracks = GameObject.Find("BarracksBG");
		barracks.SetActive(false);
		viewSupport = GameObject.Find("ViewUnits");
		viewSupport.SetActive(false);
		victory = GameObject.Find("Victory");
		victory.SetActive(false);
		caravan = GameObject.Find("Caravan");
		caravan.SetActive(false);
		merchant = GameObject.Find("MerchantScreen");
		merchant.SetActive(false);
	}

	void Update(){
		if(caravan.activeInHierarchy){
			caravanOpen = true;
		} 
		else {
			caravanOpen = false;
		}
		if(equipGUI.activeInHierarchy){
			equipOpen = true;
		} 
		else {
			equipOpen = false;
		}
		if(merchant.activeInHierarchy){
			shopOpen = true;
		} 
		else {
			shopOpen = false;
		}
	}
}
