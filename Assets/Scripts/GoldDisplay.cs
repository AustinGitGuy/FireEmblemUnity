using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour {

	GameObject playerCharacters;
	Text goldText;

	void Start(){
		playerCharacters = GameObject.Find("PlayerCharacters");
		goldText = transform.Find("GoldText").GetComponent<Text>();
	}

	void Update(){
		goldText.text = "Gold: " + playerCharacters.GetComponent<CaravanManager>().gold;
	}
}
