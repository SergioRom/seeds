using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Next : MonoBehaviour {


	//Botón del tiempo
	public Button weather_btn;
	//Imágenes y texto del panel del tiempo
	public GameObject fakeleaf_obj;
	public Button cut, irr, fer, plant;
	bool gameover = false;
	int lifetoloss;
	public Sprite[] leafsprites = new Sprite[80]; 
	public Sprite[] flowers = new Sprite[2]; 
	public Animator texto_go;
	static int noirrigate;
	void Start(){
		lifetoloss = 0;
		noirrigate = 1;

		temperature ();

		//wheather ();
	}

	//Boton "Siguiente"
	public void NextTurn(){
		if (gameover == false) {
			Debug.Log (Gameplay_Stats.leafloss);


			//Aumenta la semana
			Gameplay_Stats.week++;
//			Debug.Log ("Semana: "+Gameplay_Stats.week);
			cuttree ();
			lifeloss ();

			wheather ();
			//lifeloss ();
			healthbar ();

			//Background
			change_season_image ();
			//Cantidad de semanas
			temperature ();
			flower_sprites ();
			actions_sprites ();
			fertilize ();


		}
	}

	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////
	void change_season_image(){//Cambia la imagen de background
		GameObject bg = GameObject.Find("background");
		if (Gameplay_Stats.week % 13 == 0) {
			Gameplay_Stats.season++;
			if (Gameplay_Stats.season > 3) {
				Gameplay_Stats.season = 0;
			}
			//Cambia el texto de la estación

			leafsprite ();

			flower_sprites_empty ();
			Gameplay_Stats.flowerscount = 0;
			Gameplay_Stats.fercount = 0;
			Debug.Log ("Estación: "+ Gameplay_Stats.season);

			GameObject hojas_fondo = GameObject.Find ("hojas_falsas");
			if (Gameplay_Stats.season == 0 || Gameplay_Stats.season == 1) {
				if (Gameplay_Stats.leafloss <= 35) {
					hojas_fondo.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/copaFinal") [0] as Sprite;
				} else if (Gameplay_Stats.leafloss <= 70) {
					hojas_fondo.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/copaFinal") [1] as Sprite;
				} else if (Gameplay_Stats.leafloss <= 300) {
					hojas_fondo.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/copaFinal") [2] as Sprite;
				}
			} else if (Gameplay_Stats.season == 2 || Gameplay_Stats.season == 3) {
				if (Gameplay_Stats.leafloss <= 35) {
					hojas_fondo.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/copaFinal") [3] as Sprite;
				} else if (Gameplay_Stats.leafloss <= 70) {
					hojas_fondo.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/copaFinal") [4] as Sprite;
				} else if (Gameplay_Stats.leafloss <= 300) {
					hojas_fondo.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/copaFinal") [5] as Sprite;
				}
			}
		}
		//Cambiar el sprite del fondo
		if (Gameplay_Stats.weather_1 == 4 || Gameplay_Stats.weather_1 == 5) {
			bg.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/Background") [Gameplay_Stats.season+4] as Sprite;
		} else {
			bg.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/Background") [Gameplay_Stats.season] as Sprite;
		}
	}
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 	/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Este será el tiempo que estará la siguiente semana
	void new_weather(){
		//El tiempo 1 es el que esta en el turno presente, el tiempo 2 es el que estará en el siguiente turno
		//Ambos se inicializan en 0
		//El tiempo 1 toma el valor del tiempo 2
		Gameplay_Stats.weather_1 = Gameplay_Stats.weather_2;
		Gameplay_Stats.weather_2 = Generation.weather_next % 6;
		//Bajar probabilidad a tormenta
		if(Gameplay_Stats.weather_2 == 5){
			//El número de probabilidad para el tiempo vuelve a cambiar
			Generation.weather_next = Random.Range (1, int.MaxValue-1);
			Random.InitState (Generation.weather_next);
			if (Generation.weather_next % 2 != 0) {//Si es 0 se mantiene en tormenta
				if (Generation.weather_next % 3 == 1) {
					Gameplay_Stats.weather_2 = 2; //Si es 1 es nublado
				} else {
					Gameplay_Stats.weather_2 = 4; //Si es 2 es lluvia
				}
			}
		}
		if (Gameplay_Stats.weather_1 == 4 || Gameplay_Stats.weather_1 == 5) {
			Gameplay_Stats.lluvia++;
		}
		Generation.weather_next = Random.Range (1, int.MaxValue-1);
		Random.InitState (Generation.weather_next);
	}

	void wheather(){
		//Tiempo
		new_weather();
		//Cambiar sprite
		weather_btn.GetComponent<Image> ().sprite =  Resources.LoadAll<Sprite>("Sprites/UI/weather_btn") [Gameplay_Stats.weather_1] as Sprite;
		//Cambiar imágenes del panel del tiempo
		//current_weather_img.GetComponent<Image> ().sprite =  Resources.LoadAll<Sprite>("Sprites/UI/weather_btn") [Gameplay_Stats.weather_1] as Sprite;
		//next_weather_img.GetComponent<Image> ().sprite =  Resources.LoadAll<Sprite>("Sprites/UI/weather_btn") [Gameplay_Stats.weather_2] as Sprite;

		//Cambiar animación
		leafanim();

		//Poner o quita lluvia
		if (Gameplay_Stats.weather_1 == 4 || Gameplay_Stats.weather_1 == 5) {
			setrain ();
		} else {
			quitrain ();
		}


	}


	void temperature(){
		//La temperatura (centigrados)
		//Depende de la estación del año y después del clima actual
		//Código: Switchception
		int base_temp = 0;
		switch(Gameplay_Stats.season){
		//Puede ser 0,1,2,3
		case 0://Primavera
			base_temp = 15;
			break;
		case 1://Verano
			base_temp = 25; 
			break;
		case 2://Otoño
			base_temp = 10;
			break;
		case 3://Invierno
			base_temp = 3;
			break;
		}

		switch (Gameplay_Stats.weather_1) {
		case 0://Soleado
			Gameplay_Stats.temp = base_temp + Generation.temp_next % 12;
			break;
		case 1://Medio Nublado
			Gameplay_Stats.temp = base_temp + Generation.temp_next%8;
			break;
		case 2://Nublado
			Gameplay_Stats.temp = base_temp + Generation.temp_next%7;
			break;
		case 3://Viento
			Gameplay_Stats.temp = base_temp + Generation.temp_next%6;
			break;
		case 4://Lluvia
			Gameplay_Stats.temp = base_temp + Generation.temp_next%3;
			break;
		case 5://Tormenta
			Gameplay_Stats.temp = base_temp + Generation.temp_next%2;
			break;
		}
		if (Generation.weather_next % 3 == 0) {
			Gameplay_Stats.temp += Gameplay_Stats.season + 1;
		}

		//Debug.Log ("Temperatura del dia:" + Gameplay_Stats.temp);
		Generation.temp_next = Random.Range (1, int.MaxValue-1);
		Random.InitState (Generation.temp_next);
	}

	void setrain(){
		GameObject rain_parent, rain_obj;
		rain_parent = GameObject.Find ("background");
		//Particulas
		rain_obj = rain_parent.transform.Find ("rain").gameObject;
		rain_obj.SetActive (true);
		//Nubes y fondo negro
		rain_obj = rain_parent.transform.Find ("skyrain_p").gameObject;
		rain_obj.SetActive (true);
	}
	void quitrain(){
		GameObject rain_parent, rain_obj;
		rain_parent = GameObject.Find ("background");
		//Particulas
		rain_obj = rain_parent.transform.Find ("rain").gameObject;
		rain_obj.SetActive (false);
		//Nubes y fondo negro
		rain_obj = rain_parent.transform.Find ("skyrain_p").gameObject;
		rain_obj.SetActive (false);
	}


	public Image gameover_image;
	public Animator go_1,go_2;
	void lifeloss() {

		bool ActiveRain_1 = false;
		//bool ActiveRain_2 = false;
		lifelossfunc ();
		if (Gameplay_Stats.weather_1 == 4 || Gameplay_Stats.weather_1 == 5) {
			ActiveRain_1 = true;
		}
		/*if (Gameplay_Stats.weather_2 == 4 || Gameplay_Stats.weather_2 == 5) {
			ActiveRain_2 = true;
		}*/




		int i=0;
		switch (Gameplay_Stats.season) {
		case 0:
			i = 6;
			break;
		case 1:
			i = 8;
			break;
		case 2:
			i = 5;
			break;
		case 3:
			i = 4;
			break;
		}




		//Contador de veces regado
		if (Gameplay_Stats.weather_1 == 4 || Gameplay_Stats.weather_1 == 5 || Irrigate.ActiveIrrigation == true) {
			Gameplay_Stats.irrigatecount++;
			//Debug.Log ("Veces regado: " + Gameplay_Stats.irrigatecount);
		} else {
			if (Gameplay_Stats.irrigatecount >= i) {
				Irrigate.ActiveIrrigation = true;
			}
			Gameplay_Stats.irrigatecount = 0;
			//Debug.Log ("Veces regado: " + Gameplay_Stats.irrigatecount);
		}

		bool damaged = false;

		if (Gameplay_Stats.irrigatecount > i) {
			damaged = true;
		} else {
			if (Irrigate.ActiveIrrigation == false) {
				if (ActiveRain_1 == false) {
					damaged = true;
				}
			} else {
				if (ActiveRain_1 == true/* || Gameplay_Stats.irrigatecount > i*/) {
					damaged = true;
				} /*else {
					Gameplay_Stats.irrigatecount = 0;
					/*if (Irrigate.AI2 == false && Gameplay_Stats.irrigatecount == i) {
					Gameplay_Stats.irrigatecount = 0;
					Debug.Log ("Veces regado: " + Gameplay_Stats.irrigatecount);
				}}*/

			}
		}




		if (damaged == true) {
			Gameplay_Stats.current_life -= lifetoloss;
			leaf_death ();
		}
		damaged = false;

		Irrigate.ActiveIrrigation = false;
		Irrigate.AI2 = false;
		if (Gameplay_Stats.current_life <= 0) {
			gameover = true;
			Gameplay_Stats.current_life = 0;
			GameObject leaftodie;
			GameObject conjunto_de_hojas_falsas = GameObject.Find ("hojas_falsas");
			Destroy (conjunto_de_hojas_falsas);
			for(i = 0; i < Generation.total_leaf; i++){
				leaftodie = GameObject.Find("leaf_c_"+i);
				leaftodie.GetComponent<SpriteRenderer> ().color = new Color(0,0,255,0);
				GameObject newLeaf = Instantiate (fakeleaf_obj);
				newLeaf.name = "leaf_to_die";
				newLeaf.transform.position = leaftodie.transform.position;
			}
			go_1.Play ("game_over1");
			go_2.Play ("game_over2");
			texto_go.Play("go_text");
			GameObject menus_death;
			menus_death = GameObject.Find ("menus_obj");
			Destroy (menus_death);
			


			Restart.restart = true;

		}
		Debug.Log ("Vida actual: " + Gameplay_Stats.current_life);
	}

	void lifelossfunc(){
		//lifetoloss = 1;
		Gameplay_Stats.heal = Gameplay_Stats.flowerscount * 10;
		if (Gameplay_Stats.weather_1 == 4 || Gameplay_Stats.weather_1 == 5 || Irrigate.ActiveIrrigation == true) {
			noirrigate = 1;
		}
		int mul;
		mul = DB.type_tree + 1;
	lifetoloss = (((Gameplay_Stats.temp+(Gameplay_Stats.week/2)) * 2)*noirrigate - (Gameplay_Stats.leafloss/10) + Gameplay_Stats.heal*(Gameplay_Stats.fercount+1)*mul);
	}
		
	void cuttree(){
		if (Cut.ActiveCut == true && Gameplay_Stats.cutcount < 3) {
			GameObject leaftodie;
			for (int i = 0; i < Generation.total_leaf; i++) {
				if ((Generation.leaftodie_next % 7) == 0) {
					leaftodie = GameObject.Find ("leaf_c_" + i);
					leaftodie.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [79] as Sprite;
					GameObject newLeaf = Instantiate (fakeleaf_obj);
					newLeaf.name = "leaf_to_die";
					newLeaf.transform.position = leaftodie.transform.position;	
					Gameplay_Stats.leafloss++;
				}
				Generation.leaftodie_next = Random.Range (1, int.MaxValue - 1);
				Random.InitState (Generation.leaftodie_next);
			}
			Gameplay_Stats.cutcount++;
			Cut.ActiveCut = false;
			Debug.Log (Gameplay_Stats.cutcount);
		}
	}

	//Tiempo(?
	//Soleado, medio nublado, nublado, viento, lluvioso, tormenta
	bool previous_weather;
	void leafanim(){
		GameObject leaftochange;
		//Si es Soleado, medio nublado o nublado y los siguientes son viento, lluvioso y tormenta, entonces...
		if ((Gameplay_Stats.weather_1 >= 3 && Gameplay_Stats.weather_1 <= 5)) {
			if (previous_weather != true) {
				for (int i = 0; i < Generation.total_leaf; i++) {
					leaftochange = GameObject.Find ("leaf_c_" + i);
					switch (Generation.leaf_next [1] % 2) {
					case 0:
						leaftochange.GetComponentInChildren<Animator>().Play("leaf_wr00", -1, ((Generation.leaf_next[1]%100)/100f));
						break;
					case 1:
						leaftochange.GetComponentInChildren<Animator>().Play("leaf_wr01", -1, ((Generation.leaf_next[1]%100)/100f));
						break;
					}

					Generation.leaf_next[1] = Random.Range (1, int.MaxValue-1);
					Random.InitState (Generation.leaf_next[1]);
				}
				previous_weather = true;
				//Debug.Log ("Cambio de idle a wr");
			}
		} else if((Gameplay_Stats.weather_1 >= 0 && Gameplay_Stats.weather_1 <= 3)) {
			if (previous_weather != false) {
				for (int i = 0; i < Generation.total_leaf; i++) {
					leaftochange = GameObject.Find ("leaf_c_" + i);
					switch (Generation.leaf_next [1] % 2) {
					case 0:
						leaftochange.GetComponent<Animator> ().Play("leaf_idle00", -1, ((Generation.leaf_next[1]%100)/100f));
						break;
					case 1:
						leaftochange.GetComponent<Animator> ().Play("leaf_idle01", -1, ((Generation.leaf_next[1]%100)/100f));
						break;
					}
					Generation.leaf_next[1] = Random.Range (1, int.MaxValue-1);
					Random.InitState (Generation.leaf_next[1]);
				}
				previous_weather = false;
				//Debug.Log ("Cambio de wr a idle");
			}
		}
	}
		

	void leafsprite(){
		GameObject leaftochange;
		for (int i = 0; i < Generation.total_leaf; i++) {
			leaftochange = GameObject.Find ("leaf_c_" + i);
			switch (Gameplay_Stats.season) {


			case 0:
				switch (Generation.leaf_next[1] % 12) {
				case 0:
					leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [0] as Sprite;
					break;
				case 1:
					leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [1] as Sprite;
					break;
				case 2:
					leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [2] as Sprite;
					break;
				case 3:
					leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/leaf") [10] as Sprite;
					break;
				case 4:
					leaftochange.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [11] as Sprite;
					break;
				case 5:
					leaftochange.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [12] as Sprite;;
					break;
				case 6:
					leaftochange.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [20] as Sprite;
					break;
				case 7:
					leaftochange.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [21] as Sprite;
					break;
				case 8:
					leaftochange.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [22] as Sprite;
					break;
				case 9:
					leaftochange.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [30] as Sprite;
					break;
				case 10:
					leaftochange.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [31] as Sprite;
					break;
				case 11:
					leaftochange.GetComponent<SpriteRenderer> ().sprite =  Resources.LoadAll<Sprite>("Sprites/leaf") [32] as Sprite;
					break;
				}
				Generation.leaftodie_next = Random.Range (1, int.MaxValue-1);
				Random.InitState (Generation.leaftodie_next);
				break;
			case 1:

				break;
			case 2:
				if (leaftochange.GetComponent<SpriteRenderer> ().sprite == leafsprites [79]) {
					break;
				} else {
					switch (Generation.leaf_next [1] % 12) {

					case 0:
						leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [40] as Sprite;
						break;
					case 1:
						leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [41] as Sprite;
						break;
					case 2:
						leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [42] as Sprite;
						break;
					case 3:
						leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [50] as Sprite;
						break;
					case 4:
						leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [51] as Sprite;
						break;
					case 5:
						leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [52] as Sprite;
						break;
					case 6:
						leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [60] as Sprite;
						break;
					case 7:
						leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [61] as Sprite;
						break;
					case 8:
						leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [62] as Sprite;
						break;
					case 9:
						leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [70] as Sprite;
						break;
					case 10:
						leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [71] as Sprite;
						break;
					case 11:
						leaftochange.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [72] as Sprite;
						break;
					}

				}

				leaf_death_autumn (i);

				break;
			case 3:

				break;
			}
			Generation.leaf_next[1] = Random.Range (1, int.MaxValue-1);
			Random.InitState (Generation.leaf_next[1]);
		}
	}


	//Barra de vida
	public Image bar_img;
	public Text porcentual_life;
	void healthbar(){
		porcentual_life.text = "Salud: "+ (Gameplay_Stats.current_life * 100) / Gameplay_Stats.max_life + "%";
		//Se saca el porcentaje y se vuelve a dividir en 100 para sacar sus decimales
		bar_img.fillAmount = ((Gameplay_Stats.current_life * 100) / Gameplay_Stats.max_life)/100f;
	}



	//Hojas cayendo
	void leaf_death(){
		GameObject leaftodie;//, leaftodie_child;
		//El numero total de hojas es 269 (por ahora)
		//Se escojera una hoja al azar en entre el 0 y el total de hojas
		leaftodie = GameObject.Find("leaf_c_"+Generation.leaftodie_next%Generation.total_leaf);
//		Debug.Log ("Hoja ''eliminada'' es:" + Generation.leaftodie_next %Generation.total_leaf);
		//Hace la hoja hijo (la del sprite) invisible
		leaftodie.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [79] as Sprite;
		GameObject newLeaf = Instantiate (fakeleaf_obj);
		newLeaf.name = "leaf_to_die";
		newLeaf.transform.position = leaftodie.transform.position;
		noirrigate++;
		Gameplay_Stats.leafloss++;

		Generation.leaftodie_next = Random.Range (1, int.MaxValue-1);
		Random.InitState (Generation.leaftodie_next);
	}
		
	void leaf_death_autumn(int i){



		GameObject leaftodie;
		//for(i = 0; i < Generation.total_leaf; i++){
		if(Generation.leaftodie_next%4==0){
			leaftodie = GameObject.Find("leaf_c_"+i);
			leaftodie.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/leaf") [79] as Sprite;
			GameObject newLeaf = Instantiate (fakeleaf_obj);
			newLeaf.name = "leaf_to_die";
			newLeaf.transform.position = leaftodie.transform.position;	
			Gameplay_Stats.leafloss++;
		}

		//}

		Generation.leaftodie_next = Random.Range (1, int.MaxValue-1);
		Random.InitState (Generation.leaftodie_next);


	}

	IEnumerator DeleteLeaf(GameObject leaf){
		yield return new WaitForSeconds (10f);
		Destroy (leaf);
	}


	

	void fertilize(){
		if(Fertilize.ActiveFertilize == true){
			Gameplay_Stats.fercount++;
		}
		if (Gameplay_Stats.fercount >= 6) {
			flower_sprites_empty ();
			Gameplay_Stats.flowerscount = 0;
			Gameplay_Stats.fercount = 0;
		}
		Fertilize.ActiveFertilize = false;
	}
	void flower_sprites(){
		GameObject flower;
		if (Plant.ActivePlant == true) {
			Gameplay_Stats.flowerscount++;
			flower = GameObject.Find("flower_"+Gameplay_Stats.flowerscount);
			flower.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/flower") [0] as Sprite;
		//	Debug.Log (Gameplay_Stats.flowerscount);
		}
		Plant.ActivePlant = false;
	}


	void flower_sprites_empty(){
		GameObject flower;
		for (int i = 1; i < 9; i++) {
			flower = GameObject.Find("flower_"+i);
			flower.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/flower") [1] as Sprite;
		}
		
	}

	void actions_sprites(){
		if (Gameplay_Stats.cutcount >= 3) {
			cut.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite> ("Sprites/UI/actions2_btn") [9] as Sprite;
		} else {
			cut.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/actions2_btn") [0] as Sprite;
		}
		irr.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/actions2_btn") [1] as Sprite;

		fer.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/actions2_btn") [2] as Sprite;
		if (Gameplay_Stats.flowerscount >= 8 || Gameplay_Stats.season == 3) {
			plant.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite> ("Sprites/UI/actions2_btn") [10] as Sprite;
		} else {
			plant.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/actions2_btn") [3] as Sprite;
		}
		
	}
}
