using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This class manages home screen UI, provides
// some basic functions such as Start game and 
// Quit Game.
public class HomeUIManager : MonoBehaviour {

   // Methid: StartGame
   // Purpose: When user pressed start button,
   // the game will move to scene Level1
    public void StartGame() {
        StartCoroutine(WaitDuration());
	}

   // Method: QuitGame
   // Purpose: When user pressed quit button,
   // the game will quit.
	public void QuitGame() {
		Application.Quit ();
	}

   // Method: WaitDuration
   // Purpose: The scene will fade out based on time when it
   // faded in eariler.
    IEnumerator WaitDuration() {
        float floatTime = GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(floatTime);
        SceneManager.LoadScene("Level1");
    }
}
