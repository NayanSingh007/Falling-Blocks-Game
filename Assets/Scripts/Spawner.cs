﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject fallingObjectPrefab;
	public Vector2 secondsBetweenSpawnsMinMax;
	float nextSpawnTime;
	
	public Vector2 spawnSizeMinMax;
	public float spawnAngleMax;
	
	Vector2 screenHalfSizeWorldUnits;
	
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect*Camera.main.orthographicSize,Camera.main.orthographicSize);
    }

    void Update()
    {
		if(Time.time > nextSpawnTime){
			float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y,secondsBetweenSpawnsMinMax.x, Difficulty.getDifficultyPercent());
			//print(secondsBetweenSpawns);
			nextSpawnTime = Time.time + secondsBetweenSpawns;
			
			float spawnAngle = Random.Range(-spawnAngleMax,spawnAngleMax);
			float spawnSize = Random.Range(spawnSizeMinMax.x,spawnSizeMinMax.y);
			Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x,screenHalfSizeWorldUnits.x),screenHalfSizeWorldUnits.y+spawnSize);
			GameObject newBlock =(GameObject)Instantiate(fallingObjectPrefab,spawnPosition,Quaternion.Euler(Vector3.forward*spawnAngle));
			newBlock.transform.localScale = Vector3.one*spawnSize;
		}
    }
}
