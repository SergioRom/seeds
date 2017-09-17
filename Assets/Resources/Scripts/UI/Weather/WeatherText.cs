using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherText : MonoBehaviour {

	//Textos en el panel del tiempo
	private Text season_txt;
	private Text week_count_txt;
	private Text current_weather_txt;
	private Text temp_txt;

	//Imágenes en el panel del tiempo 
	private Image current_weather_img;
	private Image next_weather_img;

	//Game Manager
	private GameObject gm;
	private Gameplay_Stats gs;

	// Use this for initialization
	void Start () {
		//Game manager
		gm = GameObject.Find("GameManager");
		gs = gm.GetComponent<Gameplay_Stats> ();

		//Textos en el panel del tiempo
		season_txt = gameObject.transform.GetChild(0).GetComponent<Text>();
		week_count_txt = gameObject.transform.GetChild(1).GetComponent<Text>();
		current_weather_txt = gameObject.transform.GetChild(3).GetComponent<Text>();
		temp_txt = gameObject.transform.GetChild(5).GetComponent<Text>();


		season_txt.text = SetSeason(gs.GetSeason ());
		week_count_txt.text = SetWeekCount(gs.GetWeek());
		current_weather_txt.text = SetCurrentWeather(gs.GetCurrentWeather());
		temp_txt.text = SetTemperature(gs.GetTemp());

		//Imágenes del tiempo
		current_weather_img = gameObject.transform.GetChild(4).GetComponent<Image>();
		next_weather_img = gameObject.transform.GetChild(7).GetComponent<Image>();

		current_weather_img.sprite = SetImageCurrentWeahter(gs.GetCurrentWeather());
		next_weather_img.sprite = SetImageCurrentWeahter(gs.GetNextWeather());

	}


	//String de la estación del año
	private string SetSeason(int no_season){
		string season = "";
		switch (no_season) {
		case 0:
			//Gameplay_Stats.leafloss = 0;
			//Gameplay_Stats.cutcount = 0;
			season = "Estación: Primavera";
			break;
		case 1:
			season = "Estación: Verano";
			break;
		case 2:
			season = "Estación: Otoño";
			break;
		case 3:
			season = "Estación: Invierno";
			break;
		}
		return season;
	}

	//String de la cuenta de semanas
	private string SetWeekCount(int no_week){
		string week_count = "";
		week_count = "Semana: " + no_week;
		return week_count;
	}

	//String del tiempo actual
	private string SetCurrentWeather(int no_weather){
		string current_weater = "";
		switch (no_weather) {
		case 0:
			current_weater = "Soleado";
			break;
		case 1:
			current_weater = "Medio nublado";
			break;
		case 2:
			current_weater = "Nublado";
			break;
		case 3:
			current_weater = "Viento";
			break;
		case 4:
			current_weater = "Lluvioso";
			break;
		case 5:
			current_weater = "Tormenta";
			break;
		}
		return current_weater;
	}

	//String de la temperatura
	private string SetTemperature(int no_temperature){
		string temperature = "";
		temperature = "Temperatura: " + no_temperature + "°C";
		return temperature;
	}


	//Imagen del tiempo actual
	private Sprite SetImageCurrentWeahter(int no_weather){
		Sprite current_weather = Resources.LoadAll<Sprite>("Sprites/UI/weather_btn") [no_weather] as Sprite;
		return current_weather;
	}

	//Imagen del tiempo siguiente
	private Sprite SetImageNextWeather(int no_weather){
		Sprite next_weather = Resources.LoadAll<Sprite>("Sprites/UI/weather_btn") [no_weather] as Sprite;
		return next_weather;
	}
}
