using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsDisplay : MonoBehaviour {

	GameObject StatsGUI;

	void Start(){
		StatsGUI = GameObject.Find("GodObject").GetComponent<GUIManager>().statsGUI;
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(1)){
			StatsGUI.SetActive(true);
			StatsGUI.GetComponent<StatsGUI>().curPlayer = this.gameObject;
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			StatsGUI.SetActive(false);
		}
	}
}
