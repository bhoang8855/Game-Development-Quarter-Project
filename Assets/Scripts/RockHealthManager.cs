using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHealthManager : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;
	public GameObject mined_rock;


	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
	}

	// Update is called once per frame
	void Update () {
		if (CurrentHealth <= 0) {
			Destroy (gameObject);
			Instantiate (mined_rock, transform.position, transform.rotation);
		}

	}

	public void HurtRock(int damageToGive) {
		CurrentHealth -= damageToGive;
	}

	public void SetMaxHealth() {
		CurrentHealth = MaxHealth;
	}
}
