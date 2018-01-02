﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemySpawner : MonoBehaviour {

    public Transform spawn1;
    public Transform spawn2;
    public GameObject enemyPrefab;
    public GameObject Boss;
    public int totalToSpawn = 20;

    float timer = 0;
    float nextSpawn = 0;
    float timeBetweenSpawns = 2;
    int spawnedAmount = 0;

	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (spawnedAmount >= totalToSpawn && playerInfo.Current.enemiesKilledInStage >= spawnedAmount)
        {    
            if (Boss.GetComponent<enemyHealth>().HP > 0)
                Boss.SetActive(true);
            return;
        }
        timer += Time.deltaTime;
	    if (spawnedAmount < totalToSpawn)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + timeBetweenSpawns;
                Instantiate(enemyPrefab, spawn1.position, spawn1.rotation);
                Instantiate(enemyPrefab, spawn2.position, spawn2.rotation);
                spawnedAmount += 2;
            }
        }
	}
}
