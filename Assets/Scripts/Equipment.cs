using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {

	public enum Rank {A, B, C, D, E, S, Prf};
	public enum Type {Sword, Lance, Axe, Bow, Staff, Dark, Light, Anima, Consumable, NullType};
	public enum Bane {None, Flying, Dragon, Armor, Horseback, Monster};
	public Bane baneNum;
	public Type wepType;
	public Rank wepRank;
	public int maxUses;
	public int curUses;
	public int might;
	public int hit;
	public int crit;
	public int range;
	public int weight;
	public int worth;
	public bool reaver;
	public bool brave;
	public int healAmount;

	public int hpBuff;
	public int strBuff;
	public int sklBuff;
	public int spdBuff;
	public int lckBuff;
	public int defBuff;
	public int resBuff;
	public int conBuff;
	public int moveBuff;

	void Start(){
		curUses = maxUses;
	}

	public int GetFullHit(){
		if(wepType == Type.Anima || wepType == Type.Dark || wepType == Type.Light || wepType == Type.Lance || wepType == Type.Bow){
			if(wepRank == Rank.B || wepRank == Rank.A){
				return 5 + hit;
			}
		}
		if(wepType == Type.Axe){
			if(wepRank == Rank.C){
				return 5 + hit;
			}
			if(wepRank == Rank.B){
				return 10 + hit;
			}
			if(wepRank == Rank.A){
				return 15 + hit;
			}
		}
		return hit;
	}
}
