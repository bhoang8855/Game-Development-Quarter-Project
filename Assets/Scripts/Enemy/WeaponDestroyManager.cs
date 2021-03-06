﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDestroyManager : MonoBehaviour {

    public float lifetime = 0.0f;
	// Use this for initialization
	void Awake () {
        Destroy(this.gameObject, lifetime);
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Destroy(this.gameObject);
        }
    }
}
