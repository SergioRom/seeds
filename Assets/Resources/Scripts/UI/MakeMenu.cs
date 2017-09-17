using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakeMenu : MonoBehaviour {


	public Image Notebook_Background_Prefab;
	public void NotebookBackground(){
		Image notebook_img = (Image) Instantiate(Notebook_Background_Prefab);
		GameObject my_canvas = GameObject.Find ("UserInterface");
		notebook_img.transform.SetParent(my_canvas.transform, true);
		Notebook_btn notebook_script = notebook_img.GetComponent<Notebook_btn> ();
		notebook_script.IONotebook ();
	}

	public Image Pause_Menu_Prefab;
	public void PauseMenu(){
		Image pause_menu_img = (Image) Instantiate(Pause_Menu_Prefab);
		GameObject my_canvas = GameObject.Find ("UserInterface");
		pause_menu_img.transform.SetParent(my_canvas.transform, true);
		RectTransform pause_menu_pos = pause_menu_img.GetComponent<RectTransform>();
		pause_menu_pos.position = new Vector2 (288, 512);
		pause_menu_img.name = "pause_ui";
	}


	public Image background_prefab;
	public Image MakeBackgroundBlack(){
		Image bg_black = (Image) Instantiate(background_prefab);
		GameObject my_canvas = GameObject.Find ("UserInterface");
		bg_black.transform.SetParent(my_canvas.transform, true);
		RectTransform bg_black_pos = bg_black.GetComponent<RectTransform>();
		bg_black_pos.position = new Vector2 (288, 512);
		bg_black.transform.SetSiblingIndex (0);
		return bg_black;
	}
}
