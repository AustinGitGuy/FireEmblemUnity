using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGame : MonoBehaviour {

	void OnMouseDown(){
		SceneManager.LoadScene("Scene1");
	}
}
