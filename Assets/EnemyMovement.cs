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
        transform.LookAt(target);
        transform.Rotate(new Vector3(0,-90,0),Space.Self);
        if (Vector3.Distance(transform.position,target.position)>1f){//move if distance from target is greater than 1
            transform.Translate(new Vector3(moveSpeed* Time.deltaTime, 0, 0) );
        }
        transform.rotation = Quaternion.identity;
	}

	public void removeAndDestoy(){		//public for testing
		phaseSystemRef.removeEnemy (this.gameObject);
		Destroy (this.gameObject);
	}
}
