using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepPromote : MonoBehaviour {

	void Start(){
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		GameObject.Find("GodObject").GetComponent<GUIManager>().prepPromoteInput.SetActive(true);
		this.transform.parent.gameObject.SetActive(false);
	}
}
