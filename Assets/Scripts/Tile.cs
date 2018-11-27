using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tile : MonoBehaviour {
	
	public GameObject[] connected;

	void Start(){
		connected = Movement.GetAdjacentTiles(this.gameObject);
	}
}
