using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TradeGUI : MonoBehaviour {

	GameObject[] pEquips;
	GameObject[] pDuras;
	GameObject[] nEquips;
	GameObject[] nDuras;

	public GameObject[] pActualEquips;
	public GameObject[] nActualEquips;
	public GameObject curUnit;
	public GameObject nUnit;

	public void Start(){
		pActualEquips = new GameObject[5];
		nActualEquips = new GameObject[5];

		pEquips = new GameObject[5];
		pDuras = new GameObject[5];

		nEquips = new GameObject[5];
		nDuras = new GameObject[5];

		pEquips[0] = GameObject.Find("PEquipName1");
		pEquips[1] = GameObject.Find("PEquipName2");
		pEquips[2] = GameObject.Find("PEquipName3");
		pEquips[3] = GameObject.Find("PEquipName4");
		pEquips[4] = GameObject.Find("PEquipName5");

		pDuras[0] = GameObject.Find("PEquipDura1");
		pDuras[1] = GameObject.Find("PEquipDura2");
		pDuras[2] = GameObject.Find("PEquipDura3");
		pDuras[3] = GameObject.Find("PEquipDura4");
		pDuras[4] = GameObject.Find("PEquipDura5");

		nEquips[0] = GameObject.Find("NEquipName1");
		nEquips[1] = GameObject.Find("NEquipName2");
		nEquips[2] = GameObject.Find("NEquipName3");
		nEquips[3] = GameObject.Find("NEquipName4");
		nEquips[4] = GameObject.Find("NEquipName5");

		nDuras[0] = GameObject.Find("NEquipDura1");
		nDuras[1] = GameObject.Find("NEquipDura2");
		nDuras[2] = GameObject.Find("NEquipDura3");
		nDuras[3] = GameObject.Find("NEquipDura4");
		nDuras[4] = GameObject.Find("NEquipDura5");
	}

	void Update(){
		pActualEquips = curUnit.GetComponent<EquipmentManager>().equipment;
		for(int i = 0; i < pEquips.Length; i++){
			if(pActualEquips[i] != null){
				pEquips[i].GetComponent<Text>().text = pActualEquips[i].name;
				pDuras[i].GetComponent<Text>().text = pActualEquips[i].GetComponent<Equipment>().curUses.ToString();
			}
			else {
				pEquips[i].GetComponent<Text>().text = "";
				pDuras[i].GetComponent<Text>().text = "";
			}
		}

		nActualEquips = nUnit.GetComponent<EquipmentManager>().equipment;
		for(int i = 0; i < nEquips.Length; i++){
			if(nActualEquips[i] != null){
				nEquips[i].GetComponent<Text>().text = nActualEquips[i].name;
				nDuras[i].GetComponent<Text>().text = nActualEquips[i].GetComponent<Equipment>().curUses.ToString();
			} 
			else {
				nEquips[i].GetComponent<Text>().text = "";
				nDuras[i].GetComponent<Text>().text = "";
			}
		}
	}
}
