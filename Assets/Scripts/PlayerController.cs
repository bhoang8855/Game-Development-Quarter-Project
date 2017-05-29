using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Animator anim;
	private bool playerMoving;
	private Vector2 lastMove;
	private bool debug;

    private Rigidbody2D myRigidbody;
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    [SerializeField]
    private BoxCollider2D SwordCollider;

    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator> ();
        myRigidbody = GetComponent<Rigidbody2D>();
        debug = false;		//change if not debugging
	}

    // Update is called once per frame
    void Update()
    {
        // Check if player is in motion
        playerMoving = false;

        if (!attacking)
        {
            // Controls player movement
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                // Move player based on A, D
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                playerMoving = true;
                // Grabs where player was facing for idle animation
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //Move player based on W, D
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                playerMoving = true;
                // Grabs where player was facing for idle animation
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            // Controls player attacking
            if (Input.GetKeyDown(KeyCode.J))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
                SwordCollider.enabled = true;
            }
        }

        if (attackTimeCounter >= 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            SwordCollider.enabled = false;
            anim.SetBool("Attack", false);
        }

        //Kill enemy (for testing)
        if (Input.GetKey(KeyCode.Space) && debug) {
			debugKillEnemy ();
		}
			
		// Animate player moving
		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool("PlayerMoving", playerMoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
	}

    public void MeleeAttack()
    {
        SwordCollider.enabled = !SwordCollider.enabled;
    }

    void debugKillEnemy(){
		GameObject target = GameObject.Find("Enemy Unit(Ground)(Clone)");
		if (target != null) {
			EnemyMovement targetRef = (EnemyMovement)target.GetComponent (typeof(EnemyMovement));
			targetRef.removeAndDestoy ();
		}
	}
}

