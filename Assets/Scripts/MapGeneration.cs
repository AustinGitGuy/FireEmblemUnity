using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

	public int width;
	public int height;
	public float scale;
	public int octaves;

	[Range(0,1)]
	public float persistance;
	public float lacunarity;

	public int seed;
	public Vector2 offset;

	float[,] noise;
	float[] noise1d;

	GameObject[,] tiles;
	GameObject[,] lines;

	public GameObject sandPrefab;
	public GameObject grassPrefab;
	public GameObject stonePrefab;

	public GameObject voidPrefab;

	public bool autoUpdate;

	void Start(){
		//seed = GameObject.Find("Seed").GetComponent<GetSeed>().seed;
		seed = 11037;
		noise = Noise.GenerateNoiseMap(width, height, seed, scale, octaves, persistance, lacunarity, offset);
		tiles = new GameObject[width, height];
		lines = new GameObject[width, height];
		HeightToTile();
	}

	void Update(){
		if (width < 1) width = 1;
		if (height < 1) height = 1;
		if (lacunarity < 1) lacunarity = 1;
		if (octaves < 1) octaves = 1;
		if (autoUpdate){
			noise = Noise.GenerateNoiseMap(width, height, seed, scale, octaves, persistance, lacunarity, offset);
			DeleteTiles();
			HeightToTile();
		}
	}

	void HeightToTile(){
		for(int y = 0; y < height; y++){
			for(int x = 0; x < width; x++){
				if (y == 0 || x == 0 || y == height - 1 || x == width - 1) tiles[x, y] = Instantiate(voidPrefab) as GameObject;
				else if (noise[x, y] < .3333) tiles[x, y] = Instantiate(sandPrefab) as GameObject;
				else if (noise[x, y] < .6666) tiles[x, y] = Instantiate(grassPrefab) as GameObject;
				else if (noise[x, y] <= 1) tiles[x, y] = Instantiate(stonePrefab) as GameObject;
				MoveTile(x, y);
			}
		}
	}

	void DeleteTiles(){
		for(int y = 0; y < height; y++){
			for(int x = 0; x < width; x++){
				if (tiles[x, y] != null) Destroy(tiles[x, y]);
				if (lines[x, y] != null) Destroy(lines[x, y]);
			}
		}
	}

	void MoveTile(int x, int y){
		if (tiles[x,y] != null) tiles[x, y].transform.position = new Vector2(x, y);
	}
}
