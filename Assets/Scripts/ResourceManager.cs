using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

	/* Gold */
	public Text moneyText;
	public int currentGold;

	/* Wood */
	public Text woodText;
	public int currentWood;

	/* Rocks */
	public Text rockText;
	public int currentRock;

	// Use this for initialization
	void Start () {
		//		if (PlayerPrefs.HasKey("CurrentMoney")) {
		//			currentGold = PlayerPrefs.GetInt ("CurrentMoney");
		//		}
		//		else {
		//				currentGold = 0;
		//				PlayerPrefs.SetInt("CurrentMoney", 0);
		//		}

		/* Gold */
		currentGold = 0;
		PlayerPrefs.SetInt ("CurrentMoney", 0);
		moneyText.text = "" + currentGold;

		/* Wood */
		currentWood = 0;
		PlayerPrefs.SetInt ("CurrentWood", 0);
		woodText.text = "" + currentWood;

		/* Rocks */
		currentRock = 0;
		PlayerPrefs.SetInt ("CurrentRock", 0);
		rockText.text = "" + currentRock;

	}

	// Update is called once per frame
	void Update () {

	}

	public void AddMoney(int goldToAdd) {
		currentGold += goldToAdd;
		PlayerPrefs.SetInt ("CurrentMoney", currentGold);
		moneyText.text = "" + currentGold;
	}

	public void AddWood(int woodToAdd) {
		currentWood += woodToAdd;
		PlayerPrefs.SetInt ("CurrentWood", currentWood);
		woodText.text = "" + currentWood;
	}

	public void AddRock(int rockToAdd) {
		currentRock += rockToAdd;
		PlayerPrefs.SetInt ("CurrentRock", 0);
		rockText.text = "" + currentRock;
	}
}
