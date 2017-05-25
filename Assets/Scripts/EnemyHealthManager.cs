﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;
	public GameObject coin;


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
}
