using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpgrade : MonoBehaviour {

	private int playerMax;
	private int playerCurrent;
	private Button button = null;
	public int healthUpgrade = 10;
	string tag;


	// Use this for initialization
	void Start () {
		button = gameObject.GetComponent<Button> ();
		button.onClick.AddListener(() =>{Click();});
		tag = transform.tag;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Click() {
		GameObject.FindGameObjectWithTag("Player").SendMessage ("UpgradeMaxHealth");
		//playerCurrent = GameObject.FindGameObjectWithTag("Player").SendMessage ("PlayerCurrentHealth");


	}
}
