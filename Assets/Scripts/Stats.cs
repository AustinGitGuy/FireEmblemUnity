using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour {

	GameObject levelUp;

	public int level;
	public int baseHP;
	public int baseStrength;
	public int baseSkill;
	public int baseSpeed;
	public int baseLuck;
	public int baseDefense;
	public int baseRes;
	public int baseCon;
	public int baseMovement;

	public bool promoted;

	int curHP;
	public int exp;

	public bool[] didLevel;

	public int editorLevel;

	void Start(){
		didLevel = new bool[7];
		curHP = baseHP;
		Random.InitState((int)System.DateTime.Now.Ticks + (int)(Random.value * 100f));
	}

	void Update(){
		if(editorLevel > 0){
			MassLevel(editorLevel);
			editorLevel = 0;
		}
		if(levelUp == null){
			levelUp = GameObject.Find("GodObject").GetComponent<GUIManager>().levelUp;
		}
	}

	public int GetCurHP(){
		return this.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().hpBuff + curHP;
	}

	public void SetHP(int num){
		curHP = num;
	}

	public void DecreaseHP(int num){
		curHP -= num;
	}

	public void IncreaseHP(int num){
		curHP += num;
	}

	public void ResetHP(){
		curHP = baseHP;
	}

	public int GetStrength(){
		return this.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().strBuff + baseStrength;
	}

	public int GetDefense(){
		return this.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().defBuff + baseDefense;
	}

	public int GetRes(){
		return this.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().resBuff + baseRes;
	}

	public int GetMovement(){
		return this.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().moveBuff + baseMovement;
	}

	public int GetSkill(){
		return this.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().sklBuff + baseSkill;
	}

	public int GetLuck(){
		return this.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().lckBuff +  baseLuck;
	}

	public int GetCon(){
		return this.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().conBuff + baseCon;
	}

	public int GetSpeed(){
		return this.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().spdBuff + baseSpeed;
	}

	public int GetEffectiveLevel(){
		if(promoted){
			return level + 20;
		}
		return level;
	}

	public void CheckLevelUp(){
		Random.InitState((int)System.DateTime.Now.Ticks + (int)(Random.value * 100f));
		if(exp >= 100 && level < 20){
			levelUp.SetActive(true);
			level++;
			exp -= 100;
			int growths = Random.Range(1, 100);
			if(growths <= GetComponent<ClassManager>().unitClass.hpGrowth){
				baseHP++;
				curHP = baseHP;
				didLevel[0] = true;
			} 
			else {
				didLevel[0] = false;
			}
			if(growths <= GetComponent<ClassManager>().unitClass.strGrowth){
				baseStrength++;
				didLevel[1] = true;
			}
			else {
				didLevel[1] = false;
			}
			if(growths <= GetComponent<ClassManager>().unitClass.sklGrowth){
				baseSkill++;
				didLevel[2] = true;
			}
			else {
				didLevel[2] = false;
			}
			if(growths <= GetComponent<ClassManager>().unitClass.spdGrowth){
				baseSpeed++;
				didLevel[3] = true;
			}
			else {
				didLevel[3] = false;
			}
			if(growths <= GetComponent<ClassManager>().unitClass.lckGrowth){
				baseLuck++;
				didLevel[4] = true;
			}
			else {
				didLevel[4] = false;
			}
			if(growths <= GetComponent<ClassManager>().unitClass.defGrowth){
				baseDefense++;
				didLevel[5] = true;
			}
			else {
				didLevel[5] = false;
			}
			if(growths <= GetComponent<ClassManager>().unitClass.resGrowth){
				baseRes++;
				didLevel[6] = true;
			}
			else {
				didLevel[6] = false;
			}
			StartCoroutine(levelUp.GetComponent<LevelUpRender>().RenderUp(this));
		}
	}

	public void MassLevel(int times){
		for(int i = 0; i < times; i++){
			if(level >= 20){
				return;
			}
			Random.InitState((int)System.DateTime.Now.Ticks + (int)(Random.value * 100f));
			int growths = Random.Range(1, 100);
			level++;
			if(growths <= GetComponent<ClassManager>().unitClass.hpGrowth){
				baseHP++;
				curHP = baseHP;
				didLevel[0] = true;
			} 
			else {
				didLevel[0] = false;
			}
			if(growths <= GetComponent<ClassManager>().unitClass.strGrowth){
				baseStrength++;
				didLevel[1] = true;
			}
			else {
				didLevel[1] = false;
			}
			if(growths <= GetComponent<ClassManager>().unitClass.sklGrowth){
				baseSkill++;
				didLevel[2] = true;
			}
			else {
				didLevel[2] = false;
			}
			if(growths <= GetComponent<ClassManager>().unitClass.spdGrowth){
				baseSpeed++;
				didLevel[3] = true;
			}
			else {
				didLevel[3] = false;
			}
			if(growths <= GetComponent<ClassManager>().unitClass.lckGrowth){
				baseLuck++;
				didLevel[4] = true;
			}
			else {
				didLevel[4] = false;
			}
			if(growths <= GetComponent<ClassManager>().unitClass.defGrowth){
				baseDefense++;
				didLevel[5] = true;
			}
			else {
				didLevel[5] = false;
			}
			if(growths <= GetComponent<ClassManager>().unitClass.resGrowth){
				baseRes++;
				didLevel[6] = true;
			}
			else {
				didLevel[6] = false;
			}
		}
	}
}
