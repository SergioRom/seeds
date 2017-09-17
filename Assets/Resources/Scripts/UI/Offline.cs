using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Offline : MonoBehaviour {

	public static bool PlayOff;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Animator newgameanim;
	public Animator bg_login_register_anim;

	public void PlayOffline(){
		PlayOff = true;
		bg_login_register_anim.Play ("bg_login_register_out");
		newgameanim.Play ("new_game_anim_1");
	}
}
