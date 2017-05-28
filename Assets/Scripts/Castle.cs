using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour {
	public int castleMaxHealth;
	public int castleCurrentHealth;
	public GameObject dmg;
	public int meleeDamageTaken;
	public int projectileDamageTaken;

	// Use this for initialization
	void Start () {
		castleCurrentHealth = castleMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (castleCurrentHealth <= 0) {
			gameObject.SetActive (false);
		}
	}

	public void HurtCastle(int damageToGive) {
		castleCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth() {
		castleCurrentHealth = castleMaxHealth;
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			// Show damage number
			var clone = (GameObject) Instantiate (dmg, transform.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers>().dmg = meleeDamageTaken;


		}

		if (other.gameObject.tag == "EnemyProjectile") {
			// Show damage number
			var clone = (GameObject) Instantiate (dmg, transform.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers>().dmg = projectileDamageTaken;

	
		}
	}
}
