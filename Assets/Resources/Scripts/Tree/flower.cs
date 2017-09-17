using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Animator flower_anim = gameObject.GetComponent<Animator>();
		flower_anim.Play("flower_1", -1, ((Generation.leaf_next[1]%100)/100f));
		Generation.leaf_next[1] = Random.Range (1, int.MaxValue-1);
		Random.InitState (Generation.leaf_next[1]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
