using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int damageTaken;
	public int castleDamageTaken;
	public int MaxHealth;
	public int CurrentHealth;
	public GameObject coin;
	public GameObject dmg;


	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
	}

	// Update is called once per frame
	void Update () {
		if (CurrentHealth <= 0) {
			// kill the enemy
			Destroy (gameObject);
			// enemy leaves a coin
			Instantiate (coin, transform.position, transform.rotation);
		}

	}

	public void HurtEnemy(int damageToGive) {
		CurrentHealth -= damageToGive;
	}

	public void SetMaxHealth() {
		CurrentHealth = MaxHealth;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			// Show damage number
			var clone = (GameObject) Instantiate (dmg, transform.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers>().dmg = damageTaken;
		}
		if (other.gameObject.tag == "CastleProjectile") {
			// Show damage number
			var clone1 = (GameObject) Instantiate (dmg, transform.position, Quaternion.Euler (Vector3.zero));
			clone1.GetComponent<FloatingNumbers>().dmg = castleDamageTaken;
		}
	}
}
