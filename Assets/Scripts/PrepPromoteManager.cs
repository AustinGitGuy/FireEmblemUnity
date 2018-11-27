using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepPromoteManager : MonoBehaviour {

	public bool initiated = true;
	GameObject curUnit;
	GameObject promoteBG;

	void Start(){
		
	}

	void Update(){
		if(initiated){
			initiated = false;
			curUnit = GameObject.Find(transform.Find("EnterName").Find("NameText").gameObject.GetComponent<Text>().text);
			if(curUnit == null){
				Debug.Log("Invalid Name");
				GameObject.Find("GodObject").GetComponent<GUIManager>().prepMenu.SetActive(true);
				gameObject.SetActive(false);
				return;
			} 
			else {
				if(curUnit.GetComponent<Stats>().promoted){
					Debug.Log("Already Promoted");
					GameObject.Find("GodObject").GetComponent<GUIManager>().prepMenu.SetActive(true);
					gameObject.SetActive(false);
					return;
				}
				promoteBG = GameObject.Find("GodObject").GetComponent<GUIManager>().promoteBG;
				promoteBG.SetActive(true);
				promoteBG.GetComponent<PromotionBG>().InitPromoteGUI(curUnit);

				gameObject.SetActive(false);
			}
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			GameObject.Find("GodObject").GetComponent<GUIManager>().prepMenu.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
