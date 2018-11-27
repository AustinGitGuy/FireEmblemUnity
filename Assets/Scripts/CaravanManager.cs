using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanManager : MonoBehaviour {

	List<GameObject> items;
	GameObject display;
	public int gold;

	void Start(){
		items = new List<GameObject>();
		display = GameObject.Find("GodObject").GetComponent<GUIManager>().caravan;
	}

	void Update(){
		display.GetComponent<CaravanDraw>().items = items;
	}

	public void AddItem(GameObject toAdd){
		items.Add(toAdd);
	}

	public void DeleteItem(int toDelete){
		if(toDelete > items.Count || toDelete < 0){
			return;
		}
		items.RemoveAt(toDelete);
	}

	public void DeleteItem(GameObject toDelete){
		items.RemoveAt(findIndex(toDelete));
	}

	public GameObject findItem(string name){
		for(int i = 0; i < items.Count; i++){
			if(items[i].name == name){
				return items[i];
			}
		}
		return null;
	}

	public int findIndex(GameObject toFind){
		for(int i = 0; i < items.Count; i++){
			if(items[i] == toFind){
				return i;
			}
		}
		return -1;
	}
}
