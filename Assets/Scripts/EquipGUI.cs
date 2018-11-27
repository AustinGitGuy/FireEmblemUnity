using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EquipGUI : MonoBehaviour {

	Text curEquip;
	GameObject[] equips;
	GameObject[] duras;

	public GameObject[] actualEquips;
	public GameObject curUnit;

	public void Start(){
		actualEquips = new GameObject[5];
		curEquip = GameObject.Find("PEquipName").GetComponent<Text>();
		equips = new GameObject[5];
		duras = new GameObject[5];
		equips[0] = GameObject.Find("EquipName1");
		equips[1] = GameObject.Find("EquipName2");
		equips[2] = GameObject.Find("EquipName3");
		equips[3] = GameObject.Find("EquipName4");
		equips[4] = GameObject.Find("EquipName5");

		duras[0] = GameObject.Find("EquipDura1");
		duras[1] = GameObject.Find("EquipDura2");
		duras[2] = GameObject.Find("EquipDura3");
		duras[3] = GameObject.Find("EquipDura4");
		duras[4] = GameObject.Find("EquipDura5");
	}

	void Update(){
		curEquip.text = curUnit.GetComponent<EquipmentManager>().getCurEquipment().name;
		actualEquips = curUnit.GetComponent<EquipmentManager>().equipment;
		for(int i = 0; i < equips.Length; i++){
			if(actualEquips[i] != null){
				equips[i].GetComponent<Text>().text = actualEquips[i].name;
				duras[i].GetComponent<Text>().text = actualEquips[i].GetComponent<Equipment>().curUses.ToString();
			}
		}
	}
}
