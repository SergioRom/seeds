using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {




//	static bool light=false;
	// Use this for initialization
	void Start () {
		//InvokeRepeating("NewLight",1,1);
		InvokeRepeating("NewLight",((Generation.lightning_next%5)+3),((Generation.lightning_next%7)+5));
		//InvokeRepeating("NewLight", (4%1)+0, 0.0f);
	}

	void Update(){
		if (Gameplay_Stats.weather_1 == 4) {
			Animator anim = GetComponent<Animator> ();
			anim.Play ("Empty");
		}
	}
	void NewLight(){
		if (Gameplay_Stats.weather_1 == 5) {
			Animator anim = GetComponent<Animator> ();
			switch (Generation.lightning_next % 5) {
			case 0:
				anim.Play ("l_1");
				break;
			case 1:
				anim.Play ("l_2");
				break;
			case 2:
				anim.Play ("l_3");
				break;
			case 3:
				anim.Play ("l_4");
				break;
			case 4:
				anim.Play ("l_5");
				break;
			}

			Generation.lightning_next = Random.Range (1, int.MaxValue - 1);
			Random.InitState (Generation.lightning_next);
		} 
	}

}


