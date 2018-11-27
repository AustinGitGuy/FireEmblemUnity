using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	GameObject[] playerSpawns;

	void Start(){
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		playerSpawns = GameObject.FindGameObjectsWithTag("PlayerSpawn");
		for(int i = 0; i < playerSpawns.Length; i++){
			playerSpawns[i].SetActive(false);
		}
		GameObject.Find("GodObject").GetComponent<CheckTurnEnd>().gameStart = true;
		this.transform.parent.gameObject.SetActive(false);
	}
}
