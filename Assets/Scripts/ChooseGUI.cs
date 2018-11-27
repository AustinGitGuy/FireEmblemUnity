using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseGUI : MonoBehaviour {

	int curBarrackNum;
	GameObject charManager;
	GameObject[] playerSpawns;
	public Image[] active;
	public GameObject[] activeUnits;
	public Image[] barracks;
	public GameObject[] barracksUnits;

	public bool dontLock;

	void Start(){
		charManager = GameObject.Find("PlayerCharacters");
		active = new Image[8];
		activeUnits = new GameObject[8];
		barracks = new Image[40];
		barracksUnits = new GameObject[40];
		for(int i = 1; i < active.Length + 1; i++){
			active[i - 1] = GameObject.Find("ChooseU" + i).GetComponent<Image>();
			active[i - 1].sprite = null;
			active[i - 1].gameObject.SetActive(false);
		}
		for(int i = 1; i < barracks.Length + 1; i++){
			barracks[i - 1] = GameObject.Find("ChooseB" + i).GetComponent<Image>();
			barracks[i - 1].gameObject.SetActive(false);
		}
		SetLockedUnits();
	}

	void Update(){
		CheckBackToMenu();
		curBarrackNum = 0;
		playerSpawns = GameObject.FindGameObjectsWithTag("PlayerSpawn");
		for(int i = 0; i < playerSpawns.Length; i++){
			active[i].gameObject.SetActive(true);
			if(activeUnits[i] != null){
				activeUnits[i].SetActive(true);
				activeUnits[i].transform.position = playerSpawns[i].transform.position;
			}
		}
		for(int i = 0; i < charManager.GetComponent<CharacterManager>().characters.Length; i++){
			if(charManager.GetComponent<CharacterManager>().unlocked[i]){
				barracks[curBarrackNum].gameObject.SetActive(true);
				barracks[curBarrackNum].sprite = charManager.GetComponent<CharacterManager>().characters[i].GetComponent<SpriteRenderer>().sprite;
				barracksUnits[curBarrackNum] = charManager.GetComponent<CharacterManager>().characters[i];
				curBarrackNum++;
			}
		}
	}

	void SetLockedUnits(){
		if(dontLock){
			return;
		}
		playerSpawns = GameObject.FindGameObjectsWithTag("PlayerSpawn");
		activeUnits[0] = charManager.GetComponent<CharacterManager>().FindCharacter("Timmy");
		activeUnits[0].SetActive(true);
		active[0].sprite = activeUnits[0].GetComponent<SpriteRenderer>().sprite;
		activeUnits[0].transform.position = playerSpawns[0].transform.position;
	}

	void CheckBackToMenu(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			GameObject.Find("GodObject").GetComponent<GUIManager>().prepMenu.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}

	public void AddActiveUnit(int id){
		for(int i = 0; i < active.Length; i++){
			if(active[i].IsActive()){
				if(active[i].sprite == null){
					for(int c = 0; c < i; c++){
						if(active[c].sprite == barracks[id].sprite){
							return;
						}
					}
					active[i].sprite = barracks[id].sprite;
					activeUnits[i] = barracksUnits[id];
					return;
				}
			}
		}
	}
}
