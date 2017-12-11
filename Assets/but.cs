using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class but : MonoBehaviour {


	// Use this for initialization
	void Start () {
		//Esto se ejecuta al contestar una pregunta
		GameObject der_obj, izq_obj;
		//Referenciando los dos objetos 

									// V Estos son los objetos con los botones dentro
		der_obj = GameObject.Find ("opcion1");
		izq_obj = GameObject.Find ("opcion2");


		//Posiciones
		Vector2 pos_der_obj, pos_izq_obj; 

		//Sacando posiciones
		pos_der_obj = der_obj.transform.localPosition;
		pos_izq_obj = izq_obj.transform.localPosition;

		//Un numero al azar
		int numero_al_azar = Random.Range (1, 1000);

		if (numero_al_azar % 2 == 0) {
			//Si el residuo del numero al azar es igual a 0

			//El objeto derecho se pone en la posición del izquierdo
			der_obj.transform.localPosition = pos_izq_obj;
			//El objeto izquierdo se pone en la posición del derecho
			izq_obj.transform.localPosition = pos_der_obj;

			Debug.Log ("Switch!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
