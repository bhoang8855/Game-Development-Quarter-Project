using UnityEngine;
using System.Collections.Generic;

public class ResourceSpawner : MonoBehaviour
{

	private PhaseSystem phaseSystemRef;
	private int spawnCount;
	private int MAX_SPAWN_COUNT = 0;
	public GameObject tree;
	public GameObject rock;
	float randAngle;
	Vector2 whereToSpawn;
	public float spawnRate = 0.5f;
	float nextSpawn = 0.0f;

	// Use this for initialization
	void Start ()
	{
		GameObject phaseSystem = GameObject.FindWithTag ("Phase System");
		this.phaseSystemRef = (PhaseSystem) phaseSystem.GetComponent(typeof(PhaseSystem));

		if (MAX_SPAWN_COUNT == 0)
			MAX_SPAWN_COUNT = 50;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (phaseSystemRef.gatherPhase && spawnCount < MAX_SPAWN_COUNT && Time.time > nextSpawn)
		{
			nextSpawn = Time.time + spawnRate;
			do {
				randAngle = Random.Range (0.0f, 2.0f * Mathf.PI);
				whereToSpawn = new Vector2 (Random.Range(-5.0f,8.0f), Random.Range(-5.0f, 3.0f));
			} while (!checkIfPosEmpty (whereToSpawn));

			float treeOrRock = Random.value;
			if (treeOrRock < 0.5)
				spawnObject (tree, whereToSpawn);
			else
				spawnObject (rock, whereToSpawn);

		}
	}

	void spawnObject(GameObject obj, Vector2 location)
	{
		Debug.Log("Spawning " +obj+ "at "+ whereToSpawn);
		GameObject clone = Instantiate(obj, whereToSpawn, Quaternion.identity) as GameObject;
		spawnCount++;
	}

	bool checkIfPosEmpty(Vector2 targetPos){
		Vector2 size = new Vector2 (0.5f, 0.5f);
		if (Physics2D.OverlapBox(targetPos, size, randAngle)) {
			return false;
		} else {
			return true;
		}
	}
}

