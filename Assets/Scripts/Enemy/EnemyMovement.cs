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
    //For attack management
    private bool isAttacking;
    private bool isAttackingTower;
    private float attackCooldown;
    //Developer input parameters
    public float cooldown;
    public float attackRange;
    public float playerDetectionRange;

	// Use this for initialization
	void Start () {
		GameObject phaseSystem = GameObject.FindWithTag ("Phase System");
		this.phaseSystemRef = (PhaseSystem) phaseSystem.GetComponent(typeof(PhaseSystem));
        //target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //target = GameObject.Find("Debugging Tower").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        isAttacking = false;
        isAttackingTower = false;
	}
	
	// Update is called once per frame
	void Update () {
        if ((Vector3.Distance(transform.position, GameObject.FindWithTag("Player").GetComponent<Transform>().position) < playerDetectionRange) 
            //&& !isAttackingTower
            ) {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
        else {
            target = GameObject.Find("Debugging Tower").GetComponent<Transform>();
        }
        isMoving = false;
        // two variables to hold last frame position
        float lastX = transform.position.x;
        float lastY = transform.position.y;
        float directionX = 0; float directionY = 0;
        // The enemy will face toward the player
        transform.LookAt(target);
        // rotate the enemy so it will not "turn face" in 2D game
        transform.Rotate(new Vector3(0,-90,0),Space.Self);

        // Simple attack cooldown system
        if(isAttacking) {
            if (attackCooldown > 0) {
                attackCooldown -= Time.deltaTime;
            }
            if (attackCooldown < 0) {
                attackCooldown = 0.0f;
            }
        }
        if(attackCooldown == 0) {
            isAttacking = false;
            attackCooldown = cooldown;
        }

        // Move to player
        if (Vector3.Distance(transform.position, target.position) > attackRange) {
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
            directionX = transform.position.x - lastX;
            directionY = transform.position.y - lastY;
            lastMove = new Vector2(directionX, directionY);
            isMoving = true;
        }
        // Attack the player
        else {
            if (!isAttacking) {
                //target.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(1);
                //isAttackingTower = (target.name.Equals("Debugging Tower")) ? true : false;
                isAttacking = true;
            }
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
