using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveChar : MonoBehaviour {

	float speed = 5f;

	void OnMouseDown(){
		StartCoroutine(MoveStuff());
	}

	IEnumerator MoveStuff(){
		float distx = Mathf.Abs(transform.parent.position.x - transform.position.x);
		float disty = Mathf.Abs(transform.parent.position.y - transform.position.y);
		if(transform.parent.position.x != transform.position.x) transform.parent.DOLocalMoveX(transform.position.x, distx / speed);
		yield return new WaitForSeconds(0f);
		if(transform.parent.position.y != transform.position.y) transform.parent.DOLocalMoveY(transform.position.y, disty / speed);
		if(transform.parent.GetComponent<AfterMovementMenu>().Menu()) transform.parent.GetComponent<Movement>().DestroySquares();
	}
}
