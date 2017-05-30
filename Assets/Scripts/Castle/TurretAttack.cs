using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour {

	private Animator anim;
	//public Transform target;
	public GameObject target;
	public GameObject dmg;
	private bool isAttacking;
	//private bool isAttackingTower;
	private float attackCooldown;
	public float cooldown;
	public GameObject weapon;
	public float attackRange;
	public float projectileSpeed;
	public float enemyDetectionRange;
	private Vector2 lastMove;
	private List<GameObject> projectiles;
	private Vector3 projectileTarget;
	private Vector3 projectileStartDirection;


	public bool isActive;

	// Use this for initialization
	void Start () {
		projectiles = new List<GameObject>();
		isAttacking = false;
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			target = other.gameObject;
			float lastX = transform.position.x;
			float lastY = transform.position.y;
			float directionX = 0; float directionY = 0;

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
			else {
				lastMove = new Vector3(target.transform.position.x - lastX, target.transform.position.y - lastY);
				if (!isAttacking) {
					//target.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(1);
					//isAttackingTower = (target.name.Equals("Debugging Tower")) ? true : false;
					GameObject projectile = Instantiate(weapon, transform.position, Quaternion.identity) as GameObject;
					projectiles.Add(projectile);
					projectileTarget = new Vector2(target.transform.position.x, target.transform.position.y);
					projectileStartDirection = (projectileTarget - projectile.transform.position).normalized;
					isAttacking = true;
				}
			}
			for (int i = 0; i < projectiles.Count; i++) {
				GameObject goBullet = projectiles[i];
				if (goBullet != null) {
					goBullet.transform.Translate(projectileStartDirection * Time.deltaTime * projectileSpeed, Space.World);
				}
			}
		}
	}
}
