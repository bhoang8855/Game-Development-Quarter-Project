using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtRock : MonoBehaviour {

	public int damageToGive;
	public GameObject damageBurst;
	public Transform hitPoint;
    public AudioClip sound;

    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Rock") {
			other.gameObject.GetComponent<RockHealthManager> ().HurtRock (damageToGive);
			// Enable damage burst while hitting the enemy
			Instantiate (damageBurst, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
	}
}
