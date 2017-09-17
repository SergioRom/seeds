using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Newgame_btn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void continue_newgame(){
		/*Generation.total_leaf = 0;
		Gameplay_Stats.week = 1;
		Gameplay_Stats.season = 0;
		Generation.zpos = 0;*/
		Time.timeScale = 1;
		Restart.restart = true;
		if (Offline.PlayOff == false) {
			Gameplay_Stats.cant_hoja = Gameplay_Stats.leafloss;

			Gameplay_Stats.semana = Gameplay_Stats.week;
			Debug.Log ("Semana1:"+Gameplay_Stats.semana);
			Debug.Log ("Semana2:"+Gameplay_Stats.week);
			StartCoroutine (new_game ());
		} else {
			SceneManager.LoadScene ("mainmenu",LoadSceneMode.Single);
		}
	}

	IEnumerator new_game(){
		WWW new_game_connection = new WWW ("https://intento01.000webhostapp.com/new_tree.php?tipo_arbol="+Gameplay_Stats.tipo_arbol+"&cant_hoja="+Gameplay_Stats.cant_hoja+"&semana="+Gameplay_Stats.semana+"&cuidado="+Gameplay_Stats.cuidado+"&lluvia="+Gameplay_Stats.lluvia+"&us_arbol="+Gameplay_Stats.us_arbol+"&rayo_caido="+Gameplay_Stats.rayo_caido);
		yield return(new_game_connection);
		SceneManager.LoadScene ("mainmenu",LoadSceneMode.Single);
	}

}
