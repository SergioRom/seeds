using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {
	public Text main_text;
	// Use this for initialization
	void Start () {

		string message="";


		switch (Random.Range (1,26)) {
		case 1:
			message = "Los árboles necesitan  agua para poder sobrevivir, en ocasiones el agua en exceso puede perjudicarlos.";
			break;
		case 2:
			message = "En otoño e invierno los árboles pierden la mayoría de sus hojas para gastar la menor cantidad de agua posible.";
			break;
		case 3:
			message = "El fertilizante puede llegar a ser útil para las plantas, no es necesario usar grandes cantidades.";
			break;
		case 4:
			message = "Un árbol (promedio) absorbe en toda su vida, un aproximado de 730 kilogramos de dióxido de carbono.";
			break;
		case 5:
			message = "Cerca de 2.56 toneladas de madera se requieren para fabricar una tonelada de papel. Cada resma de hojas necesita 3.6 kg de madera.";
			break;
		case 6:
			message = "El árbol más alto jamás medido fue un Eucalipto Australiano (Eucalyptus regnans), en Watts River, Victoria, Australia. En el año  1872 se reportó una altura de 132 metros.";
			break;
		case 7:
			message = "Se requieren 22 árboles para suplir la demanda de oxígeno de una persona al día. 0,41 hectáreas con árboles, produce suficiente oxígeno al día para 18 personas.";
			break;
		case 8:
			message = "Un árbol puede absorber los gases tóxicos que emiten cien coches en un día.";
			break;
		case 9:
			message = "Un árbol consume a lo largo de su vida , aproximadamente una tonelada de dióxido de carbono.";
			break;
		case 10:
			message = "Muchos tipos de frutas y frutos secos vienen de los árboles incluyendo manzanas, naranjas, nueces, peras y duraznos.";
			break;
		case 11:
			message = "Los árboles son uno de los recursos naturales más importantes.";
			break;
		case 12:
			message = "Los árboles mantienen nuestro aire puro y limpio.";
			break;
		case 13:
			message = "Los árboles reducen la contaminación por ruido.";
			break;
		case 14:
			message = "Los árboles mejorar la calidad del agua.";
			break;
		case 15:
			message = "Un árbol produce aproximadamente 260 libras de oxígeno al año.";
			break;
		case 16:
			message = "Muchas medicinas provienen de los árboles.";
			break;
		case 17:
			message = "Los árboles nos dan madera para las construcciones y la pulpa para hacer papel.";
			break;
		case 18:
			message = "Los árboles son los organismos más longevos del planeta.";
			break;
		case 19:
			message = "Los árboles no crecen más allá de su capacidad para valerse por sí mismos: durante los períodos difíciles sueltan hojas, flores, frutos y ramas.";
			break;
		case 20:
			message = "Cuando han sido heridos o tienen alguna enfermedad, no restauran el tejido dañado. Ese área simplemente no se desarrolla más.";
			break;
		case 21:
			message = "Los árboles proporcionan alimento y refugio a la vida.";
			break;
		case 22:
			message = "Los árboles son renovables, biodegradables y reciclables.";
			break;
		case 23:
			message = "La edad de un árbol puede determinarse por el número de anillos que tenga.";
			break;
		case 24:
			message = "Algunos árboles pueden “hablar” entre sí. Cuando los sauces son atacados por gusanos y orugas, emiten una sustancia química que alerta a otros sauces acerca del peligro. Entonces los árboles vecinos responden con un bombeo más taninos a sus hojas, dificultando a los insectos digerirlas.";
			break;
		case 25:
			message = "Ningún árbol muere por vejez. Los insectos, las enfermedades o las personas son quienes les dan muerte.";
			break;
		default:
			message = "Ningún árbol muere por vejez. Los insectos, las enfermedades o las personas son quienes les dan muerte.";
			break;
		}
		main_text.text = message;

	}


}
