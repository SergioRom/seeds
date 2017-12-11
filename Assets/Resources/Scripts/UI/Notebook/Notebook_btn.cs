using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Notebook_btn : MonoBehaviour {
	
	private Animator notebook_anim;
	private bool SetNotebook;
	//private RectTransform background_notebook;

	public void IONotebook(){
		GameObject libreta = GameObject.Find ("notebook");
		notebook_anim = libreta.GetComponent<Animator> ();


		//background_notebook = GetComponent<RectTransform> ();

		if (SetNotebook == false) {
			notebook_anim.Play ("notebook_in");

			SetNotebook = true;
		} else {
			notebook_anim.Play ("notebook_out");
			Destroy (libreta,0.25f);
			Destroy (gameObject);

			SetNotebook = false;

		}

	}

}
