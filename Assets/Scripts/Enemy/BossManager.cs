using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour {
    private PhaseSystem phaseSystemRef;
    private Animator anim;
    public Transform target;
    public GameObject weapon;
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
    public float projectileSpeed;
    public float playerDetectionRange;
    //Hold projectiles and track its direction
    private List<GameObject> projectiles;
    private List<Vector3> associateCoordinate;
    private Vector3 projectileTarget;
    private Vector3 projectileStartDirection;

    //fixing enemy walking towards castle
    private float originAttackRange;

    // Use this for initialization
    void Start () {
        GameObject phaseSystem = GameObject.FindWithTag ("Phase System");
        this.phaseSystemRef = (PhaseSystem) phaseSystem.GetComponent(typeof(PhaseSystem));
        //target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //target = GameObject.Find("Debugging Tower").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        projectiles = new List<GameObject>();
        associateCoordinate = new List<Vector3>();
        isAttacking = false;
        isAttackingTower = false;
        originAttackRange = attackRange;
    }

    // Update is called once per frame
    void Update () {
        if ((Vector3.Distance(transform.position, GameObject.FindWithTag("Player").GetComponent<Transform>().position) < playerDetectionRange) 
            //&& !isAttackingTower
        ) {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            attackRange = originAttackRange;
        }
        else {
            target = GameObject.Find("Castle").GetComponent<Transform>();
            //target = GameObject.Find("Debugging Tower").GetComponent<Transform>();
            attackRange = originAttackRange + 1.3f;
        }
        isMoving = false;
        // two variables to hold last frame position
        float lastX = transform.position.x;
        float lastY = transform.position.y;
        float directionX = 0; float directionY = 0;
        // The enemy will face toward the player
        transform.LookAt(target);
        // rotate the enemy so it will not "turn face" in 2D game
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);


        // Simple attack cooldown system
        if (isAttacking) {
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
            lastMove = new Vector3(directionX, directionY);
            isMoving = true;
        }
        // Attack the player
        else {
            lastMove = new Vector3(target.transform.position.x - lastX, target.transform.position.y - lastY);
            if (!isAttacking) {
                //target.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(1);
                //isAttackingTower = (target.name.Equals("Debugging Tower")) ? true : false;
                GameObject projectile = Instantiate(weapon, transform.position, Quaternion.identity) as GameObject;
                //projectile.transform.localScale = new Vector3(5, 5);
                projectiles.Add(projectile);
                projectileTarget = new Vector2(target.transform.position.x, target.transform.position.y);
                projectileStartDirection = (projectileTarget - projectile.transform.position).normalized;
                associateCoordinate.Add(projectileStartDirection);
                isAttacking = true;
            }
        }

        for (int i = 0; i < projectiles.Count; i++) {
            GameObject goBullet = projectiles[i];
            if (goBullet != null) {
                goBullet.transform.Translate(associateCoordinate[i] * Time.deltaTime * projectileSpeed, Space.World);
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

    public void removeAndDestoy(){      //public for testing
        phaseSystemRef.removeEnemy (this.gameObject);
        Destroy (this.gameObject);
    }

}
