using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PromotionBG : MonoBehaviour {

	public GameObject curUnit;

	Text unitName;
	Text promOne;
	Text promTwo;
	Image promSprite;

	int hpDiff;
	int strDiff;
	int sklDiff;
	int spdDiff;
	int lckDiff;
	int defDiff;
	int resDiff;
	int moveDiff;
	int conDiff;

	void Start(){
		unitName = transform.Find("PromName").gameObject.GetComponent<Text>();
		promOne = transform.Find("PromOne").gameObject.GetComponent<Text>();
		promTwo = transform.Find("PromTwo").gameObject.GetComponent<Text>();
		promSprite = transform.Find("PromSprite").gameObject.GetComponent<Image>();
	}

	void Update(){
		unitName.text = curUnit.name;
		promOne.text = curUnit.GetComponent<ClassManager>().unitClass.promote1.name;
		promTwo.text = curUnit.GetComponent<ClassManager>().unitClass.promote2.name;
		promSprite.sprite = curUnit.GetComponent<SpriteRenderer>().sprite;
	}

	public void InitPromoteGUI(GameObject one){
		curUnit = one;
	}

	public void PromoteUnit(int id){
		if(id == 0){
			CalculateDiff(curUnit.GetComponent<ClassManager>().unitClass, curUnit.GetComponent<ClassManager>().unitClass.promote1.GetComponent<Class>());
			curUnit.GetComponent<ClassManager>().unitClass = curUnit.GetComponent<ClassManager>().unitClass.promote1.GetComponent<Class>();
		}
		if(id == 1){
			if(curUnit.GetComponent<ClassManager>().unitClass.promote2.name == "No Option"){
				return;
			}
			CalculateDiff(curUnit.GetComponent<ClassManager>().unitClass, curUnit.GetComponent<ClassManager>().unitClass.promote2.GetComponent<Class>());
			curUnit.GetComponent<ClassManager>().unitClass = curUnit.GetComponent<ClassManager>().unitClass.promote2.GetComponent<Class>();
		}
		curUnit.GetComponent<Stats>().level = 1;
		curUnit.GetComponent<Stats>().promoted = true;
		curUnit.GetComponent<Stats>().baseHP += hpDiff + 2;
		curUnit.GetComponent<Stats>().baseStrength += strDiff + 2;
		curUnit.GetComponent<Stats>().baseSkill += sklDiff + 2;
		curUnit.GetComponent<Stats>().baseSpeed += spdDiff + 2;
		curUnit.GetComponent<Stats>().baseLuck += lckDiff + 2;
		curUnit.GetComponent<Stats>().baseDefense += defDiff + 2;
		curUnit.GetComponent<Stats>().baseRes += resDiff + 2;
		curUnit.GetComponent<Stats>().baseMovement += moveDiff;
		curUnit.GetComponent<Stats>().baseCon += conDiff;
		GameObject.Find("GodObject").GetComponent<GUIManager>().prepMenu.SetActive(true);
		this.gameObject.SetActive(false);
	}

	void CalculateDiff(Class cBase, Class cProm){
		hpDiff = cProm.baseHP - cBase.baseHP;
		strDiff = cProm.baseStr - cBase.baseStr;
		sklDiff = cProm.baseSkl - cBase.baseSkl;
		spdDiff = cProm.baseSpd - cBase.baseSpd;
		lckDiff = cProm.baseLck - cBase.baseLck;
		defDiff = cProm.baseDef - cBase.baseDef;
		resDiff = cProm.baseRes - cBase.baseRes;
		moveDiff = cProm.baseMove - cBase.baseMove;
		conDiff = cProm.baseCon - cBase.baseCon;
	}
}
