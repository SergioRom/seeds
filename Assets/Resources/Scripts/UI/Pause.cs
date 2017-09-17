using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}

	public void QuitPause(){
		Time.timeScale = 1;
		GameObject pause_obj = GameObject.Find ("pause_ui");
		Destroy (pause_obj);

	}

}
