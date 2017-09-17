using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notebook : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public Image picture_notebook;
	public Text parrafotxt, titulo;
	string texto, tit;
	int num=1;
	public void text(int valor){
		

		num = num + valor;
		if (num <= 0) {
			num = 1;
		}
		if (num >= 25) {
			num = 25;
		}
	//	Debug.Log (num);
		picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [17] as Sprite;
		switch (num) {
		case 1:
			tit = "#cuidados";
			texto = "Los árboles necesitan  agua para poder sobrevivir, en ocasiones el agua en exceso puede perjudicarlos.";
			break;
		case 2:
			tit = "#cuidados";
			texto = "En otoño e invierno los árboles pierden la mayoría de sus hojas para gastar la menor cantidad de agua posible.";
			break;
		case 3:
			tit = "#cuidados";
			texto = "El fertilizante puede llegar a ser útil para las plantas, no es necesario usar grandes cantidades.";
			break;
		case 4:
			tit = "#info";
			texto = "Un árbol (promedio) absorbe en toda su vida, un aproximado de 730 kilogramos de dióxido de carbono.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [0] as Sprite;
			break;
		case 5:
			tit = "#info";
			texto = "Cerca de 2.56 toneladas de madera se requieren para fabricar una tonelada de papel. Cada resma de hojas necesita 3.6 kg de madera.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [1] as Sprite;
			break;
		case 6:
			tit = "#info";
			texto = "El árbol más alto jamás medido fue un Eucalipto Australiano (Eucalyptus regnans), en Watts River, Victoria, Australia. En el año  1872 se reportó una altura de 132 metros.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [2] as Sprite;
			break;
		case 7:
			tit = "#info";
			texto = "Se requieren 22 árboles para suplir la demanda de oxígeno de una persona al día. 0,41 hectáreas con árboles, produce suficiente oxígeno al día para 18 personas.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [3] as Sprite;
			break;
		case 8:
			tit = "#info";
			texto = "Un árbol puede absorber los gases tóxicos que emiten cien coches en un día.";
			break;
		case 9:
			tit = "#info";
			texto = "Un árbol consume a lo largo de su vida , aproximadamente una tonelada de dióxido de carbono.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [4] as Sprite;
			break;
		case 10:
			tit = "#info";
			texto = "Muchos tipos de frutas y frutos secos vienen de los árboles incluyendo manzanas, naranjas, nueces, peras y duraznos.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [5] as Sprite;
			break;
		case 11:
			tit = "#info";
			texto = "Los árboles son uno de los recursos naturales más importantes.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [6] as Sprite;
			break;
		case 12:
			tit = "#info";
			texto = "Los árboles mantienen nuestro aire puro y limpio.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [7] as Sprite;
			break;
		case 13:
			tit = "#info";
			texto = "Los árboles reducen la contaminación por ruido.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [8] as Sprite;
			break;
		case 14:
			tit = "#info";
			texto = "Los árboles mejorar la calidad del agua.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [9] as Sprite;
			break;
		case 15:
			tit = "#info";
			texto = "Un árbol produce aproximadamente 260 libras de oxígeno al año.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [10] as Sprite;
			break;
		case 16:
			tit = "#info";
			texto = "Muchas medicinas provienen de los árboles.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [11] as Sprite;
			break;
		case 17:
			tit = "#info";
			texto = "Los árboles nos dan madera para las construcciones y la pulpa para hacer papel.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [12] as Sprite;
			break;
		case 18:
			tit = "#info";
			texto = "Los árboles son los organismos más longevos del planeta.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [13] as Sprite;
			break;
		case 19:
			tit = "#info";
			texto = "Los árboles no crecen más allá de su capacidad para valerse por sí mismos: durante los períodos difíciles sueltan hojas, flores, frutos y ramas.";
			break;
		case 20:
			tit = "#info";
			texto = "Cuando han sido heridos o tienen alguna enfermedad, no restauran el tejido dañado. Ese área simplemente no se desarrolla más.";
			break;
		case 21:
			tit = "#info";
			texto = "Los árboles proporcionan alimento y refugio a la vida.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [14] as Sprite;
			break;
		case 22:
			tit = "#info";
			texto = "Los árboles son renovables, biodegradables y reciclables.";
			break;
		case 23:
			tit = "#info";
			texto = "La edad de un árbol puede determinarse por el número de anillos que tenga.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [15] as Sprite;
			break;
		case 24:
			tit = "#info";
			texto = "Algunos árboles pueden “hablar” entre sí. Cuando los sauces son atacados por gusanos y orugas, emiten una sustancia química que alerta a otros sauces acerca del peligro. Entonces los árboles vecinos responden con un bombeo más taninos a sus hojas, dificultando a los insectos digerirlas.";
			break;
		case 25:
			tit = "#info";
			texto = "Ningún árbol muere por vejez. Los insectos, las enfermedades o las personas son quienes les dan muerte.";
			picture_notebook.GetComponent<Image> ().sprite = Resources.LoadAll<Sprite>("Sprites/UI/images") [16] as Sprite;
			break;

		}
		titulo.text = tit;
		parrafotxt.text = texto;
	}
}
