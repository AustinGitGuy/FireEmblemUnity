using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaravanDraw : MonoBehaviour {

	public List<GameObject> items;
	public List<Text> itemTexts;

	int numItems = 40;

	void Start(){
		itemTexts = new List<Text>();
		for(int i = 0; i < numItems; i++){
			itemTexts.Add(this.transform.Find("Item" + (i + 1)).GetComponent<Text>());
		}
	}

	void Update(){
		for(int i = 0; i < itemTexts.Count; i++){
			if(i < items.Count && items[i] != null){
				itemTexts[i].text = items[i].name	;
			} 
			else {
				itemTexts[i].text = "";
			}
		}
	}
}
