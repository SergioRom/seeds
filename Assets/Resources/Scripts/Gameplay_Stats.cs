using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_Stats : MonoBehaviour {



	//Variables para base de datos
	public static int tipo_arbol, cant_hoja, semana, cuidado, lluvia, us_arbol, rayo_caido;
	// Use this for initialization
	void Start () {
		//Estaciones: 0 = Primavera; 1 = Verano; 2 = Otoño; 3 = Invierno;
		season = 0;
		leafloss = 0;
		week = 1;
		weather_1 = 0;
		weather_2 = 0;
		max_life = 1000;
		temp = 20;
		cutcount = 0;
		irrigatecount = 0;
		flowerscount = 0;
		heal = 0;
		fercount = 0;
		current_life = max_life;
		/////////////////////////////////////////////////////////////////////////////////////
		tipo_arbol = DB.type_tree;
		cant_hoja = 0;
		semana = week;
		cuidado = 0;
		lluvia = 0;
		us_arbol = DB.id_user;
		rayo_caido = 0;
	}
	public static int season, week, temp, weather_1, weather_2, max_life,current_life, leafloss, cutcount, irrigatecount, flowerscount, heal, fercount;

	//Get
	public int GetSeason(){
		return season;
	}

	public int GetWeek(){
		return week;
	}

	public int GetCurrentWeather(){
		return weather_1;
	}

	public int GetNextWeather(){
		return weather_2;
	}

	public int GetTemp(){
		return temp;
	}
}
