﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtCastle : MonoBehaviour {

	public int damageToGive;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "Castle") {
			other.gameObject.GetComponent<CastleHealthManager> ().HurtCastle (damageToGive);
			Destroy(this.gameObject);
		}
	}
}