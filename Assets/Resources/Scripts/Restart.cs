using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {



	public static bool restart;

	public Animator continue_anim, newgame;
	// Use this for initialization
	void Start () {
		if (restart == true) {
			continue_anim.Play ("continue_btn");
			newgame.Play ("new_game_anim_1");
			restart = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
}
