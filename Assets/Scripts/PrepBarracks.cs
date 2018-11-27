using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepBarracks : MonoBehaviour {
	
	void Start(){
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		GameObject.Find("GodObject").GetComponent<GUIManager>().barracks.SetActive(true);
		this.transform.parent.gameObject.SetActive(false);
	}
}
