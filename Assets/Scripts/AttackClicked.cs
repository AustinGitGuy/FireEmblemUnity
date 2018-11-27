using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackClicked : MonoBehaviour {

	public GameObject redSquarePrefab;
	GameObject end;
	GameObject equip;
	GameObject attack;
	GameObject dance;
	GameObject heal;
	GameObject trade;
	GameObject caravan;
	GameObject[] squareArray;
	public int range;
	public bool clicked;
	int superIndex = 0;

	public GameObject[] characters;

	void Start(){
		squareArray = new GameObject[GetNumSquares()];
		end = GameObject.Find("End(Clone)");
		equip = GameObject.Find("Equip(Clone)");
		heal = GameObject.Find("Heal(Clone)");
		dance = GameObject.Find("Dance(Clone)");
		trade = GameObject.Find("Trade(Clone)");
		caravan = GameObject.Find("Caravan(Clone)");
		characters = GameObject.FindGameObjectsWithTag("Character");
		for(int i = 0; i < characters.Length; i++){
			characters[i] = characters[i].transform.parent.gameObject;
		}
		range = GetComponentInParent<EquipmentManager>().getCurEquipment().GetComponent<Equipment>().range;
	}

	int GetNumSquares(){
		int num = 0;
		for(int i = 0; i < range; i++){
			num += Recurse(i);
		}
		return num;
	}

	int Recurse(int iteration){
		return (range - Mathf.Abs((iteration + 1 - range))) * 4;
	}

	void OnMouseDown(){
		gameObject.SetActive(false);
		end.SetActive(false);
		equip.SetActive(false);
		trade.SetActive(false);
		if(heal != null){
			heal.SetActive(false);
		}
		if(dance != null){
			dance.SetActive(false);
		}
		if(caravan != null){
			caravan.SetActive(false);
		}
		RenderAttackSquares();
	}

	void RenderAttackSquares(){
		if (clicked) return;
		clicked = true;
		for(int c = 0; c < range; c++){
			for(int i = 0; i < range - c; i++){
				squareArray[superIndex] = Instantiate(redSquarePrefab, this.transform.parent) as GameObject;
				if(i == 0) MoveSquareUp(squareArray[superIndex], c);
				if(i > 0) MoveSquareUp(squareArray[superIndex], squareArray[superIndex - 1], c);
				superIndex++;
			}
			for(int i = 0; i < range - c; i++){
				squareArray[superIndex] = Instantiate(redSquarePrefab, this.transform.parent) as GameObject;
				if(i == 0) MoveSquareDown(squareArray[superIndex], c);
				if(i > 0) MoveSquareDown(squareArray[superIndex], squareArray[superIndex - 1], c);
				superIndex++;
			}
			for(int i = 0; i < range - c; i++){
				squareArray[superIndex] = Instantiate(redSquarePrefab, this.transform.parent) as GameObject;
				if(i == 0) MoveSquareLeft(squareArray[superIndex], c);
				if(i > 0) MoveSquareLeft(squareArray[superIndex], squareArray[superIndex - 1], c);
				superIndex++;
			}
			for(int i = 0; i < range - c; i++){
				squareArray[superIndex] = Instantiate(redSquarePrefab, this.transform.parent) as GameObject;
				if(i == 0) MoveSquareRight(squareArray[superIndex], c);
				if(i > 0) MoveSquareRight(squareArray[superIndex], squareArray[superIndex - 1], c);
				superIndex++;
			}
		}
	}

	void MoveSquareUp(GameObject square, int c){
		int index = 0;
		Vector2 pos = new Vector2(c, 1);
		square.transform.localPosition = pos;
		for(int i = 0; i < characters.Length; i++){
			if(square.transform.position == characters[i].transform.position && !characters[i].GetComponent<Movement>().dead){
				if(characters[i].gameObject.tag == "Ally" && transform.parent.gameObject.tag == "Enemy") index++;
				if(characters[i].gameObject.tag == "Enemy" && transform.parent.gameObject.tag == "Ally") index++;
			}
		}
		if(index == 0) Destroy(square);
	}

	void MoveSquareUp(GameObject square, GameObject previousSquare, int c){
		int index = 0;
		float yPos = previousSquare.transform.localPosition.y + 1;
		square.transform.localPosition = new Vector2(c, yPos);
		for(int i = 0; i < characters.Length; i++){
			if(square.transform.position == characters[i].transform.position && !characters[i].GetComponent<Movement>().dead){
				if(characters[i].gameObject.tag == "Ally" && transform.parent.gameObject.tag == "Enemy") index++;
				if(characters[i].gameObject.tag == "Enemy" && transform.parent.gameObject.tag == "Ally") index++;
			}
		}
		if(index == 0) Destroy(square);
	}

	void MoveSquareDown(GameObject square, int c){
		int index = 0;
		Vector2 pos = new Vector2(-c, -1);
		square.transform.localPosition = pos;
		for(int i = 0; i < characters.Length; i++){
			if(square.transform.position == characters[i].transform.position && !characters[i].GetComponent<Movement>().dead){
				if(characters[i].gameObject.tag == "Ally" && transform.parent.gameObject.tag == "Enemy") index++;
				if(characters[i].gameObject.tag == "Enemy" && transform.parent.gameObject.tag == "Ally") index++;
			}
		}
		if(index == 0) Destroy(square);
	}

	void MoveSquareDown(GameObject square, GameObject previousSquare, int c){
		int index = 0;
		float yPos = previousSquare.transform.localPosition.y - 1;
		square.transform.localPosition = new Vector2(-c, yPos);
		for(int i = 0; i < characters.Length; i++){
			if(square.transform.position == characters[i].transform.position && !characters[i].GetComponent<Movement>().dead){
				if(characters[i].gameObject.tag == "Ally" && transform.parent.gameObject.tag == "Enemy") index++;
				if(characters[i].gameObject.tag == "Enemy" && transform.parent.gameObject.tag == "Ally") index++;
			}
		}
		if(index == 0) Destroy(square);
	}

	void MoveSquareRight(GameObject square, int c){
		int index = 0;
		Vector2 pos = new Vector2(1, -c);
		square.transform.localPosition = pos;
		for(int i = 0; i < characters.Length; i++){
			if(square.transform.position == characters[i].transform.position && !characters[i].GetComponent<Movement>().dead){
				if(characters[i].gameObject.tag == "Ally" && transform.parent.gameObject.tag == "Enemy") index++;
				if(characters[i].gameObject.tag == "Enemy" && transform.parent.gameObject.tag == "Ally") index++;
			}
		}
		if(index == 0) Destroy(square);
	}

	void MoveSquareRight(GameObject square, GameObject previousSquare, int c){
		int index = 0;
		float xPos = previousSquare.transform.localPosition.x + 1;
		square.transform.localPosition = new Vector2(xPos, -c);
		for(int i = 0; i < characters.Length; i++){
			if(square.transform.position == characters[i].transform.position && !characters[i].GetComponent<Movement>().dead){
				if(characters[i].gameObject.tag == "Ally" && transform.parent.gameObject.tag == "Enemy") index++;
				if(characters[i].gameObject.tag == "Enemy" && transform.parent.gameObject.tag == "Ally") index++;
			}
		}
		if(index == 0) Destroy(square);
	}

	void MoveSquareLeft(GameObject square, int c){
		int index = 0;
		Vector2 pos = new Vector2(-1, c);
		square.transform.localPosition = pos;
		for(int i = 0; i < characters.Length; i++){
			if(square.transform.position == characters[i].transform.position && !characters[i].GetComponent<Movement>().dead){
				if(characters[i].gameObject.tag == "Ally" && transform.parent.gameObject.tag == "Enemy") index++;
				if(characters[i].gameObject.tag == "Enemy" && transform.parent.gameObject.tag == "Ally") index++;
			}
		}
		if(index == 0) Destroy(square);
	}

	void MoveSquareLeft(GameObject square, GameObject previousSquare, int c){
		int index = 0;
		float xPos = previousSquare.transform.localPosition.x - 1;
		square.transform.localPosition = new Vector2(xPos, c);
		for(int i = 0; i < characters.Length; i++){
			if(square.transform.position == characters[i].transform.position && !characters[i].GetComponent<Movement>().dead){
				if(characters[i].gameObject.tag == "Ally" && transform.parent.gameObject.tag == "Enemy") index++;
				if(characters[i].gameObject.tag == "Enemy" && transform.parent.gameObject.tag == "Ally") index++;
			}
		}
		if(index == 0) Destroy(square);
	}

	public void DestroySquares(){
		for(int i = 0; i < squareArray.Length; i++){
			Destroy(squareArray[i]);
		}
		clicked = false;
		transform.parent.GetComponent<Movement>().turnEnd = true;
		transform.parent.GetComponent<Movement>().inMenu = false;
		superIndex = 0;
		Destroy(this.gameObject);
		Destroy(end);
		Destroy(equip);
		if(heal != null){
			Destroy(heal);
		}
		if(dance != null){
			Destroy(dance);
		}
		if(caravan != null){
			Destroy(caravan);
		}
	}

	public void BackToMenu(){
		GameObject.Find("GodObject").GetComponent<GUIManager>().combatGUI.SetActive(false);
		for(int i = 0; i < squareArray.Length; i++){
			Destroy(squareArray[i]);
		}
		clicked = false;
		superIndex = 0;
		transform.parent.GetComponent<AfterMovementMenu>().ExitMenu();
		if(transform.parent.GetComponent<AfterMovementMenu>().Menu()) transform.parent.GetComponent<Movement>().DestroySquares();
	}
}
