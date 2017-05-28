using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

	public int damageToGive;
	public GameObject damageBurst;
	public Transform hitPoint;
//	public GameObject dmg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (damageToGive);
			// Enable damage burst while hitting the enemy
			Instantiate (damageBurst, transform.position, transform.rotation);
//			// Show damage numbers
//			var clone = (GameObject) Instantiate (dmg, transform.position, Quaternion.Euler (Vector3.zero));
//			clone.GetComponent<FloatingNumbers>().dmg = damageToGive;
		}
	}
}
