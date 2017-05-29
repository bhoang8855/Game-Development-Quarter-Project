using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{

    public int damageToGive;
    public GameObject damageBurst;
    public Transform hitPoint;
    //	public GameObject dmg;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger != true && other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            // Enable damage burst while hitting the enemy
            Instantiate(damageBurst, transform.position, transform.rotation);
            //			// Show damage numbers
            //			var clone = (GameObject) Instantiate (dmg, transform.position, Quaternion.Euler (Vector3.zero));
            //			clone.GetComponent<FloatingNumbers>().dmg = damageToGive;
        }
        if (other.gameObject.tag == "Rock")
        {
            other.gameObject.GetComponent<RockHealthManager>().HurtRock(damageToGive);
            // Enable damage burst while hitting the enemy
            Instantiate(damageBurst, transform.position, transform.rotation);
        }
    }
}
