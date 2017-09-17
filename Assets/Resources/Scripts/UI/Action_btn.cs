using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_btn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Animator actions_anim;
	public bool actions = false;
	public void actions_menu(){
		if (actions == false) {
			actions_anim.Play ("actions_anim01");
			actions = true;
		} else {
			actions_anim.Play ("actions_anim02");
			actions = false;
		}
	}
}
