using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveComplete : MonoBehaviour {

	GameObject godObject;
	GameObject[] players;

	public bool killEnemies;
	public int id;

	public string[] sceneLines;
	public string[] sceneNames;

	void Start(){
		godObject = GameObject.Find("GodObject");
	}

	void Update(){
		if((killEnemies && godObject.GetComponent<CheckTurnEnd>().enemiesDefeated) || !killEnemies){
			CheckMapEnd();
		}
	}

	void CheckMapEnd(){
		players = GameObject.FindGameObjectsWithTag("Ally");
		for(int i = 0; i < players.Length; i++){
			if(players[i].transform.position.x == this.transform.position.x && players[i].transform.position.y == this.transform.position.y){
				if(godObject.GetComponent<ChaptersCleared>().chapterCleared >= id){
					LoadVictory();
				} 
				else {
					LoadCutscene();
				}
			}
		}
	}

	void LoadVictory(){
		godObject.GetComponent<GUIManager>().victory.SetActive(true);
	}

	void LoadCutscene(){

	}
}
