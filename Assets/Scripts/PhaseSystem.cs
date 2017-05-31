using UnityEngine;
using System.Collections;

public class PhaseSystem : MonoBehaviour
{
	private int enemiesAlive;
	private int enemiesDead;
	private Countdown countdownRef;
	private EnemySpawner enemySpawnerRef;
	public bool battlePhase;
	public bool gatherPhase;
	public int NUMWAVES;

	// Use this for initialization
	void Start ()
	{
		enemiesAlive = 0;
		enemiesDead = 0;
		NUMWAVES = 0;
		GameObject countdown = GameObject.FindWithTag ("Countdown");
		countdownRef = (Countdown) countdown.GetComponent(typeof(Countdown));
		GameObject enemySpawner = GameObject.FindWithTag ("Enemy Spawner");
		enemySpawnerRef = (EnemySpawner) enemySpawner.GetComponent(typeof(EnemySpawner));
		startBattlePhase ();
		//startGatherPhase (); 	//testing
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
		Debug.Log ("Spawned " + enemy + " ("+enemiesAlive+"/" + enemySpawnerRef.getMaxSpawnCount () + ")");
	}

	public void removeEnemy(GameObject enemy){
		enemiesAlive--;
		enemiesDead++;
		Debug.Log ("Enemies killed" + enemiesDead + "/" + enemySpawnerRef.getMaxSpawnCount ());
	}

	void startTimer(float time){
		countdownRef.startTimer (time);
	}

	void startTimer(){
		countdownRef.startTimer ();
	}

	public void timerDone(){
		startBattlePhase ();
	}

	void startGatherPhase(){
		Debug.Log ("Gather Phase");
		battlePhase = false;
		gatherPhase = true;
		startTimer (30f);	//Timer for Gather Phase
	}

	void startBattlePhase(){
		gatherPhase = false;
		battlePhase = true;
		NUMWAVES++;
		Debug.Log ("Battle Phase - Wave #: " + NUMWAVES);
		resetCounters();
		enemySpawnerRef.startSpawner (5 + 2*(NUMWAVES - 1)); //MAX SPAWN = 5 + 2*NUMWAVES, e.g. Wave 1 = 5, 2 = 7, 3 = 9, etc.
	}

	void resetCounters(){
		enemiesDead = 0;
		enemiesAlive = 0;
	}
}

