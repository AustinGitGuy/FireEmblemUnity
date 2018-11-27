using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour {

	void Awake(){
		if(SceneManager.GetActiveScene().name == "AlliesWin" || SceneManager.GetActiveScene().name == "EnemiesWin") Destroy(transform.gameObject);
		DontDestroyOnLoad(transform.gameObject);
	}
}
