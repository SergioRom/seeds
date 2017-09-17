
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf_Parent : Tree_body {

	GameObject branchChild;
	// Use this for initialization
	void Start () {
		//Poner el nombre a la hoja
		//gameObject.name = "leaf_p_"+Generation.total_leaf;
		Generation.total_leaf++;

		//Poner a la hoja como hijo de la rama
		branchChild = transform.parent.gameObject;

		//Su rotación
		int giro = 90;
		if (Generation.leaf_next[0] % 2 == 0) {
			giro += (Generation.leaf_next[0] % 45);
		} else {
			giro -= (Generation.leaf_next[0] % 45);
		}
		if (Generation.leaf_next[0] % 3 == 0) {
			transform.Rotate(0,180,0);
		}
		transform.Rotate(0,0,(giro));

		Generation.leaf_next[0] = Random.Range (1, int.MaxValue-1);
		Random.InitState (Generation.leaf_next[0]);

		//Darle su posición
		Set_Position();
	}


	new void Set_Position(){
		Vector3 posparent = branchChild.transform.position;
		Vector3 posleaf = gameObject.transform.position;
		posleaf = Random.insideUnitCircle * 1.0f;
		posleaf = posleaf + posparent;
		if (Generation.leaf_next [0] % 2 != 0) {
			posleaf.z = 5.5f + Generation.zpos;
		} else {
			posleaf.z = 4.5f - Generation.zpos;
		}
		Generation.zpos = Generation.zpos + 0.001f;
		//Debug.Log (Generation.zpos);
		gameObject.transform.position = posleaf;
	}



}
