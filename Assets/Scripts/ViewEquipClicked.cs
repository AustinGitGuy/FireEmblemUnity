using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewEquipClicked : MonoBehaviour {

	GameObject support;
	GameObject trade;

	GameObject equipGUI;

	void Start(){
		support = GameObject.Find("Support(Clone)");
		trade = GameObject.Find("Trade(Clone");
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		support.SetActive(false);
		trade.SetActive(false);
		equipGUI = GameObject.Find("GodObject").GetComponent<GUIManager>().equipGUI;
		equipGUI.SetActive(true);
		equipGUI.GetComponent<EquipGUI>().curUnit = transform.parent.GetComponentInParent<UnitMenu>().barracksUnits[GetComponentInParent<ViewUnitMenu>().id];
		this.gameObject.SetActive(false);
	}
}
