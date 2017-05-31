using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;
	public GameObject dmg;
	public int meleeDamageTaken;
	public int projectileDamageTaken;
    private AudioSource playerHurt_sfx;
    public AudioClip sound;

    public GameObject GameOverText;
    public PhaseSystem phaseRef;
    private bool restoringHealth;

    // Use this for initialization
    void Start () {
		playerCurrentHealth = playerMaxHealth;
        playerHurt_sfx = GetComponent<AudioSource>();
        GameObject phaseSystem = GameObject.FindWithTag("Phase System");
        this.phaseRef = (PhaseSystem)phaseSystem.GetComponent(typeof(PhaseSystem));
    }
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			gameObject.SetActive (false);
            AudioSource.PlayClipAtPoint(sound, transform.position);
            GameOverText.SetActive(true);
            Invoke("Restart", 3f);
        }

        //restore health here
        if (phaseRef.gatherPhase && !restoringHealth) {
            playerCurrentHealth += 10;
            if (playerCurrentHealth < playerMaxHealth) {
                playerCurrentHealth = playerMaxHealth;
            }
            restoringHealth = true;
        }

        if (phaseRef.battlePhase) {
            restoringHealth = false;
        }

	}

    void Restart()
    {
        SceneManager.LoadScene("Home");
    }

	public void HurtPlayer(int damageToGive) {
		playerCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth() {
		playerCurrentHealth = playerMaxHealth;
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			// Show damage number
			var clone = (GameObject) Instantiate (dmg, transform.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers>().dmg = meleeDamageTaken;
            // Play sfx
            playerHurt_sfx.Play();
        }

		if (other.gameObject.tag == "EnemyProjectile") {
			// Show damage number
			var clone = (GameObject) Instantiate (dmg, transform.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers>().dmg = projectileDamageTaken;
            // Play sfx
            playerHurt_sfx.Play();
		}
	}
}
