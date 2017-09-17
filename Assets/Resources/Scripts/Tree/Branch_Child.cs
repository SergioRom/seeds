using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch_Child : MonoBehaviour {


	private Animator branch_anim;
	// Use this for initialization
	void Start () {
		
		branch_anim = gameObject.GetComponentInChildren<Animator>();
		int numR = Random.Range (1, int.MaxValue-1);
		if (numR % 2 == 0) {
			branch_anim.Play("branch_idle00", -1, ((numR%100)/100f));
		} else {
			branch_anim.Play("branch_idle01", -1, ((numR%100)/100f));
		}

	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere (gameObject.transform.position, 1.0f);
	}

}
