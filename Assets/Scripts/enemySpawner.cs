using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class enemySpawner : MonoBehaviour {

    public Transform spawn1;
    public Transform spawn2;
    public GameObject enemyPrefab;
    public GameObject Boss;
    public Slider bossHP;
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
            if (!playerInfo.Current.stage1Cleared)
            {
                bossHP.gameObject.SetActive(true);
                Boss.SetActive(true);
            }
            return;
        }
        timer += Time.deltaTime;
	    if (spawnedAmount < totalToSpawn)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + timeBetweenSpawns;
                GameObject temp = Instantiate(enemyPrefab, spawn1.position, spawn1.rotation) as GameObject;
                temp.GetComponent<moveAlongWaypoint>().pathNumber = 1;
                temp = Instantiate(enemyPrefab, spawn2.position, spawn2.rotation) as GameObject;
                temp.GetComponent<moveAlongWaypoint>().pathNumber = 2;
                spawnedAmount += 2;
            }
        }
	}
}
