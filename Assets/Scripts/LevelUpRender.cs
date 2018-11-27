using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUpRender : MonoBehaviour {

	Text newLevel;
	Text newHP;
	Text newStrength;
	Text newSkill;
	Text newSpeed;
	Text newLuck;
	Text newDefense;
	Text newRes;

	void Start(){
		newLevel = transform.Find("NewLevel").gameObject.GetComponent<Text>();
		newHP = transform.Find("NewHP").gameObject.GetComponent<Text>();
		newStrength = transform.Find("NewStrength").gameObject.GetComponent<Text>();
		newSkill = transform.Find("NewSkill").gameObject.GetComponent<Text>();
		newSpeed = transform.Find("NewSpeed").gameObject.GetComponent<Text>();
		newLuck = transform.Find("NewLuck").gameObject.GetComponent<Text>();
		newDefense = transform.Find("NewDefense").gameObject.GetComponent<Text>();
		newRes = transform.Find("NewRes").gameObject.GetComponent<Text>();
	}

	public IEnumerator RenderUp(Stats player){
		if(newLevel == null){
			newLevel = transform.Find("NewLevel").gameObject.GetComponent<Text>();
		}
		if(newHP == null){
			newHP = transform.Find("NewHP").gameObject.GetComponent<Text>();
		}
		if(newStrength == null){
			newStrength = transform.Find("NewStrength").gameObject.GetComponent<Text>();
		}
		if(newSkill == null){
			newSkill = transform.Find("NewSkill").gameObject.GetComponent<Text>();
		}
		if(newSpeed == null){
			newSpeed = transform.Find("NewSpeed").gameObject.GetComponent<Text>();
		}
		if(newLuck == null){
			newLuck = transform.Find("NewLuck").gameObject.GetComponent<Text>();
		}
		if(newDefense == null){
			newDefense = transform.Find("NewDefense").gameObject.GetComponent<Text>();
		}
		if(newRes == null){
			newRes = transform.Find("NewRes").gameObject.GetComponent<Text>();
		}
		newLevel.text = "Level: " + player.level + "^";
		newHP.text = "HP: " + player.baseHP;
		newStrength.text = "Strength: " + player.baseStrength;
		newSkill.text = "Skill: " + player.baseSkill;
		newSpeed.text = "Speed: " + player.baseSpeed;
		newLuck.text = "Luck: " + player.baseLuck;
		newDefense.text = "Defense: " + player.baseDefense;
		newRes.text = "Res: " + player.baseRes;
		if(player.didLevel[0]){
			newHP.text += "^";
		}
		if(player.didLevel[1]){
			newStrength.text += "^";
		}
		if(player.didLevel[2]){
			newSkill.text += "^";
		}
		if(player.didLevel[3]){
			newSpeed.text += "^";
		}
		if(player.didLevel[4]){
			newLuck.text += "^";
		}
		if(player.didLevel[5]){
			newDefense.text += "^";
		}
		if(player.didLevel[6]){
			newRes.text += "^";
		}
		yield return new WaitForSeconds(2f);
		this.gameObject.SetActive(false);
	}
}
