﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class helps to spawn enmey at one location, or randomly
public class EnemySpawner : MonoBehaviour {

	private PhaseSystem phaseSystemRef;
	private int spawnCount;
	private int MAX_SPAWN_COUNT = 0;
    public GameObject enemy;
    float randAngle;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

	// Use this for initialization
	void Start () {
		if(MAX_SPAWN_COUNT == 0)
			MAX_SPAWN_COUNT = 5; //debugging
		//Debug.Log("Started, Max spawn Count is: "+MAX_SPAWN_COUNT);
		GameObject phaseSystem = GameObject.FindWithTag ("Phase System");
		this.phaseSystemRef = (PhaseSystem) phaseSystem.GetComponent(typeof(PhaseSystem));
		spawnCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnCount < MAX_SPAWN_COUNT && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randAngle = Random.Range(0.0f, 2.0f * Mathf.PI);
            float positionX = 3.4f * Mathf.Cos(randAngle);
            float positionY = 3.4f * Mathf.Sin(randAngle);
            whereToSpawn = new Vector2(positionX, positionY);
			spawnEnemy (enemy, whereToSpawn);
			
        }
	}

	void spawnEnemy(GameObject enemy, Vector2 location){
        
        GameObject clone = Instantiate(enemy, whereToSpawn, Quaternion.identity) as GameObject;
        //clone.transform.SetParent(GameObject.FindWithTag("Enemy").transform);
		phaseSystemRef.addEnemy (clone);
		spawnCount++;
		//Debug.Log ("Spawn count: " + spawnCount);
	}

	public int getMaxSpawnCount(){
		return this.MAX_SPAWN_COUNT;
	}

	public void startSpawner(int maxSpawn){
		this.MAX_SPAWN_COUNT = maxSpawn;
		Start ();
	}
}
