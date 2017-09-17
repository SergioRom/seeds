using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue_btn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public Animator continue_anim, bg_login_register_anim;
	public void continue_btn(){
		continue_anim.Play ("continue_btn");
		bg_login_register_anim.Play ("bg_login_register");
	}


	public Animator register_anim;
	public void RegisterAnim(){
		register_anim.Play ("bg_login_register");
		bg_login_register_anim.Play ("bg_login_register_out");
	}
}
