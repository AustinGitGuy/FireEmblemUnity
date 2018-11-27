using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrepMap : MonoBehaviour {

	void Start(){
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){
		SceneManager.LoadScene("WorldMap");
		this.transform.parent.gameObject.SetActive(false);
	}
}
