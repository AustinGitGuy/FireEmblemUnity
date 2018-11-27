using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedActiveUnit : MonoBehaviour {

	public int id;

	void Start(){
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		GetComponentInParent<ChooseGUI>().active[id].sprite = null;
		GetComponentInParent<ChooseGUI>().activeUnits[id].SetActive(false);
		GetComponentInParent<ChooseGUI>().activeUnits[id] = null;
	}
}
