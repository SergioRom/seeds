using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherButton : MonoBehaviour {

	private Animator weather_panel_anim;
	public static bool panel_actived;

	public Image weather_panel_prefab; 
	private GameObject canvas_obj;
	private Canvas canvas_parent;
	private Image panel;
	static int counter=0;
	private GameObject panel_obj;

	//Game Manager
	private GameObject gm;
	private MakeMenu gs;
	private GameObject background_obj;
	private Image background;

	void Start(){
		//Game manager
		gm = GameObject.Find("GameManager");
		gs = gm.GetComponent<MakeMenu> ();

		canvas_obj = GameObject.Find ("UserInterface");
		canvas_parent = canvas_obj.GetComponent<Canvas> ();
	}

	public void OpenClosePanel(){
		if (panel_actived == false) {
			background = gs.MakeBackgroundBlack ();
			background.name = "temporal_background_black_" + counter;
			background_obj = GameObject.Find ("temporal_background_black_" + counter);
			MakeWeatherPanel ();
			weather_panel_anim.Play ("weather_panel_in");
			panel_actived = true;
		} else {
			weather_panel_anim.Play ("weather_panel_out");
			panel_actived = false;
			Destroy (background_obj);
			Destroy (panel_obj, 0.25f);
		}
	}

	private void MakeWeatherPanel(){
		panel = (Image) Instantiate(weather_panel_prefab);
		panel.transform.SetParent(canvas_parent.transform, true);
		panel.name= "weather_panel_obj_" + counter;
		panel_obj = GameObject.Find ("weather_panel_obj_" + counter);
		counter++;
		PlayPanelAnimator ();
	}

	private void PlayPanelAnimator(){
		weather_panel_anim = panel.GetComponent<Animator> ();
	}

	public void ClosePanel(){
		weather_panel_anim = GetComponentInParent<Animator> ();
		weather_panel_anim.Play ("weather_panel_out");
		panel_actived = false;
		background_obj = GameObject.Find ("temporal_background_black_" + (counter-1));
		Destroy (background_obj);
		Destroy (transform.parent.gameObject, 0.25f);
	}


}
