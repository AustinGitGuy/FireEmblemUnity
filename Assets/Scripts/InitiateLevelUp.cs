using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitiateLevelUp : MonoBehaviour {

	void Start(){
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		transform.parent.gameObject.GetComponent<PrepLevelManager>().initiated = true;
	}
}
