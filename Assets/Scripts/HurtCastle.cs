using System.Collections;
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

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Castle") {
			other.gameObject.GetComponent<CastleHealthManager> ().HurtCastle (damageToGive);
            if (gameObject.tag != "Enemy")
		    	Destroy(this.gameObject);
		}
	}
}
