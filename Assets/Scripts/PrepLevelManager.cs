using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepLevelManager : MonoBehaviour {

	public bool initiated = false;
	int numTimes;
	GameObject curUnit;

	void Update(){
		if(initiated){
			initiated = false;
			curUnit = GameObject.Find(transform.Find("EnterName").Find("NameText").gameObject.GetComponent<Text>().text);
			numTimes = int.Parse((transform.Find("EnterNum").Find("NumberText").gameObject.GetComponent<Text>().text));
			if(numTimes < 0){
				GameObject.Find("GodObject").GetComponent<GUIManager>().prepMenu.SetActive(true);
				transform.parent.gameObject.SetActive(false);
				return;
			}
			if(curUnit == null){
				GameObject.Find("GodObject").GetComponent<GUIManager>().prepMenu.SetActive(true);
				transform.parent.gameObject.SetActive(false);
				return;
			} 
			else {
				curUnit.GetComponent<Stats>().MassLevel(numTimes);
			}
			GameObject.Find("GodObject").GetComponent<GUIManager>().prepMenu.SetActive(true);
			transform.parent.gameObject.SetActive(false);
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			GameObject.Find("GodObject").GetComponent<GUIManager>().prepMenu.SetActive(true);
			transform.parent.gameObject.SetActive(false);
		}
	}
}
