using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour {

	public enum Bane {Flying, Dragon, Armor, Horseback, Monster};
	public enum PrefType {Sword, Lance, Axe, Bow, Staff, Dark, Light, Anima, NullType};
	public bool[] cType = new bool[5];
	public char[] pType = new char[9];
	public int hpGrowth;
	public int strGrowth;
	public int sklGrowth;
	public int spdGrowth;
	public int lckGrowth;
	public int defGrowth;
	public int resGrowth;

	public GameObject promote1;
	public GameObject promote2;

	public int baseHP;
	public int baseStr;
	public int baseSkl;
	public int baseSpd;
	public int baseLck;
	public int baseDef;
	public int baseRes;
	public int baseMove;
	public int baseCon;
}
