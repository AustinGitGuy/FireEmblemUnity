using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipButtonPush : MonoBehaviour {

	public int ID;

	GameObject godObject;

	void Start(){
		godObject = GameObject.Find("GodObject");
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		if(transform.parent.GetComponentInParent<EquipGUI>().curUnit.GetComponent<EquipmentManager>().equipment[ID] != null){
			if(godObject.GetComponent<GUIManager>().caravanOpen){
				godObject.GetComponent<GUIManager>().caravan.GetComponent<CaravanManager>().AddItem(
					transform.parent.GetComponentInParent<EquipGUI>().curUnit.GetComponent<EquipmentManager>().equipment[ID]);
				transform.parent.GetComponentInParent<EquipGUI>().curUnit.GetComponent<EquipmentManager>().equipment[ID] = null;
			} 
			else {
				if(transform.parent.GetComponentInParent<EquipGUI>().curUnit.GetComponent<EquipmentManager>().equipment[ID].GetComponent<Equipment>().wepType == Equipment.Type.Consumable){
					transform.parent.GetComponentInParent<EquipGUI>().curUnit.GetComponent<Stats>().IncreaseHP(transform.parent.GetComponentInParent<EquipGUI>().curUnit.
					                                                                                       GetComponent<EquipmentManager>().equipment[ID].GetComponent<Equipment>().healAmount);
					transform.parent.GetComponentInParent<EquipGUI>().curUnit.GetComponent<EquipmentManager>().equipment[ID].GetComponent<Equipment>().curUses--;
				}
				else {
					transform.parent.GetComponentInParent<EquipGUI>().curUnit.GetComponent<EquipmentManager>().curEquipNum = ID;
				}
			}
		}
	}
}
