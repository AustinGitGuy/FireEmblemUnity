using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise{

	public static float[,] GenerateNoiseMap(int width, int height, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset){

		//Persistance increases the randomness of the heightmap. More persistance = less continuity
		//Lacunarity will decrease the size of the sections. Higher lacunarity = less section continuity
		//Octaves also affect section continuty but a real lower value or a real high value will increase continuity
		//Scale will zoom in on the level, increasing the size of specific sections

		System.Random rando = new System.Random(seed);
		Vector2[] octaveOffset = new Vector2[octaves];

		float maxNoise = float.MinValue;
		float minNoise = float.MaxValue;

		float halfWidth = width / 2f;
		float halfHeight = height / 2f;

		for(int i = 0; i < octaves; i++){
			float offX = rando.Next(-100000, 100000) + offset.x;
			float offY = rando.Next(-100000, 100000) + offset.y;
			octaveOffset[i] = new Vector2(offX, offY);
		}

		float[,] noiseMap = new float[width, height];
		if (scale <= 0) scale = 0.001f;

		for(int y = 0; y < height; y++){
			for(int x = 0; x < width; x++){
				float amplitude = 1;
				float frequency = 1;
				float noiseHeight = 0;

				for(int i = 0; i < octaves; i++){
					float sampleX = (x - halfWidth) / scale * frequency + octaveOffset[i].x;
					float sampleY = (y - halfHeight) / scale * frequency + octaveOffset[i].y;

					float perlin = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
					noiseHeight += perlin * amplitude;

					amplitude *= persistance;
					frequency *= lacunarity;
				}
				if (noiseHeight > maxNoise) maxNoise = noiseHeight;
				else if (noiseHeight < minNoise) minNoise = noiseHeight;
				noiseMap[x, y] = noiseHeight;
			}
		}

		for(int y = 0; y < height; y++){
			for(int x = 0; x < width; x++){
				noiseMap[x, y] = Mathf.InverseLerp(minNoise, maxNoise, noiseMap[x, y]);
			}
		}
		return noiseMap;
	}

	public static float[] GenerateNoiseMap(int width, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset){

		System.Random rando = new System.Random(seed);
		Vector2[] octaveOffset = new Vector2[octaves];

		float maxNoise = float.MinValue;
		float minNoise = float.MaxValue;

		float halfWidth = width / 2f;

		float offY = 0;

		for(int i = 0; i < octaves; i++){
			float offX = rando.Next(-100000, 100000) + offset.x;
			octaveOffset[i] = new Vector2(offX, offY);
		}

		float[] noiseMap = new float[width];
		if (scale <= 0) scale = 0.001f;

		for(int x = 0; x < width; x++){
			float amplitude = 1;
			float frequency = 1;
			float noiseHeight = 0;

			for (int i = 0; i < octaves; i++) {
				float sampleX = (x - halfWidth) / scale * frequency + octaveOffset[i].x;
				float sampleY = 0;

				float perlin = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
				noiseHeight += perlin * amplitude;

				amplitude *= persistance;
				frequency *= lacunarity;
			}
			if (noiseHeight > maxNoise) maxNoise = noiseHeight;
			else if (noiseHeight < minNoise) minNoise = noiseHeight;
			noiseMap[x] = noiseHeight;
		}
			
		for(int x = 0; x < width; x++){
			noiseMap[x] = Mathf.InverseLerp(minNoise, maxNoise, noiseMap[x]);
		}
		return noiseMap;
	}

}
