using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fake_leaf : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Animator leaf_anim = gameObject.GetComponentInChildren<Animator>();

		//Iniciar diferentes animaciones con diferentes tiempos 
		switch (Generation.leaf_next [1] % 2) {
		case 0:
			leaf_anim.Play("leaf_death", -1, ((Generation.leaf_next[1]%100)/100f));
			break;
		case 1:
			leaf_anim.Play("leaf_death_2", -1, ((Generation.leaf_next[1]%100)/100f));
			break;
		}
		//Escoger el sprite de la hoja
		switch (Gameplay_Stats.season) {
		case 0:
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
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [12] as Sprite;;
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
			break;
		case 1:
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
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [12] as Sprite;;
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
			break;
		case 2:
			switch (Generation.leaf_next[1] % 12) {
			case 0:
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [40] as Sprite;
				break;
			case 1:
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [41] as Sprite;
				break;
			case 2:
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [42] as Sprite;
				break;
			case 3:
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [50] as Sprite;
				break;
			case 4:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [51] as Sprite;
				break;
			case 5:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [52] as Sprite;;
				break;
			case 6:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [60] as Sprite;
				break;
			case 7:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [61] as Sprite;
				break;
			case 8:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [62] as Sprite;
				break;
			case 9:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [70] as Sprite;
				break;
			case 10:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [71] as Sprite;
				break;
			case 11:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [72] as Sprite;
				break;
			}
			break;
		case 3:
			switch (Generation.leaf_next[1] % 12) {
			case 0:
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [40] as Sprite;
				break;
			case 1:
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [41] as Sprite;
				break;
			case 2:
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [42] as Sprite;
				break;
			case 3:
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [50] as Sprite;
				break;
			case 4:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [51] as Sprite;
				break;
			case 5:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [52] as Sprite;;
				break;
			case 6:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [60] as Sprite;
				break;
			case 7:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [61] as Sprite;
				break;
			case 8:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [62] as Sprite;
				break;
			case 9:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [70] as Sprite;
				break;
			case 10:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [71] as Sprite;
				break;
			case 11:
				gameObject.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [72] as Sprite;
				break;
			}
			break;
		}

		Generation.leaf_next[1] = Random.Range (1, int.MaxValue-1);
		Random.InitState (Generation.leaf_next[1]);
		StartCoroutine (DeleteLeaf ());
	}
		
	IEnumerator DeleteLeaf(){
		yield return new WaitForSeconds (2.5f);
		Destroy (gameObject);
	}
}
