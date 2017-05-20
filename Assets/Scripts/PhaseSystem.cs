using UnityEngine;
using System.Collections;

public class PhaseSystem : MonoBehaviour
{
	private int enemiesAlive;
	private int enemiesDead;
	private Countdown countdownRef;
	private EnemySpawner enemySpawnerRef;
	private bool battlePhase;
	private bool gatherPhase;


	// Use this for initialization
	void Start ()
	{
		enemiesAlive = 0;
		enemiesDead = 0;
		GameObject countdown = GameObject.FindWithTag ("Countdown");
		countdownRef = (Countdown) countdown.GetComponent(typeof(Countdown));
		GameObject enemySpawner = GameObject.FindWithTag ("Enemy Spawner");
		enemySpawnerRef = (EnemySpawner) enemySpawner.GetComponent(typeof(EnemySpawner));
		battlePhase = true; //testing
		gatherPhase = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(battlePhase && enemiesDead == enemySpawnerRef.getMaxSpawnCount()){
			startGatherPhase ();
		}
	}

	public void addEnemy(GameObject enemy){
		//possibly can implement a list instead of just a counter
		enemiesAlive++;
	}

	public void removeEnemy(GameObject enemy){
		enemiesAlive--;
		enemiesDead++;
		Debug.Log ("Enemies killed" + enemiesDead + "/" + enemySpawnerRef.getMaxSpawnCount ());

	}

	void startTimer(){
		countdownRef.startTimer ();
	}

	public void timerDone(){
		startBattlePhase ();
	}

	void startGatherPhase(){
		battlePhase = false;
		gatherPhase = true;
		startTimer ();
	}

	void startBattlePhase(){
		gatherPhase = false;
		battlePhase = true;
		enemySpawnerRef.startSpawner (7); //get wave count
		enemiesAlive = 0;
		enemiesDead = 0;
	}
}

