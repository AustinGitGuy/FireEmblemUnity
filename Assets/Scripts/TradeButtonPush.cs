using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeButtonPush : MonoBehaviour {

	public bool player;
	public int id;

	void Start(){
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		if(player){
			GameObject toAdd = transform.parent.GetComponentInParent<TradeGUI>().curUnit.GetComponent<EquipmentManager>().equipment[id];
			if(transform.parent.GetComponentInParent<TradeGUI>().nUnit.GetComponent<EquipmentManager>().addItem(toAdd)){
				transform.parent.GetComponentInParent<TradeGUI>().curUnit.GetComponent<EquipmentManager>().removeItem(id);
			}
		} 
		else {
			GameObject toAdd = transform.parent.GetComponentInParent<TradeGUI>().nUnit.GetComponent<EquipmentManager>().equipment[id];
			if(transform.parent.GetComponentInParent<TradeGUI>().curUnit.GetComponent<EquipmentManager>().addItem(toAdd)){
				transform.parent.GetComponentInParent<TradeGUI>().nUnit.GetComponent<EquipmentManager>().removeItem(id);
			}
		}
	}
}
