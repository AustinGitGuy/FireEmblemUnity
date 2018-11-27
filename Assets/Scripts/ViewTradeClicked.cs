using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTradeClicked : MonoBehaviour {

	GameObject support;
	GameObject equip;

	void Start(){
		support = GameObject.Find("Support(Clone)");
		equip = GameObject.Find("Equip(Clone");
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		transform.parent.GetComponentInParent<UnitMenu>().tradeUnit = transform.parent.GetComponentInParent<UnitMenu>().barracksUnits[GetComponentInParent<ViewUnitMenu>().id];
		transform.parent.GetComponentInParent<UnitMenu>().clickUText.SetActive(true);
		support.SetActive(false);
		equip.SetActive(false);
		transform.parent.GetComponentInParent<UnitMenu>().otherUnit = null;
		gameObject.SetActive(false);
	}
}
