using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour {

	Rigidbody2D rb;
	float speed = 4f;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
	}
}
