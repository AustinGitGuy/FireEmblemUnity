using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DanceChar : MonoBehaviour {

	GameObject[] characters;
	GameObject otherUnit;
	GameObject player;

	GameObject dance;

	void Start(){
		player = transform.parent.gameObject;
		dance = transform.parent.Find("Dance(Clone)").gameObject;
		characters = GameObject.FindGameObjectsWithTag("Character");
		for(int i = 0; i < characters.Length; i++){
			characters[i] = characters[i].transform.parent.gameObject;
		}
	}

	void OnMouseDown(){
		Dance();
	}

	void Dance(){
		for(int i = 0; i < characters.Length; i++){
			if(characters[i].transform.position == this.gameObject.transform.position){
				otherUnit = characters[i];
			}
		}
		player.GetComponent<Stats>().exp += 10;
		player.GetComponent<Stats>().CheckLevelUp();
		otherUnit.GetComponent<Movement>().turnEnd = false;
		dance.GetComponent<DanceClicked>().DestroySquares();
	}
}
