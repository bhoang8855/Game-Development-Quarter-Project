using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text HPText;
	public PlayerHealthManager playerHealth;
	public Text CastleHP;
	public CastleHealthManager castle;


	// Use this for initialization
	void Start () {
		//CastleHP = (Text) GameObject.FindWithTag("CastleHP").GetComponent(typeof(Text));
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
		CastleHP.text = "Castle HP: " + castle.castleCurrentHealth + "/" + castle.castleMaxHealth;
	}
}
