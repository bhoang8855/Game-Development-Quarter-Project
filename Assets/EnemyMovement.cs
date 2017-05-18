using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    //Rigidbody rb;
	private PhaseSystem phaseSystemRef;
    public Transform target;
    public float moveSpeed = 4f;
    //float direction;
	// Use this for initialization
	void Start () {
		GameObject phaseSystem = GameObject.FindWithTag ("Phase System");
		this.phaseSystemRef = (PhaseSystem) phaseSystem.GetComponent(typeof(PhaseSystem));
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        // The enemy will face toward the player
        transform.LookAt(target);
        // rotate the enemy so it will not "turn face" in 2D game
        transform.Rotate(new Vector3(0,-90,0),Space.Self);
        // if the enemy and player has a distance greater than 0.5
        if (Vector3.Distance(transform.position,target.position)>0.2f){
            transform.Translate(new Vector3(moveSpeed* Time.deltaTime, 0, 0) );
        }
        transform.rotation = Quaternion.identity;
	}

	public void removeAndDestoy(){		//public for testing
		phaseSystemRef.removeEnemy (this.gameObject);
		Destroy (this.gameObject);
	}
}
