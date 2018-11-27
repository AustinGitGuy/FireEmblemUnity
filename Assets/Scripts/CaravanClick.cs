using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaravanClick : MonoBehaviour {

	public GameObject godObject;
	GameObject playerCharacters;
	int id;
	GameObject curUnit;

	void Start(){
		godObject = GameObject.Find("GodObject");
		playerCharacters = GameObject.Find("PlayerCharacters");
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
		id = int.Parse(this.name.Substring(4, this.name.Length - 4));
	}

	void OnButtonClick(){
		if(godObject.GetComponent<GUIManager>().equipOpen){
			//Add it to the unit's equipment and remove it from the caravan
			curUnit = godObject.GetComponent<GUIManager>().equipGUI.GetComponent<EquipGUI>().curUnit;
			curUnit.GetComponent<EquipmentManager>().addItem(GetComponentInParent<CaravanDraw>().items[id - 1]);
			playerCharacters.GetComponent<CaravanManager>().DeleteItem((int)id - 1);
		} 
		else if(godObject.GetComponent<GUIManager>().shopOpen){
			playerCharacters.GetComponent<CaravanManager>().gold += GetComponentInParent<CaravanDraw>().items[id - 1].GetComponent<Equipment>().worth / 2;
			playerCharacters.GetComponent<CaravanManager>().DeleteItem((int)id - 1);
		}
		else {
			//Open a menu on what to do with the item
		}
	}
}
