using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedBarrackUnit : MonoBehaviour {

	public int id;

	void Start(){
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		GetComponentInParent<ChooseGUI>().AddActiveUnit(id);
	}
}
