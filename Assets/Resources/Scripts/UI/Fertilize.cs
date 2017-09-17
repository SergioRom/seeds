using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fertilize : MonoBehaviour {

	public Button fertilize_btn;
	public static bool ActiveFertilize;

	// Use this for initialization
	void Start () {
		ActiveFertilize = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FertilizeTree(){
		if (ActiveFertilize == false) {
			ActiveFertilize = true;
			fertilize_btn.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/actions2_btn") [7] as Sprite;
		} else {
			ActiveFertilize = false;
			fertilize_btn.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/actions2_btn") [2] as Sprite;
		}

		Gameplay_Stats.cuidado++;
	}
}
