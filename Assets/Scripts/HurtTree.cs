using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtTree : MonoBehaviour {

	public int damageToGive;
	public GameObject damageBurst;
	public Transform hitPoint;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Tree") {
			other.gameObject.GetComponent<TreeHealthManager> ().HurtTree (damageToGive);
			// Enable damage burst while hitting the enemy
			Instantiate (damageBurst, transform.position, transform.rotation);
		}
	}
}
