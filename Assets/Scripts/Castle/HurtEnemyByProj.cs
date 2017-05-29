using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyByProj : MonoBehaviour {

	public int damageToGive;
	public GameObject damageBurst;
	public GameObject dmg;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "Enemy Unit(Ground)(Clone)") {
			other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (damageToGive);
			Destroy(this.gameObject);
			// Enable damage burst while hitting the enemy
			Instantiate (damageBurst, transform.position, transform.rotation);
			//			// Show damage numbers
			var clone = (GameObject) Instantiate (dmg, transform.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers>().dmg = damageToGive;
		}
	}
}
