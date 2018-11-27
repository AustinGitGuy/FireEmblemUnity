using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour {

	public GameObject[] characters;
	public bool[] unlocked;

	void Start(){
		characters = GameObject.FindGameObjectsWithTag("Ally");
		unlocked = new bool[characters.Length];
		for(int i = 0; i < characters.Length; i++){
			if(characters[i].name == "Timmy" || characters[i].name == "JunoJr"){
				unlocked[i] = true;
			}
			characters[i].SetActive(false);
		}
	}

	bool SetCharacterActive(string name){
		for(int i = 0; i < characters.Length; i++){
			if(characters[i].name == name){
				unlocked[i] = true;
				return true;
			}
		}
		return false;
	}

	bool SetCharacterInactive(string name){
		for(int i = 0; i < characters.Length; i++){
			if(characters[i].name == name){
				unlocked[i] = false;
				return true;
			}
		}
		return false;
	}

	bool GetCharacterActive(string name){
		for(int i = 0; i < characters.Length; i++){
			if(characters[i].name == name){
				return unlocked[i];
			}
		}
		return false;
	}

	public GameObject FindCharacter(string name){
		for(int i = 0; i < characters.Length; i++){
			if(characters[i].name == name){
				return characters[i];
			}
		}
		return null;
	}
}
