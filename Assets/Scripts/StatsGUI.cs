using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsGUI : MonoBehaviour {

	public GameObject curPlayer;

	Text pName;
	Text lvl;
	Text hp;
	Text str;
	Text skl;
	Text spd;
	Text lck;
	Text def;
	Text res;
	Text con;
	Text move;

	void Start(){
		pName = GameObject.Find("PStatsName").GetComponent<Text>();
		lvl = GameObject.Find("PStatsLvl").GetComponent<Text>();
		hp = GameObject.Find("PStatsHP").GetComponent<Text>();
		str = GameObject.Find("PStatsStr").GetComponent<Text>();
		skl = GameObject.Find("PStatsSkl").GetComponent<Text>();
		spd = GameObject.Find("PStatsSpd").GetComponent<Text>();
		lck = GameObject.Find("PStatsLck").GetComponent<Text>();
		def = GameObject.Find("PStatsDef").GetComponent<Text>();
		res = GameObject.Find("PStatsRes").GetComponent<Text>();
		con = GameObject.Find("PStatsCon").GetComponent<Text>();
		move = GameObject.Find("PStatsMove").GetComponent<Text>();
	}
		
	void Update(){
		if(curPlayer != null){
			pName.text = curPlayer.name;
			hp.text = curPlayer.GetComponent<Stats>().GetCurHP() + "/" + curPlayer.GetComponent<Stats>().baseHP;
			lvl.text = "Lvl: " + curPlayer.GetComponent<Stats>().level;
			str.text = "Str: " + curPlayer.GetComponent<Stats>().GetStrength();
			skl.text = "Skl: " + curPlayer.GetComponent<Stats>().GetSkill();
			spd.text = "Spd: " + curPlayer.GetComponent<Stats>().GetSpeed();
			lck.text = "Lck: " + curPlayer.GetComponent<Stats>().GetLuck();
			def.text = "Def: " + curPlayer.GetComponent<Stats>().GetDefense();
			res.text = "Res: " + curPlayer.GetComponent<Stats>().GetRes();
			con.text = "Con: " + curPlayer.GetComponent<Stats>().GetCon();
			move.text = "Move: " + curPlayer.GetComponent<Stats>().GetMovement();
		}
	}
}
