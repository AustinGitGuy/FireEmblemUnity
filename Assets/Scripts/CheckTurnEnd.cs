using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckTurnEnd : MonoBehaviour {

	public bool gameStart;

	public bool allyTurn = true;
	public bool enemyTurn = false;
	public bool neutralTurn = false;

	public bool enemiesDefeated = false;

	GameObject[] allies;
	GameObject[] enemies;
	GameObject[] neutrals;
	GameObject[] characters;

	int seed;

	Text curTurn;

	void Start(){
		curTurn = GameObject.Find("CurrentTurn").GetComponent<Text>();
		seed = GameObject.Find("GodObject").GetComponent<MapGeneration>().seed;
		allies = GameObject.FindGameObjectsWithTag("Ally");
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		neutrals = GameObject.FindGameObjectsWithTag("Neutral");
		characters = GameObject.FindGameObjectsWithTag("Character");
		for(int i = 0; i < characters.Length; i++){
			characters[i] = characters[i].transform.parent.gameObject;
		}
	}

	void MoveCharacters(){
		Random.InitState(seed);
		for(int i = 0; i < characters.Length; i++){
			float yPos;
			float xPos;
			xPos = Random.Range(1, 16);
			yPos = Random.Range(1, 10);
			for(int c = 0; c < characters.Length; c++){
				while(xPos == characters[c].transform.position.x && characters[c].gameObject.name != characters[i].gameObject.name) xPos = Random.Range(1, 16);
				characters[i].transform.position = new Vector3(xPos, yPos, -1);
			}
		}
	}

	void Update(){
		allies = GameObject.FindGameObjectsWithTag("Ally");
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		neutrals = GameObject.FindGameObjectsWithTag("Neutral");
		characters = GameObject.FindGameObjectsWithTag("Character");
		for(int i = 0; i < characters.Length; i++){
			characters[i] = characters[i].transform.parent.gameObject;
		}
		if(SceneManager.GetActiveScene().name != "WorldMap"){
			if(allyTurn){
				CheckAllyTurnEnd();
				curTurn.text = "Your Turn";
			}
			if(enemyTurn){
				CheckEnemyTurnEnd();
				curTurn.text = "Enemy Turn";
			}
			if(neutralTurn){
				CheckNeutralTurnEnd();
				curTurn.text = "Neutral Turn";
			}
		} 
		else {
			curTurn.text = "World Map";
		}
		CheckEscape();
		CheckBackToMenu();
		CheckAllyDead();
		CheckEnemyDead();
	}

	void CheckBackToMenu(){
		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.L)){
			gameStart = false;
			GetComponent<GUIManager>().prepMenu.SetActive(true);
		}
	}

	void CheckAllyTurnEnd(){
		int index = 0;
		for(int i = 0; i < allies.Length; i++){
			if(allies[i].GetComponent<Movement>().turnEnd || allies[i].GetComponent<Movement>().dead) index++;
		}
		if(index == allies.Length){
			allyTurn = false;
			enemyTurn = true;
			for(int i = 0; i < allies.Length; i++){
				allies[i].GetComponent<Movement>().turnEnd = false;
			}
		}
	}

	void CheckEnemyTurnEnd(){
		int index = 0;
		for(int i = 0; i < enemies.Length; i++){
			if(enemies[i].GetComponent<Movement>().turnEnd || enemies[i].GetComponent<Movement>().dead) index++;
		}
		if(index == enemies.Length){
			enemyTurn = false;
			neutralTurn = true;
			for(int i = 0; i < enemies.Length; i++){
				enemies[i].GetComponent<Movement>().turnEnd = false;
			}
		}
	}

	void CheckNeutralTurnEnd(){
		int index = 0;
		for(int i = 0; i < neutrals.Length; i++){
			if(neutrals[i].GetComponent<Movement>().turnEnd || neutrals[i].GetComponent<Movement>().dead) index++;
		}
		if(index == neutrals.Length){
			neutralTurn = false;
			allyTurn = true;
			for(int i = 0; i < neutrals.Length; i++){
				neutrals[i].GetComponent<Movement>().turnEnd = false;
			}
		}
	}

	void CheckEscape(){
		for(int i = 0; i < characters.Length; i++){
			GameObject attack = null;
			if(characters[i].transform.Find("Attack(Clone)") != null) attack = characters[i].transform.Find("Attack(Clone)").gameObject;
			if(attack != null){
				if(attack.GetComponent<AttackClicked>().clicked && Input.GetKeyDown(KeyCode.Escape)){
					attack.GetComponent<AttackClicked>().BackToMenu();
				}
			}
			GameObject equip = null;
			if(characters[i].transform.Find("Equip(Clone)") != null) equip = characters[i].transform.Find("Equip(Clone)").gameObject;
			if(equip != null){
				if(equip.GetComponent<EquipClicked>().clicked && Input.GetKeyDown(KeyCode.Escape)){
					equip.GetComponent<EquipClicked>().BackToMenu();
				}
			}
			GameObject heal = null;
			if(characters[i].transform.Find("Heal(Clone)") != null) equip = characters[i].transform.Find("Heal(Clone)").gameObject;
			if(heal != null){
				if(heal.GetComponent<HealClicked>().clicked && Input.GetKeyDown(KeyCode.Escape)){
					heal.GetComponent<HealClicked>().BackToMenu();
				}
			}
			GameObject dance = null;
			if(characters[i].transform.Find("Dance(Clone)") != null) equip = characters[i].transform.Find("Dance(Clone)").gameObject;
			if(dance != null){
				if(equip.GetComponent<DanceClicked>().clicked && Input.GetKeyDown(KeyCode.Escape)){
					equip.GetComponent<DanceClicked>().BackToMenu();
				}
			}
			GameObject trade = null;
			if(characters[i].transform.Find("Trade(Clone)") != null) equip = characters[i].transform.Find("Trade(Clone)").gameObject;
			if(trade != null){
				if(trade.GetComponent<TradeClicked>().clicked && Input.GetKeyDown(KeyCode.Escape)){
					trade.GetComponent<TradeClicked>().BackToMenu();
				}
			}
			GameObject caravan = null;
			if(characters[i].transform.Find("Caravan(Clone)") != null) equip = characters[i].transform.Find("Caravan(Clone)").gameObject;
			if(caravan != null){
				if(caravan.GetComponent<CaravanClicked>().clicked && Input.GetKeyDown(KeyCode.Escape)){
					caravan.GetComponent<CaravanClicked>().BackToMenu();
				}
			}
		}
	}

	void CheckAllyDead(){
		int test = 0;
		for(int i = 0; i < allies.Length; i++){
			if(allies[i].GetComponent<Movement>().dead) test++;
		}
		if(test == allies.Length){

		}
	}

	void CheckEnemyDead(){
		int test = 0;
		for(int i = 0; i < enemies.Length; i++){
			if(enemies[i].GetComponent<Movement>().dead) test++;
		}
		if(test == enemies.Length){
			enemiesDefeated = true;
		}
	}
}
