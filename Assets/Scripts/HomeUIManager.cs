using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeUIManager : MonoBehaviour {

    public void StartGame() {
        StartCoroutine(WaitDuration());
	}

	public void QuitGame() {
		Application.Quit ();
	}

    IEnumerator WaitDuration() {
        float floatTime = GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(floatTime);
        SceneManager.LoadScene("Level1");
    }
        
}
