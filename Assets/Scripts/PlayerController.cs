using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	public float speed = 4.0f;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//Vector to store change in movement.
		var move = new Vector3();

		/*
         * Movement:
         * Player moves using the WASD keys. 
         */

		if (Input.anyKey == false) {
			animator.SetInteger("Direction", 4);
		}
		if (Input.GetKey(KeyCode.A))
		{
			animator.SetInteger("Direction", 3);
			move += Vector3.left;

		}
		if (Input.GetKey(KeyCode.D))
		{
			animator.SetInteger("Direction", 1);
			move += Vector3.right;
		}
		if (Input.GetKey(KeyCode.W))
		{
			animator.SetInteger("Direction", 2);
			move += Vector3.up;
		}
		if (Input.GetKey(KeyCode.S))
		{
			animator.SetInteger("Direction", 0);
			move += Vector3.down;
		}

		transform.position += move * speed * Time.deltaTime;
	}
}
