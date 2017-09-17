using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
	
	public Tree(){
		branch_count = 0;
		leaf_count = 0;
	}

	private static int branch_count;
	private static int leaf_count;


	public int GetBranchCount(){
	
		return branch_count;
	}

	public void IncrementBranchCount(){
		branch_count++;
	}

	public int GetLeafCount(){
	
		return leaf_count;
	}



	public void SetSprite(GameObject obj, string dir, int idSprite){
		obj.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> (dir) [idSprite] as Sprite;
	}



}
