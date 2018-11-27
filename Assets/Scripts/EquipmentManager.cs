using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

	public GameObject[] equipment;
	public GameObject noEquipment;

	public int curEquipNum;

	public GameObject getCurEquipment(){
		if(curEquipNum == -1){
			return noEquipment;
		}
		return equipment[curEquipNum];
	}

	public int getEmptySpace(){
		for(int i = 0; i < equipment.Length; i++){
			if(equipment[i] == null){
				return i;
			}
		}
		return -1;
	}

	public int getNextEquip(){
		for(int i = 0; i < equipment.Length; i++){
			if(equipment[i] != null && equipment[i].GetComponent<Equipment>().wepType != Equipment.Type.Consumable){
				return i;
			}
		}
		return -1;
	}

	public bool addItem(GameObject item){
		if(getEmptySpace() == -1){
			return false;
		}
		equipment[getEmptySpace()] = item;
		return true;
	}

	public void removeItem(int num){
		equipment[num] = null;
	}

	void Update(){
		for(int i = 0; i < equipment.Length; i++){
			if(equipment[i] != null){
				if(equipment[i].GetComponent<Equipment>().curUses <= 0){
					removeItem(i);
				}
			}
		}
		if(getCurEquipment() == null){
			curEquipNum = getNextEquip();
		}
	}
}
