using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHeightmap : MonoBehaviour {

	public GameObject[] tilesPrefab;
	public GameObject voidPrefab;
	public GameObject stonePrefab;
	public GameObject sandPrefab;
	public GameObject grassPrefab;

	GameObject[,] tiles;
	int[,] heightMap;
	int width = 26;
	int height = 16;

	void Start(){
		tiles = new GameObject[width + 2,height + 2];
		heightMap = new int[width + 2,height + 2];
		//RandomHeightMap();
		HeightMap();
		HeightToTile();
	}

	void RandomHeightMap(){
		for(int i = 0; i < width + 2; i++){
			for(int c = 0; c < height + 2; c++){
				if (i == 0 || i == width + 1 || c == 0 || c == height + 1) tiles[i, c] = Instantiate(voidPrefab) as GameObject;
				else tiles[i,c] = Instantiate(tilesPrefab[Random.Range(0, tilesPrefab.Length)]) as GameObject;
				MoveTile(i, c);
			}
		}
	}

	void HeightMap(){
		for(int i = 0; i < width + 2; i++){
			for(int c = 0; c < height + 2; c++){
				
			}
		}
	}

	void HeightToTile(){
		for(int i = 0; i < width + 2; i++){
			for(int c = 0; c < height + 2; c++){
				if (heightMap[i, c] == -1) tiles[i, c] = Instantiate(voidPrefab) as GameObject;
				else if (heightMap[i, c] < .3) tiles[i, c] = Instantiate(sandPrefab) as GameObject;
				else if (heightMap[i, c] < .6) tiles[i, c] = Instantiate(grassPrefab) as GameObject;
				else if (heightMap[i, c] < .9) tiles[i, c] = Instantiate(stonePrefab) as GameObject;
				MoveTile(i, c);
			}
		}
	}

	void MoveTile(int i, int c){
		tiles[i,c].transform.position = new Vector2(i, c);
	}
}
