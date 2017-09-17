using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Generation : MonoBehaviour {
	
	///////////////////////////////////////////////////////////////////
	//Variables estáticas
	//Contadores: tronco, ramas y hojas
	public static int total_branch, total_leaf, total_leafdeath;
	public static int id_leaf;
	///////////////////////////////////////////////////////////////////
	//Variables para modulos %
	//Número del que dependerá el sprite del tronco
	public static int log_next;
	//Par de números de los que dependerá la posición/rotación de la hoja y su sprite
	public static int[] leaf_next = new int[2]; //0 - Para posición; 1 - Para sprite;
	//Para no sobreponer hojas
	public static float zpos = 0;
	//Par de números de los que dependerá la posición/rotación de la rama y su sprite
	public static int[] branch_next = new int[2]; //0 - Para posición; 1 - Para sprite;
	//Número del que dependerá el clima
	public static int weather_next;
	//Número del que dependerá la temperatura;
	public static int temp_next;
	//Número del que dependerá la nube
	public static int cloud_next;
	//Número del que dependerá los rayos
	public static int lightning_next;
	int total_cloud;
	//Número del que dependerá la hoja a morir
	public static int leaftodie_next;


	//Para mantener seed, borrar en el futuro
	public static int RandomSeed;
	public static bool mantenerseed;
	public Button seed_btn;


	public GameObject cloud_prefab;
	void Start(){
		//Inicia los contadores a 0
		total_branch = 0;
		total_leaf = 0;
		id_leaf = 0;
		total_leafdeath = 0;

		if (mantenerseed == false) {
			RandomSeed = (int)System.DateTime.Now.Ticks;
		} else {
			seed_btn.GetComponent<Image>().color = new Color(0.2F, 0.3F, 0.4F, 1F);
		}
		Debug.Log ("Random Seed = " + RandomSeed);
		//La seed determirará los siguientes números "random"
		Random.InitState (RandomSeed);

		//Valores iniciales
		for (int i = 0; i < 2; i++) {
			leaf_next[i] = Random.Range (1, int.MaxValue-1);
			Random.InitState (leaf_next[i]);
			branch_next[i] = Random.Range (1, int.MaxValue-1);
			Random.InitState (branch_next[i]);
		}

		weather_next = Random.Range (1, int.MaxValue-1);
		Random.InitState (weather_next);
		//Debug.Log (weather_next);

		temp_next = Random.Range (1, int.MaxValue-1);
		Random.InitState (temp_next);
		//Debug.Log (temp_next);

		cloud_next = Random.Range (1, int.MaxValue-1);
		Random.InitState (cloud_next);
		//Debug.Log (cloud_next);

		lightning_next = Random.Range (1, int.MaxValue-1);
		Random.InitState (lightning_next);
		//Debug.Log (lightning_next);

		leaftodie_next = Random.Range (1, int.MaxValue-1);
		Random.InitState (leaftodie_next);
		//Debug.Log (leaftodie_next);

		total_leaf = 0;

		Gameplay_Stats.week = 1;
		Gameplay_Stats.season = 0;
		zpos = 0;
		total_cloud = 0;
		NewCloud ();
		InvokeRepeating("NewCloud", (cloud_next%5)+15, 25.0f);
	}

	void NewCloud () {
		GameObject newcloud = Instantiate (cloud_prefab);
		newcloud.name = "cloud_" + total_cloud;
		total_cloud++;
	}

	public void MantenerSeed(){
		if (mantenerseed == false) {
			mantenerseed = true;
			seed_btn.GetComponent<Image>().color = new Color(0.2F, 0.3F, 0.4F, 1.0F);
		} else {
			mantenerseed = false;
			seed_btn.GetComponent<Image>().color = Color.white;
		}
		Debug.Log (mantenerseed);
	}
}
