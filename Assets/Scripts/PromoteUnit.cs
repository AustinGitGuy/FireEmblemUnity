using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromoteUnit : MonoBehaviour {

	public int ID;

	void Start(){
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		transform.parent.gameObject.GetComponent<PromotionBG>().PromoteUnit(ID);
	}
}
