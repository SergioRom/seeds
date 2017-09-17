using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cut : MonoBehaviour {
	public Button cut_btn;
	public static bool ActiveCut;
	// Use this for initialization
	void Start () {
		ActiveCut = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CutTree(){
		if (Gameplay_Stats.cutcount < 3) {
			if (ActiveCut == false) {
				ActiveCut = true;
				cut_btn.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/actions2_btn") [5] as Sprite;
			} else {
				ActiveCut = false;
				cut_btn.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/actions2_btn") [0] as Sprite;
			}
		}


		Gameplay_Stats.cuidado++;
	}
}
