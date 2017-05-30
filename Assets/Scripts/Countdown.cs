using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
	private PhaseSystem phaseSystemRef;
	public bool status;
	public float timeLeft;
	public float defTimeLimit = 30.0f;
	public Text text;

	// Use this for initialization
	void Start ()
	{
		GameObject phaseSystem = GameObject.FindWithTag ("Phase System");
		this.phaseSystemRef = (PhaseSystem) phaseSystem.GetComponent(typeof(PhaseSystem));

		timeLeft = defTimeLimit;	//can change
		status = false;
		text = (Text) GameObject.FindWithTag("CountdownText").GetComponent(typeof(Text));
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timeLeft < 0)
			endTimer ();
		if (status == true) {
			timeLeft -= Time.deltaTime;
			text.text = "Gather Phase: " + Mathf.Round (timeLeft);
		} else if (status == false) {
			text.text = "Battle Phase";
		}
	}

	public void startTimer(float time){
		defTimeLimit = time;
		status = true;
	}

	public void startTimer(){
		status = true;
	}

	void endTimer(){
		phaseSystemRef.timerDone ();
		timeLeft = defTimeLimit;
		status = false;
	}
}

