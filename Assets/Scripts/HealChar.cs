using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealChar : MonoBehaviour {

	GameObject[] characters;
	GameObject otherUnit;
	GameObject player;
	GameObject heal;

	Text pName;
	Text oName;
	Text pHeal;
	Text oHealth;

	bool inHeal;

	int healAmount;

	void Start(){
		heal = transform.parent.Find("Heal(Clone)").gameObject;
		player = transform.parent.gameObject;
		characters = GameObject.FindGameObjectsWithTag("Character");
		for(int i = 0; i < characters.Length; i++){
			characters[i] = characters[i].transform.parent.gameObject;
		}
	}

	void Update(){
		if(inHeal){
			if(Input.GetKeyDown(KeyCode.E)){
				DoHeal();
			}
		}
	}

	void OnMouseDown(){
		Heal();
	}

	void DoHeal(){
		otherUnit.GetComponent<Stats>().IncreaseHP(healAmount);
		player.GetComponent<Stats>().exp += 20;
		player.GetComponent<Stats>().CheckLevelUp();
		heal.GetComponent<AttackClicked>().DestroySquares();
	}

	void Heal(){
		for(int i = 0; i < characters.Length; i++){
			if(characters[i].transform.position == this.gameObject.transform.position){
				otherUnit = characters[i];
			}
		}
		inHeal = true;
		GameObject.Find("GodObject").GetComponent<GUIManager>().healGUI.SetActive(true);
		pName = GameObject.Find("HPlayerName").GetComponent<Text>();
		oName = GameObject.Find("HEnemyName").GetComponent<Text>();
		pHeal = GameObject.Find("PlayerHeal").GetComponent<Text>();
		oHealth = GameObject.Find("EnemyHealth").GetComponent<Text>();
		pName.text = player.name;
		oName.text = otherUnit.name;
		oHealth.text = "Health: " + otherUnit.GetComponent<Stats>().GetCurHP().ToString();
		healAmount = player.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().healAmount + player.GetComponent<Stats>().GetStrength();
		if(healAmount + otherUnit.GetComponent<Stats>().GetCurHP() > otherUnit.GetComponent<Stats>().baseHP){
			healAmount = otherUnit.GetComponent<Stats>().baseHP - otherUnit.GetComponent<Stats>().GetCurHP();
		}
		pHeal.text = "Healing For: " + healAmount.ToString();
	}
}
