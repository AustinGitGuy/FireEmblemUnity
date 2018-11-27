using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

	public GameObject healthPrefab;

	int movement;
	public GameObject moveSquare;
	public GameObject[] squareArray;
	GameObject godObject;
	bool clicked;
	public bool turnEnd;
	public bool inMenu;
	int index = 0;

	int seed;

	public bool dead;

	public GameObject[] characters;

	void Start(){
		seed = GameObject.Find("GodObject").GetComponent<MapGeneration>().seed;
		seed += (int)transform.position.x;
		Random.InitState(seed);
		movement = GetComponent<Stats>().GetMovement();
		squareArray = new GameObject[GetNumSquares()];
		for(int i = 0; i < characters.Length; i++){
			characters[i] = characters[i].transform.parent.gameObject;
		}
		godObject = GameObject.Find("GodObject");
	}

	int GetNumSquares(){
		int num = 0;
		for(int i = 0; i < movement; i++){
			num += Recurse(i);
		}
		return num;
	}

	void Update(){
		CheckDead();
	}

	void CheckDead(){
		if(dead){
			//transform.DetachChildren();
			gameObject.SetActive(false);
		}
	}

	int Recurse(int iteration){
		return (movement - Mathf.Abs((iteration + 1 - movement))) * 4;
	}

	void OnMouseDown(){
		characters = GameObject.FindGameObjectsWithTag("Character");
		if(clicked){
			inMenu = true;
			clicked = false;
			if(this.GetComponent<AfterMovementMenu>().Menu()) this.GetComponent<Movement>().DestroySquares();
			return;
		}
		if(turnEnd) return;
		if(inMenu) return;
		if(!godObject.GetComponent<CheckTurnEnd>().allyTurn && transform.tag == ("Ally")) return;
		if(!godObject.GetComponent<CheckTurnEnd>().enemyTurn && transform.tag == ("Enemy")) return;
		if(!godObject.GetComponent<CheckTurnEnd>().neutralTurn && transform.tag == ("Neutral")) return;
		if(!godObject.GetComponent<CheckTurnEnd>().gameStart) return;
		if(dead) return;
		clicked = true;

		GameObject[] tiles = GetObjectsInLayer(8);
		GameObject startTile = null;
		for(int i = 0; i < tiles.Length; i++){
			if(tiles[i].transform.position.x == this.transform.position.x && tiles[i].transform.position.y == this.transform.position.y){
				startTile = tiles[i];
			}
		}
		GetValidMoves(startTile, movement);
	}

	void GetValidMoves(GameObject startTile, int movePoints){
		if(GetPlayerOverlay(startTile) && movePoints != movement){
			return;
		}
		if(!GetTileOverlay(startTile) && startTile.tag != "VoidTerrain" && startTile.tag != "DoorTerrain" && startTile.tag != "WallTerrain"){
			squareArray[index] = Instantiate(moveSquare, this.transform) as GameObject;
			squareArray[index].transform.position = new Vector3(startTile.transform.position.x, startTile.transform.position.y, -1);
			squareArray[index].layer = 9;
			index++;
		}
		for(int i = 0; i < startTile.GetComponent<Tile>().connected.Length; i++){
			int points = 1;
			if(!GetComponent<ClassManager>().unitClass.cType[(int)Class.Bane.Flying]){
				if(startTile.tag == "ForestTerrain"){
					points++;
				} 
				else if(startTile.tag == "SandTerrain"){
					if(GetComponent<ClassManager>().unitClass.cType[(int)Class.Bane.Horseback]){
						points += 3;
					} else{
						points++;
					}
				} 
				else if(startTile.tag == "MountainTerrain"){
					if(GetComponent<ClassManager>().unitClass.cType[(int)Class.Bane.Horseback] || GetComponent<ClassManager>().unitClass.cType[(int)Class.Bane.Armor]){
						points += 999;
					} else{
						points += 3;
					}
				} 
				else if(startTile.tag == "CliffTerrain"){
					points += 999;
				}

			}
			if(startTile.tag == "VoidTerrain"){
				points += 999;
			}
			int nextMoveCost = movePoints - points;
			if(nextMoveCost >= 0){
				GetValidMoves(startTile.GetComponent<Tile>().connected[i], nextMoveCost);
			}
		}
	}

	bool GetPlayerOverlay(GameObject tile){
		for(int i = 0; i < characters.Length; i++){
			if(new Vector3(tile.transform.position.x, tile.transform.position.y, -1) == characters[i].transform.position){
				if(characters[i].tag != this.tag){
					return true;
				}
			}
		}
		return false;
	}

	bool GetTileOverlay(GameObject tile){
		for(int i = 0; i < index; i++){
			if(squareArray[i].transform.position == new Vector3(tile.transform.position.x, tile.transform.position.y, -1)){
				return true;
			}
		}
		for(int i = 0; i < characters.Length; i++){
			if(new Vector3(tile.transform.position.x, tile.transform.position.y, -1) == characters[i].transform.position){
				return true;
			}
		}
		return false;
	}

	public static GameObject[] GetAdjacentTiles(GameObject toFind){
		GameObject[] adjTiles = new GameObject[4];
		int tempIndex = 0;
		GameObject[] allTiles = GetObjectsInLayer(8);
		for(int i = 0; i < allTiles.Length; i++){
			if(allTiles[i].transform.position.x == toFind.transform.position.x + 1 || allTiles[i].transform.position.x == toFind.transform.position.x - 1){
				if(allTiles[i].transform.position.y == toFind.transform.position.y){
					adjTiles[tempIndex] = allTiles[i];
					tempIndex++;
				}
			}
			if(allTiles[i].transform.position.y == toFind.transform.position.y + 1 || allTiles[i].transform.position.y == toFind.transform.position.y - 1){
				if(allTiles[i].transform.position.x == toFind.transform.position.x){
					adjTiles[tempIndex] = allTiles[i];
					tempIndex++;
				}
			}
		}
		return adjTiles;
	}

	public static string GetSquareUnder(GameObject toFind){
		GameObject[] terrain = GetObjectsInLayer(8);
		for(int i = 0; i < terrain.Length; i++){
			if(terrain[i].transform.position.x == toFind.transform.position.x && terrain[i].transform.position.y == toFind.transform.position.y){
				return terrain[i].tag;
			}
		}
		return null;
	}

	public static GameObject[] GetObjectsInLayer(int layer){
		GameObject[] goArray = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		List<GameObject> goList = new System.Collections.Generic.List<GameObject>();
		for(int i = 0; i < goArray.Length; i++){
			if(goArray[i].layer == layer){
				goList.Add(goArray[i]);
			}
		}
		if(goList.Count == 0){
			return null;
		}
		return goList.ToArray();
	}

	public void DestroySquares(){
		for(int i = 0; i < squareArray.Length; i++){
			Destroy(squareArray[i]);
		}
		clicked = false;
		inMenu = true;
		index = 0;
	}
}
