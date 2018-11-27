using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStart : MonoBehaviour {

	void OnMouseDown(){
		SceneManager.LoadScene("Start");
	}
}
