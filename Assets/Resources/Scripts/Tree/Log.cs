using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Tree {
	
	public GameObject branchToSpawn;

	// Use this for initialization
	void Start () {
		//Determinar su sprite
		int numR = Random.Range (1, int.MaxValue-1);
		SetSprite(gameObject,"Sprites/log",numR%3);
	}
}
