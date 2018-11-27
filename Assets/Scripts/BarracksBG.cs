using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksBG : MonoBehaviour {
	
	void Start(){
		
	}

	void Update(){
		this.transform.Find("BarracksMenu").gameObject.SetActive(true);
		if(Input.GetKeyDown(KeyCode.Escape)){
			GameObject.Find("GodObject").GetComponent<GUIManager>().prepMenu.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}
}
