using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Notebook_btn : MonoBehaviour {
	
	private Animator notebook_anim;
	private bool SetNotebook;
	private RectTransform background_notebook;

	public void IONotebook(){
		GameObject libreta = GameObject.Find ("notebook");
		notebook_anim = libreta.GetComponent<Animator> ();


		background_notebook = GetComponent<RectTransform> ();

		if (SetNotebook == false) {
			notebook_anim.Play ("notebook_in");
			background_notebook.position = new Vector2 (288, 512);
			SetNotebook = true;
		} else {
			notebook_anim.Play ("notebook_out");
			Destroy (gameObject);
			SetNotebook = false;

		}

	}

}
