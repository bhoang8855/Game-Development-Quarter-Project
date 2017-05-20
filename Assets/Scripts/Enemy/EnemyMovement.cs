using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	private PhaseSystem phaseSystemRef;
    private Animator anim;
    public Transform target;
    public float moveSpeed = 4f;
    private bool isMoving;
    private Vector2 lastMove;
    //float direction;
	// Use this for initialization
	void Start () {
		GameObject phaseSystem = GameObject.FindWithTag ("Phase System");
		this.phaseSystemRef = (PhaseSystem) phaseSystem.GetComponent(typeof(PhaseSystem));
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        isMoving = false;
        // two variables to hold last frame position
        float lastX = transform.position.x;
        float lastY = transform.position.y;
        float directionX = 0; float directionY = 0;
        // The enemy will face toward the player
        transform.LookAt(target);
        // rotate the enemy so it will not "turn face" in 2D game
        transform.Rotate(new Vector3(0,-90,0),Space.Self);
        // if the enemy and player has a distance greater than 0.3
        if (Vector3.Distance(transform.position, target.position) > 0.3f) {
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
            directionX = transform.position.x - lastX;
            directionY = transform.position.y - lastY;
            lastMove = new Vector2(directionX, directionY);
            isMoving = true;
        }
        transform.rotation = Quaternion.identity;
        // Set the animation moving direction
        anim.SetFloat("moveX", directionX);
        anim.SetFloat("moveY", directionY);
        anim.SetBool("isMoving", isMoving);
        anim.SetFloat("lastMoveX", lastMove.x);
        anim.SetFloat("lastMoveY", lastMove.y);
    }

	public void removeAndDestoy(){		//public for testing
		phaseSystemRef.removeEnemy (this.gameObject);
		Destroy (this.gameObject);
	}
}
