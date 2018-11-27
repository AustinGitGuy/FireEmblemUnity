using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GetSeed : MonoBehaviour {

	InputField input;
	public int seed;

	void Start (){
		if(GameObject.Find("InputField") != null) input = GameObject.Find("InputField").GetComponent<InputField>();
	}

	void Update (){
		seed = int.Parse(input.text);
	}
}
