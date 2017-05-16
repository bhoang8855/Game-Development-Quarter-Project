using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class helps scene to fade in or fade out
public class Fading : MonoBehaviour {
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000;
	// Default visible
	private float alpha = 1.0f;
	private int fadeDir = -1;

   // Method: OnGUI
   // Purpose: override and draw a black screen based on its alpha value
	void OnGUI() {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

   // Method: BeginFade
   // Purpose: return the fadeSpeed for outside IEnumrator function
   // it the direction is 1, it is fading out
   // if the direction is -1, it is fading in
	public float BeginFade (int direction) {
		fadeDir = direction;
        return fadeSpeed;
	}

   // Method: OnLevelWasLoaded
   // Purpose: override, set begin to fade when level is loaded
	void OnLevelWasLoaded() {
		BeginFade(-1);
	}
}
