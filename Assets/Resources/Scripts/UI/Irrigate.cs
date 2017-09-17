using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Irrigate : MonoBehaviour {

	public Button irrigate_btn;
	public static bool ActiveIrrigation, AI2;
	// Use this for initialization
	void Start () {
		ActiveIrrigation = false;
		AI2 = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void IrrigateTree(){
		if (ActiveIrrigation == false) {
			ActiveIrrigation = true;
			AI2 = true;
			irrigate_btn.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/actions2_btn") [6] as Sprite;
		}else{
			ActiveIrrigation = false;
			AI2 = false;
			irrigate_btn.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/actions2_btn") [1] as Sprite;
		}

		//Debug.Log (ActiveIrrigation);
		Gameplay_Stats.cuidado++;
	}
}
