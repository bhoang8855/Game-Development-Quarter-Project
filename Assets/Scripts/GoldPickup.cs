using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour {

	public int value;
	// public MoneyManager theMM;
	public ResourceManager theRM;

	// Use this for initialization
	void Start () {
		//theMM = FindObjectOfType<MoneyManager> ();
		theRM = FindObjectOfType<ResourceManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			//theMM.AddMoney (value);
			theRM.AddMoney (value);
			Destroy (gameObject);
		}
	}
}
