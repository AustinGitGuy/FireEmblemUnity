using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class AttackChar : MonoBehaviour {

	GameObject combatGUI;
	GameObject battlerBackground;
	GameObject enemy;
	GameObject player;

	GameObject missed;
	GameObject crit;

	GameObject pHealthBar;
	GameObject eHealthBar;

	Text pName;
	Text pHit;
	Text pDamage;
	Text pCrit;
	Text eName;
	Text eHit;
	Text eDamage;
	Text eCrit;	

	Text pBattler;
	Text eBattler;
	Text eBattlerHit;
	Text eBattlerCrit;
	Text eBattlerDamage;
	Text pBattlerHit;
	Text pBattlerCrit;
	Text pBattlerDamage;

	Text eExp;
	Text pExp;

	float pHitNum;
	float pDamageNum;
	float pCritNum;

	float eHitNum;
	float eDamageNum;
	float eCritNum;

	int pNumAttacks;
	int eNumAttacks;

	GameObject attack;
	GameObject[] characters;

	bool inCombat;

	bool killedPlayer;
	bool killedEnemy;

	bool disabler;

	void Start(){
		player = transform.parent.gameObject;
		combatGUI = GameObject.Find("GodObject").GetComponent<GUIManager>().combatGUI;
		battlerBackground = GameObject.Find("GodObject").GetComponent<GUIManager>().battleBackground;
		attack = transform.parent.Find("Attack(Clone)").gameObject;
		characters = GameObject.FindGameObjectsWithTag("Character");
		for(int i = 0; i < characters.Length; i++){
			characters[i] = characters[i].transform.parent.gameObject;
		}
		Random.InitState((int)System.DateTime.Now.Ticks + (int)(Random.value * 100f));
	}

	void Update(){
		if(inCombat){
			if(Input.GetKeyDown(KeyCode.E)){
				inCombat = false;
				StartCoroutine(Damage());
				StartCoroutine(DisableStuff());
			}
		}
	}

	IEnumerator DisableStuff(){
		yield return new WaitForSeconds((eNumAttacks * 3.2f + pNumAttacks * 3.2f) + 1.5f);
		if(!disabler){
			disabler = true;
			missed.SetActive(true);
			crit.SetActive(true);
			pExp.gameObject.SetActive(true);
			eExp.gameObject.SetActive(true);
			battlerBackground.SetActive(false);
			attack.GetComponent<AttackClicked>().DestroySquares();
			if(killedEnemy){
				enemy.GetComponent<Movement>().dead = true;
			}
			if(killedPlayer){
				player.GetComponent<Movement>().dead = true;
			}	
		}
	}

	IEnumerator DontCallThis(){
		yield return new WaitForSeconds(1.5f);
		if(!disabler){
			disabler = true;
			missed.SetActive(true);
			crit.SetActive(true);
			pExp.gameObject.SetActive(true);
			eExp.gameObject.SetActive(true);
			battlerBackground.SetActive(false);
			attack.GetComponent<AttackClicked>().DestroySquares();
			if(killedEnemy){
				enemy.GetComponent<Movement>().dead = true;
			}
			if(killedPlayer){
				player.GetComponent<Movement>().dead = true;
			}	
		}
	}

	IEnumerator Damage(){
		combatGUI.SetActive(false);
		battlerBackground.SetActive(true);

		missed = GameObject.Find("Missed");
		if(missed != null){
			missed.SetActive(false);
		}

		crit = GameObject.Find("Crit");
		if(crit != null){
			crit.SetActive(false);
		}

		pExp = GameObject.Find("pEXP").GetComponent<Text>();
		eExp = GameObject.Find("eEXP").GetComponent<Text>();
		pExp.gameObject.SetActive(false);
		eExp.gameObject.SetActive(false);

		eHealthBar = GameObject.Find("EHealthBar");
		pHealthBar = GameObject.Find("PHealthBar");
		GameObject.Find("EnemySprite").GetComponent<Image>().sprite = enemy.GetComponent<SpriteRenderer>().sprite;
		GameObject.Find("PlayerSprite").GetComponent<Image>().sprite = player.GetComponent<SpriteRenderer>().sprite;

		if(eNumAttacks == 0){
			GameObject.Find("EBattlerHit").GetComponent<Text>().text = "-";
			GameObject.Find("EBattlerCrit").GetComponent<Text>().text = "-";
			GameObject.Find("EBattlerDamage").GetComponent<Text>().text = "-";
		} 
		else {
			GameObject.Find("EBattlerHit").GetComponent<Text>().text = eHitNum.ToString() + "%";
			GameObject.Find("EBattlerCrit").GetComponent<Text>().text = eCritNum.ToString();
			GameObject.Find("EBattlerDamage").GetComponent<Text>().text = eDamageNum.ToString() + " x" + eNumAttacks;
		}
		GameObject.Find("EnemyBattler").GetComponent<Text>().text = enemy.name;

		GameObject.Find("PBattlerCrit").GetComponent<Text>().text = pCritNum.ToString() + "%";
		GameObject.Find("PlayerBattler").GetComponent<Text>().text = player.name;
		GameObject.Find("PBattlerDamage").GetComponent<Text>().text = pDamageNum.ToString() + " x" + pNumAttacks;
		GameObject.Find("PBattlerHit").GetComponent<Text>().text = pHitNum.ToString() + "%";

		eHealthBar.transform.localScale = new Vector2((float)enemy.GetComponent<Stats>().GetCurHP() / (float)enemy.GetComponent<Stats>().baseHP, eHealthBar.transform.localScale.y);
		pHealthBar.transform.localScale = new Vector2((float)player.GetComponent<Stats>().GetCurHP() / (float)player.GetComponent<Stats>().baseHP, pHealthBar.transform.localScale.y);

		for(int i = 0; i < 5; i++){
			if(pNumAttacks > i){
				StartCoroutine(PlayerAttack());
				yield return new WaitForSeconds(1.6f);
				yield return new WaitForSeconds(1.6f);
				if(enemy.GetComponent<Stats>().GetCurHP() <= 0){
					killedEnemy = true;
					StartCoroutine(DontCallThis());
					break;
				}
			}
			if(eNumAttacks > i){
				StartCoroutine(EnemyAttack());
				yield return new WaitForSeconds(1.6f);
				yield return new WaitForSeconds(1.6f);
				if(player.GetComponent<Stats>().GetCurHP() <= 0){
					killedPlayer = true;
					StartCoroutine(DontCallThis());
					break;
				}
			}	
		}
		CalcEXP();
		yield return new WaitForSeconds(1.5f);
	}

	void CalcEXP(){
		int pEarnedXP = 0;
		int eEarnedXP = 0;
		if(killedPlayer){
			eEarnedXP = 30 + (player.GetComponent<Stats>().GetEffectiveLevel() - enemy.GetComponent<Stats>().GetEffectiveLevel());
			enemy.GetComponent<Stats>().exp += eEarnedXP;
		} 
		else if(!killedEnemy){
			pEarnedXP = (int)(31f - ((float)enemy.GetComponent<Stats>().GetEffectiveLevel() - (float)player.GetComponent<Stats>().GetEffectiveLevel()) / 3f);
			player.GetComponent<Stats>().exp += pEarnedXP;
			eEarnedXP = (int)(31f - ((float)player.GetComponent<Stats>().GetEffectiveLevel() - (float)enemy.GetComponent<Stats>().GetEffectiveLevel()) / 3f);
			enemy.GetComponent<Stats>().exp += eEarnedXP;
		}
		if(killedEnemy){
			pEarnedXP = 30 + (enemy.GetComponent<Stats>().GetEffectiveLevel() - player.GetComponent<Stats>().GetEffectiveLevel());
			player.GetComponent<Stats>().exp += pEarnedXP;
		}
		eExp.gameObject.SetActive(true);
		eExp.text = "Earned EXP: " + eEarnedXP.ToString();

		pExp.gameObject.SetActive(true);
		pExp.text = "Earned EXP: " + pEarnedXP.ToString();
		player.GetComponent<Stats>().CheckLevelUp();
		enemy.GetComponent<Stats>().CheckLevelUp();
	}

	IEnumerator PlayerAttack(){
		int hitRoll = Random.Range(1, 100);
		int critRoll = Random.Range(1, 100);
		GameObject.Find("PlayerSprite").GetComponent<RectTransform>().DOLocalMoveX(-140, 1.5f);
		yield return new WaitForSeconds(1.5f);
		if(hitRoll <= pHitNum){
			if(critRoll <= pCritNum){
				crit.SetActive(true);
				enemy.GetComponent<Stats>().DecreaseHP((int)(pDamageNum * 3f));
			} 
			else {
				enemy.GetComponent<Stats>().DecreaseHP((int)pDamageNum);
			}
		} 
		else {
			missed.SetActive(true);
		}
		eHealthBar.transform.localScale = new Vector2((float)enemy.GetComponent<Stats>().GetCurHP() / (float)enemy.GetComponent<Stats>().baseHP, eHealthBar.transform.localScale.y);
		GameObject.Find("PlayerSprite").GetComponent<RectTransform>().DOLocalMoveX(460, 1.5f);
		player.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().curUses--;
	}

	IEnumerator EnemyAttack(){
		int hitRoll = Random.Range(1, 100);
		int critRoll = Random.Range(1, 100);
		GameObject.Find("EnemySprite").GetComponent<RectTransform>().DOLocalMoveX(53, 1.5f);
		yield return new WaitForSeconds(1.5f);
		if(hitRoll <= eHitNum){
			if(critRoll <= eCritNum){
				crit.SetActive(true);
				player.GetComponent<Stats>().DecreaseHP((int)(eDamageNum * 3f));
			} 
			else {
				player.GetComponent<Stats>().DecreaseHP((int)eDamageNum);
			}
		} 
		else {
			missed.SetActive(true);
		}
		pHealthBar.transform.localScale = new Vector2((float)player.GetComponent<Stats>().GetCurHP() / (float)player.GetComponent<Stats>().baseHP, pHealthBar.transform.localScale.y);
		GameObject.Find("EnemySprite").GetComponent<RectTransform>().DOLocalMoveX(-541, 1.5f);
		enemy.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().curUses--;
	}
		
	void OnMouseDown(){
		Combat();
	}

	void Combat(){
		for(int i = 0; i < characters.Length; i++){
			if(characters[i].transform.position == this.gameObject.transform.position){
				enemy = characters[i];
			}
		}
		Equipment curEquip = GetComponentInParent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>();
		Equipment eEquip = enemy.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>();
		combatGUI.SetActive(true);
		pName = GameObject.Find("CPlayerName").GetComponent<Text>();
		pHit = GameObject.Find("PlayerHit").GetComponent<Text>();
		pDamage = GameObject.Find("PlayerDamage").GetComponent<Text>();
		pCrit = GameObject.Find("PlayerCrit").GetComponent<Text>();
		eName = GameObject.Find("CEnemyName").GetComponent<Text>();
		eHit = GameObject.Find("EnemyHit").GetComponent<Text>();
		eDamage = GameObject.Find("EnemyDamage").GetComponent<Text>();
		eCrit = GameObject.Find("EnemyCrit").GetComponent<Text>();
		pNumAttacks = GetNumAttacks(player, enemy);
		eNumAttacks = GetNumAttacks(enemy, player);
		pHitNum = GetHitPercent(player, enemy) - GetDodgeRate(player, enemy) + GetTriangleAccuracy(player, enemy);
		if(pHitNum > 100){
			pHitNum = 100;
		}
		if(pHitNum < 0){
			pHitNum = 0;
		}
		eHitNum = GetHitPercent(enemy, player) - GetDodgeRate(enemy, player) + GetTriangleAccuracy(enemy, player);
		eCritNum = GetCritPercent(enemy, player);
		if(eHitNum > 100){
			eHitNum = 100;
		}
		if(eHitNum < 0){
			eHitNum = 0;
		}
		if(eCritNum < 0){
			eCritNum = 0;
		}
		if(eCritNum > 100){
			eCritNum = 100;
		}
		pCritNum = GetCritPercent(player, enemy);
		if(pCritNum < 0){
			pCritNum = 0;
		}
		if(pCritNum > 100){
			pCritNum = 100;
		}
		if(curEquip.wepType == Equipment.Type.Anima || curEquip.wepType == Equipment.Type.Light || curEquip.wepType == Equipment.Type.Dark){
			pDamageNum = GetAttackPower(player, enemy) - GetResPower(enemy);
		} 
		else {
			pDamageNum = GetAttackPower(player, enemy) - GetDefensePower(enemy);
		}
		if(eEquip.wepType == Equipment.Type.Anima || eEquip.wepType == Equipment.Type.Light || eEquip.wepType == Equipment.Type.Dark){
			eDamageNum = GetAttackPower(enemy, player) - GetResPower(player);
		} 
		else {
			eDamageNum = GetAttackPower(enemy, player) - GetDefensePower(player);
		}
		if(pDamageNum < 0){
			pDamageNum = 0;
		}
		if(eDamageNum < 0){
			eDamageNum = 0;
		}
		if(eNumAttacks == 0){
			eHit.text = "-";
			eCrit.text = "-";
			eDamage.text = "-";
		} 
		else {
			eHit.text = eHitNum.ToString() + "%";
			eCrit.text = eCritNum.ToString();
			eDamage.text = eDamageNum.ToString() + " x" + eNumAttacks;
		}
		eName.text = enemy.name;

		pCrit.text = pCritNum.ToString() + "%";
		pName.text = player.name;
		pDamage.text = pDamageNum.ToString() + " x" + pNumAttacks;
		pHit.text = pHitNum.ToString() + "%";
		inCombat = true;
	}

	int GetCritPercent(GameObject one, GameObject two){
		Equipment oWep = one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>();
		int temp = (int)((float)oWep.crit + one.GetComponent<Stats>().GetSkill() / 2f) - (two.GetComponent<Stats>().GetLuck());
		if(temp > 100){
			temp = 100;
		}
		if(temp < 0){
			temp = 0;
		}
		return temp;
	}

	int GetNumAttacks(GameObject one, GameObject two){
		int attackNum = 1;
		if(one.GetComponent<Stats>().GetSpeed() >= two.GetComponent<Stats>().GetSpeed() + 4){
			attackNum++;
		}
		if(one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().brave){
			attackNum*=2;
		}
		if(Vector2.Distance(one.transform.position, two.transform.position) > one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().range){
			attackNum = 0;
		}
		return attackNum;
	}

	int GetAttackPower(GameObject one, GameObject two){
		if(one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().curUses > 0){
			return one.GetComponent<Stats>().GetStrength() + (one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().might * GetWeaponEffectivness(one, two)
			                                                  + (GetTriangleAccuracy(one, two) / (int)15));
		} 
		else {
			return 0;
		}
	}

	int GetDefensePower(GameObject one){
		return GetTerrainBonus() + one.GetComponent<Stats>().GetDefense();
	}

	int GetResPower(GameObject one){
		return GetTerrainBonus() + one.GetComponent<Stats>().GetRes();
	}

	int GetWeaponEffectivness(GameObject one, GameObject two){
		if(two.GetComponent<ClassManager>().unitClass.cType[(int)one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().baneNum]){
			return 3;
		}
		return 1;
	}

	int GetHitPercent(GameObject one, GameObject two){
		return (one.GetComponent<Stats>().GetSkill() * (int)2) + (int)((float)one.GetComponent<Stats>().GetLuck() * (float).5) + 
			one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().GetFullHit();
	}

	int GetAttackSpeed(GameObject one){
		int AS = one.GetComponent<Stats>().GetSpeed() + one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().weight - one.GetComponent<Stats>().GetCon();
		if(AS < 0){
			AS = 0;
		}
		return AS;
	}

	int GetTerrainBonus(){
		string tagUnder = Movement.GetSquareUnder(this.gameObject);
		if(tagUnder == "SandTerrain"){
			return 5;
		}
		if(tagUnder == "HouseTerrain" || tagUnder == "LakeTerrain" || tagUnder == "SeaTerrain" || tagUnder == "VillageTerrain"){
			return 10;
		}
		if(tagUnder == "ForestTerrain" || tagUnder == "FortTerrain" || tagUnder == "PillarTerrain"){
			return 20;
		}
		if(tagUnder == "GateTerrain" || tagUnder == "MountainTerrain" || tagUnder == "ThroneTerrain"){
			return 30;
		}
		if(tagUnder == "PeakTerrain"){
			return 40;
		}
		return 0;
	}

	int GetDodgeRate(GameObject one, GameObject two){
		return (GetAttackSpeed(one) * 2) + one.GetComponent<Stats>().GetLuck() + GetTerrainBonus();
	}

	int GetTriangleAccuracy(GameObject one, GameObject two){
		Equipment.Type pType = one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().wepType;
		Equipment.Type eType = two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().wepType;
		if(pType == Equipment.Type.Axe){
			if(one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
				if(eType == Equipment.Type.Lance){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return -30;
					} 
					else {
						return 15;
					}
				}
				if(eType == Equipment.Type.Sword){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return 30;
					}
					else {
						return -15;
					}
				}
			} 
			else {
				if(eType == Equipment.Type.Lance){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return 15;
					} 
					else {
						return -30;
					}
				}
				if(eType == Equipment.Type.Sword){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return -15;
					} 
					else {
						return 30;
					}
				}
			}
		}
		if(pType == Equipment.Type.Lance){
			if(one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
				if(eType == Equipment.Type.Sword){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return -30;
					} 
					else {
						return 15;
					}
				}
				if(eType == Equipment.Type.Axe){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return 30;
					}
					else {
						return -15;
					}
				}
			} 
			else {
				if(eType == Equipment.Type.Sword){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return 15;
					} 
					else {
						return -30;
					}
				}
				if(eType == Equipment.Type.Axe){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return -15;
					} 
					else {
						return 30;
					}
				}
			}
		}
		if(pType == Equipment.Type.Sword){
			if(one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
				if(eType == Equipment.Type.Axe){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return -30;
					} 
					else {
						return 15;
					}
				}
				if(eType == Equipment.Type.Lance){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return 30;
					}
					else {
						return -15;
					}
				}
			} 
			else {
				if(eType == Equipment.Type.Axe){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return 15;
					} 
					else {
						return -30;
					}
				}
				if(eType == Equipment.Type.Lance){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return -15;
					} 
					else {
						return 30;
					}
				}
			}
		}
		if(pType == Equipment.Type.Anima){
			if(one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
				if(eType == Equipment.Type.Light){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return -30;
					} 
					else {
						return 15;
					}
				}
				if(eType == Equipment.Type.Dark){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return 30;
					}
					else {
						return -15;
					}
				}
			} 
			else {
				if(eType == Equipment.Type.Light){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return 15;
					} 
					else {
						return -30;
					}
				}
				if(eType == Equipment.Type.Dark){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return -15;
					} 
					else {
						return 30;
					}
				}
			}
		}
		if(pType == Equipment.Type.Light){
			if(one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
				if(eType == Equipment.Type.Dark){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return -30;
					} 
					else {
						return 15;
					}
				}
				if(eType == Equipment.Type.Anima){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return 30;
					}
					else {
						return -15;
					}
				}
			} 
			else {
				if(eType == Equipment.Type.Dark){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return 15;
					} 
					else {
						return -30;
					}
				}
				if(eType == Equipment.Type.Anima){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return -15;
					} 
					else {
						return 30;
					}
				}
			}
		}
		if(pType == Equipment.Type.Dark){
			if(one.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
				if(eType == Equipment.Type.Anima){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return -30;
					} 
					else {
						return 15;
					}
				}
				if(eType == Equipment.Type.Light){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return 30;
					}
					else {
						return -15;
					}
				}
			} 
			else {
				if(eType == Equipment.Type.Anima){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return 15;
					} 
					else {
						return -30;
					}
				}
				if(eType == Equipment.Type.Light){
					if(!two.GetComponent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().reaver){
						return -15;
					} 
					else {
						return 30;
					}
				}
			}
		}
		return 0;
	}
}
