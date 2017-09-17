using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class DB : MonoBehaviour {

	public InputField username_txt, password_txt, age_txt;
	public Dropdown sex_dropdown, country_dropdown;
	public Text warning_text;
	int sex_dropdown_index, country_dropdown_index;

	public Animator register_out;

	public void RegisterUser(){
		bool validation = false, validation_age = false;
		sex_dropdown_index = sex_dropdown.value;
		country_dropdown_index = country_dropdown.value;

		//Revisar si los campos tienen espacios o están vacíos
		string username_str = username_txt.text;
		string password_str = password_txt.text;
		if(username_str == "" || password_str == ""){
			validation = true;
		}
		for(int i = 0; i < username_str.Length; i++){
			if((username_str[i] == ' ')){
				validation = true;
				break;
			}
		}
		for(int i = 0; i < password_str.Length; i++){
			if((password_str[i] == ' ')){
				validation = true;
				break;
			}
		}
		//Revisar la edad
		if (age_txt.text == "") {
			validation = true;

		} else {
			if(age_txt.text[0] == '0' ){
				validation = true;
				validation_age = true;
			}
		}
		if (validation == false) {
			StartCoroutine (register ());
			warning_text.text = "";
		} else {
			Debug.Log ("Error al registrar a el usuario.");
			if (validation_age == true) {
				warning_text.text = "La edad está incorrecta.";
			} else {
				warning_text.text = "Los campos deben llenarse correctamente. (No espacios).";
			}

		}
		//Debug.Log(sex_dropdown.options[sex_dropdown_index].text);
		//Debug.Log(country_dropdown.options[country_dropdown_index].text);
	}

	IEnumerator register(){
		WWW re_connection = new WWW ("https://intento01.000webhostapp.com/register.php?usname="+username_txt.text+"&uspass="+password_txt.text+"&ussex="+sex_dropdown.options[sex_dropdown_index].text+"&usage="+age_txt.text+"&uscountry="+country_dropdown.options[country_dropdown_index].text);
		yield return(re_connection);

		//Mensajes de advertencia
		if (re_connection.text == "Usuario ya existente.") {
			warning_text.text = "Este usuario ya existe.";
			Debug.Log ("Este usuario ya existe.");
		} else {
			//Si está correcto, el menu regresa y el mensaje desaparece
			register_amim_out ();
			warning_text.text = "";
			//Vaciar cajas de texto
			username_txt.text = "";
			password_txt.text = "";
			sex_dropdown.value = 0;
			country_dropdown.value = 0;
			age_txt.text = "";
		}
	}
	public Animator bg_login_register_anim;
	public void register_amim_out(){
		register_out.Play("bg_login_register_out");
		bg_login_register_anim.Play ("bg_login_register");
	}
		
	/////////////////////////////////////////////////////////////////////////////////////////////
	public InputField login_username_txt, login_password_txt;
	public Text warning_login_text;
	public void LoginUser(){
		bool validation = false;

		//Revisar si los campos tienen espacios o están vacíos
		string login_username_str = login_username_txt.text;
		string login_password_str = login_password_txt.text;
		if(login_username_str == "" || login_password_str == ""){
			validation = true;
		}
		if (validation == false) {
			StartCoroutine (login ());
			warning_login_text.text = "";
		} else {
			warning_login_text.text = "Nombre de usuario o contraseña incorrectos.";
		}
	}

	//Variables estaticas para ID de usuario y su Nombre
	public static int id_user;
	public static string username;
	IEnumerator login(){
		WWW login_connection = new WWW ("https://intento01.000webhostapp.com/login.php?usname="+login_username_txt.text+"&uspass="+login_password_txt.text);
		yield return(login_connection);

		//Mensajes de advertencia
		if (login_connection.text == "El usuario no existe.") {
			warning_login_text.text = "Nombre de usuario o contraseña incorrectos.";
			Debug.Log ("Nombre de usuario o contraseña incorrectos.");
		} else {
			//Si está correcto se borra el mensaje 
			warning_login_text.text = "";
			StartCoroutine (find_user ());
		}
	}

	//Consulta para conseguir el ID del usuario y asignarlo a una variable estatica
	public Animator newgameanim;

	IEnumerator find_user(){
		WWW find_user_connection = new WWW ("https://intento01.000webhostapp.com/find_user.php?usname="+login_username_txt.text+"&uspass="+login_password_txt.text);
		yield return(find_user_connection);
		string id_user_string;
		id_user_string = find_user_connection.text;
		id_user = Convert.ToInt32(id_user_string);
		username = login_username_txt.text;
		Debug.Log ("ID usuario: " + id_user + ", Nombre: " + username);
		Offline.PlayOff = false;
		bg_login_register_anim.Play ("bg_login_register_out");
		newgameanim.Play ("new_game_anim_1");
	}

	public void newgameanimout(){
		newgameanim.Play ("new_game_anim_2");
		bg_login_register_anim.Play ("bg_login_register");
	}

	////////////////////////////////////////////////////
	// Tipo de arbol 0 = facil, 1 = normal, 2 = dificil
	public static int type_tree;
	//Cargar escenario
	public void load_new_game(int df){
		if (Offline.PlayOff == false) {
			StartCoroutine (load_new_game_IE ());
		} else {
			SceneManager.LoadScene ("gameplay");
		}
		type_tree = df;
	}

	IEnumerator load_new_game_IE(){
		WWW new_game_connection = new WWW ("https://intento01.000webhostapp.com/total_tree.php?usid="+id_user);
		yield return(new_game_connection);
		SceneManager.LoadScene ("gameplay");
	}

}



	/*
	 Variables en php
        $usname = $_GET['usname'];
        $uspass = $_GET['uspass'];
        $ussex = $_GET['ussex'];
        $usage = $_GET['usage'];
        $uscountry = $_GET['uscountry'];
    */