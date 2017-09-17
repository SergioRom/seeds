using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafGenerator : MonoBehaviour {


	public int total_leaf_to_spawn;
	public GameObject leafToSpawn;

	// Use this for initialization
	void Start () {
		int leaf_counter = 0;

		for (int i = 0; i < 6; i++) {
			for (int j = 0; j < total_leaf_to_spawn/6; j++) {
				GameObject newLeaf = Instantiate (leafToSpawn);
				newLeaf.name = "leaf_p_" + i + "_" + leaf_counter;
				leaf_counter++;
				//Poner como hijo a la hoja padre
				GameObject branch_parent = GameObject.Find("branch_c_" + i);
				newLeaf.transform.parent = branch_parent.transform;
			}
		}

		Destroy (gameObject, 2.0f);
	}

}
