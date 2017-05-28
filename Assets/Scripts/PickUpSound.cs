using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSound : MonoBehaviour {
    public AudioClip sound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Coin" || other.gameObject.tag == "MinedRock" || other.gameObject.tag == "Log") {
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }
}
