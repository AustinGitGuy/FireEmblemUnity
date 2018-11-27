using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedDisable : MonoBehaviour {

	void OnEnable(){
		StartCoroutine(Disable());
	}

	IEnumerator Disable(){
		yield return new WaitForSeconds(.5f);
		gameObject.SetActive(false);
	}
}
