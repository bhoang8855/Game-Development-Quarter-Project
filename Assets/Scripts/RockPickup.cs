using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPickup : MonoBehaviour {

	public int value;
	public ResourceManager theRM;
	// Use this for initialization
	void Start () {
		theRM = FindObjectOfType<ResourceManager> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			theRM.AddRock (value);
			Destroy (gameObject);
		}
	}
}