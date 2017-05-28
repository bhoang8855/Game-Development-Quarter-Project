using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealthManager : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;
	public GameObject log;


	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
	}

	// Update is called once per frame
	void Update () {
		if (CurrentHealth <= 0) {
			Destroy (gameObject);
			Instantiate (log, transform.position, transform.rotation);
		}

	}

	public void HurtTree(int damageToGive) {
		CurrentHealth -= damageToGive;
	}

	public void SetMaxHealth() {
		CurrentHealth = MaxHealth;
	}
}
