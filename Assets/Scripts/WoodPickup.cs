using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPickup : MonoBehaviour {

	public int value;
	//public WoodManager theWM;
	public ResourceManager theRM;

	// Use this for initialization
	void Start () {
		//theWM = FindObjectOfType<WoodManager> ();
		theRM = FindObjectOfType<ResourceManager> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			//theWM.AddWood (value);
			theRM.AddWood (value);
			Destroy (gameObject);
		}
	}
}
