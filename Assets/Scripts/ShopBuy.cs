using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuy : MonoBehaviour {

	public int id;
	GameObject playerCharacters;

	void Start(){
		playerCharacters = GameObject.Find("PlayerCharacters");
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
		id = int.Parse(this.name.Substring(4, this.name.Length - 4));
	}

	void OnButtonClick(){
		if(playerCharacters.GetComponent<CaravanManager>().gold >= GetComponentInParent<ShopManager>().items[id - 1].GetComponent<Equipment>().worth){
			playerCharacters.GetComponent<CaravanManager>().AddItem(GetComponentInParent<ShopManager>().items[id - 1]);
			playerCharacters.GetComponent<CaravanManager>().gold -= GetComponentInParent<ShopManager>().items[id - 1].GetComponent<Equipment>().worth;
		}
	}
}
