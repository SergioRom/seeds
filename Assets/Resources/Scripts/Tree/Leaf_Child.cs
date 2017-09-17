using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf_Child : MonoBehaviour {

	Animator leaf_anim; 

	// Use this for initialization
	void Start () {
		gameObject.name = "leaf_c_"+Generation.id_leaf;
		Generation.id_leaf++;

		leaf_anim = gameObject.GetComponentInChildren<Animator>();

		//Iniciar diferentes animaciones con diferentes tiempos 
		switch (Generation.leaf_next [1] % 2) {
		case 0:
			leaf_anim.Play("leaf_idle00", -1, ((Generation.leaf_next[1]%100)/100f));
			break;
		case 1:
			leaf_anim.Play("leaf_idle01", -1, ((Generation.leaf_next[1]%100)/100f));
			break;
		}

		//Escoger el sprite de la hoja
		switch (Generation.leaf_next[1] % 12) {
		case 0:
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [0] as Sprite;
			break;
		case 1:
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [1] as Sprite;
			break;
		case 2:
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [2] as Sprite;
			break;
		case 3:
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [10] as Sprite;
			break;
		case 4:
			gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [11] as Sprite;
			break;
		case 5:
			gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [12] as Sprite;
			break;
		case 6:
			gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [20] as Sprite;
			break;
		case 7:
			gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [21] as Sprite;
			break;
		case 8:
			gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [22] as Sprite;
			break;
		case 9:
			gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [30] as Sprite;
			break;
		case 10:
			gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [31] as Sprite;
			break;
		case 11:
			gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [32] as Sprite;
			break;
		}

		Generation.leaf_next[1] = Random.Range (1, int.MaxValue-1);
		Random.InitState (Generation.leaf_next[1]);
	}
}
