using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvanceText : MonoBehaviour {

	void Start(){
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		GetComponentInParent<CharacterTalk>().Advance();
	}
}
