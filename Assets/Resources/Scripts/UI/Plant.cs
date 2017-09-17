using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour {

	public Button plant_btn;
	public static bool ActivePlant;
	// Use this for initialization
	void Start () {
		ActivePlant = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlantFlower(){
		if (Gameplay_Stats.flowerscount < 8) {
			if (ActivePlant == false) {
				ActivePlant = true;
				plant_btn.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/actions2_btn") [8] as Sprite;
			} else {
				ActivePlant = false;
				plant_btn.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/actions2_btn") [3] as Sprite;
			}
		}


		Gameplay_Stats.cuidado++;
	}
}
