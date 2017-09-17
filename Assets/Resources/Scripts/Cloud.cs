using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	Animator cloud_anim;

	public Sprite[] clouds = new Sprite[6]; 
	void Update(){
		if (Gameplay_Stats.weather_1 == 4 || Gameplay_Stats.weather_1 == 5) {
			if (gameObject.GetComponent<SpriteRenderer> ().sprite == clouds [0]) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/Clouds/Cloud") [3] as Sprite;
			} else if (gameObject.GetComponent<SpriteRenderer> ().sprite == clouds [1]) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/Clouds/Cloud") [4] as Sprite;
			} else if (gameObject.GetComponent<SpriteRenderer> ().sprite == clouds [2]) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/Clouds/Cloud") [5] as Sprite;
			}
		} else {
			if (gameObject.GetComponent<SpriteRenderer> ().sprite == clouds [3]) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/Clouds/Cloud") [0] as Sprite;
			} else if (gameObject.GetComponent<SpriteRenderer> ().sprite == clouds [4]) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/Clouds/Cloud") [1] as Sprite;
			} else if (gameObject.GetComponent<SpriteRenderer> ().sprite == clouds [5]) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite> ("Sprites/Clouds/Cloud") [2] as Sprite;
			}
		}
	
	}


	public Transform target;
	public float speed;

	private Vector3 start, end;




	// Use this for initialization
	void Start () {
		//Destruir dependiendo del clima
		if(Gameplay_Stats.weather_1 == 0 || Gameplay_Stats.weather_1 == 4 || Gameplay_Stats.weather_1 == 5){
			Destroy (gameObject);
		}
	/*	if (target != null) {
			GameObject gm_obj;
			gm_obj = GameObject.Find ("Generation_Manager");
			target.parent = gm_obj.transform;

			start = transform.position;
			end = target.position;
		}
		*/
		//Escoger su animación
		cloud_anim = gameObject.GetComponentInChildren<Animator>();

		//Velocidad de la nuba
		if (Gameplay_Stats.weather_1 == 3) {
			cloud_anim.speed = 0.15f;
		} else {
			cloud_anim.speed = 0.10f;
		}

		// 0 a la izquierda, 1 a la derecha
		if (Generation.RandomSeed % 2 == 0) {
			cloud_anim.Play("cloud00");
			//cloud_anim.Play("cloud00", 0, ((Generation.cloud_next%100)/100f));
		} else {
			cloud_anim.Play("cloud01");
			//cloud_anim.Play("cloud01", 0, ((Generation.cloud_next%100)/100f));
		}



		//Escoger su tamaño
		Set_Size();

		//Esoger el sprite
		Set_Sprite();

		//Función para destruir la nube
		Destroy (gameObject,50f);
	}

	// Update is called once per frame
	/*void FixedUpdate () {
		if (target != null) {
			float fixedSpeed = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position,target.position,fixedSpeed);
		}
	
		if (transform.position == target.position) {
			target.position = (target.position == start) ? end : start;
		}
	}

	*/






	void Set_Size(){
		if (Generation.cloud_next % 3 == 0) {
			gameObject.transform.localScale = new Vector2 (1 + ((Generation.cloud_next%100)/150f), 1 + ((Generation.cloud_next%100)/150f));
		}
		Generation.cloud_next = Random.Range (1, int.MaxValue-1);
		Random.InitState (Generation.cloud_next);
	}

	void Set_Sprite(){
		switch (Generation.cloud_next % 3) {
		case 0:
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/Clouds/Cloud") [0] as Sprite;
			break;
		case 1:
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/Clouds/Cloud") [1] as Sprite;
			break;
		case 2:
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.LoadAll<Sprite>("Sprites/Clouds/Cloud") [2] as Sprite;
			break;
		}
	}

}
