using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;
	public GameObject dmg;
	public int meleeDamageTaken;
	public int projectileDamageTaken;


	// Use this for initialization
	void Start () {
		playerCurrentHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			gameObject.SetActive (false);
		}

	}

	public void HurtPlayer(int damageToGive) {
		playerCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth() {
		playerCurrentHealth = playerMaxHealth;
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
