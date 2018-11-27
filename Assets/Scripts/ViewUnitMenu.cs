using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewUnitMenu : MonoBehaviour {

	public int id;

	public GameObject tradePrefab;
	GameObject trade;

	public GameObject supportPrefab;
	GameObject support;

	public GameObject equipPrefab;
	GameObject equip;

	void Start(){
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		if(!GetComponentInParent<UnitMenu>().menu){
			OpenMenu();
		} 
		else {
			GetComponentInParent<UnitMenu>().otherUnit = GetComponentInParent<UnitMenu>().barracksUnits[id];
		}
	}

	void OpenMenu(){
		GetComponentInParent<UnitMenu>().menu = true;
		trade = Instantiate(tradePrefab, transform) as GameObject;
		trade.transform.localPosition = new Vector3(72.7f, 37.1f, -1.5f);

		equip = Instantiate(equipPrefab, transform) as GameObject;
		equip.transform.localPosition = new Vector3(72.7f, 65f, -1.5f);

		support = Instantiate(supportPrefab, transform) as GameObject;
		support.transform.localPosition = new Vector3(0f, -77.41f, -1.5f);
	}

	public void ExitMenu(){
		GameObject.Find("GodObject").GetComponent<GUIManager>().equipGUI.SetActive(false);
		GameObject.Find("GodObject").GetComponent<GUIManager>().tradeGUI.SetActive(false);
		if(trade != null)Destroy(trade);
		if(support != null)Destroy(support);
		if(equip != null) Destroy(equip);	
	}
}
