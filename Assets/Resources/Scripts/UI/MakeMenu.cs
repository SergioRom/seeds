using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakeMenu : MonoBehaviour {


	public Image Notebook_Background_Prefab, notebook_prefab;
	public void NotebookBackground(){
		if (GameObject.Find ("notebook") == null) {
			GameObject my_canvas = GameObject.Find ("UserInterface");
			//Spawn del fondo negro con el botón
			Image notebook_img_bg = (Image) Instantiate(Notebook_Background_Prefab);
			notebook_img_bg.transform.SetParent(my_canvas.transform, true);
			//Obtener el script del fondo negro
			Notebook_btn notebook_script = notebook_img_bg.GetComponent<Notebook_btn> ();
			notebook_img_bg.name="notebook_blackground_black";
			notebook_img_bg.rectTransform.localScale = new Vector3 (1, 1, 1);
			notebook_img_bg.transform.localPosition = new Vector2 (0, 0);
			notebook_img_bg.transform.SetSiblingIndex (3);

			//Spawn de la libreta completa
			Image notebook_img = (Image) Instantiate(notebook_prefab);
			notebook_img.transform.SetParent(my_canvas.transform, true);
			notebook_img.name="notebook";
			notebook_img.transform.localPosition = new Vector2 (-1000,-1000);
			notebook_img.rectTransform.localScale = new Vector3 (1, 1, 1);
			notebook_img.transform.SetSiblingIndex (4);
			//Llamar al método del script para mover a la libreta
			notebook_script.IONotebook ();
		}
	}

	public Image Pause_Menu_Prefab;
	public void PauseMenu(){
		Image pause_menu_img = (Image) Instantiate(Pause_Menu_Prefab);
		GameObject my_canvas = GameObject.Find ("UserInterface");
		pause_menu_img.transform.SetParent(my_canvas.transform, true);
		RectTransform pause_menu_pos = pause_menu_img.GetComponent<RectTransform>();
		pause_menu_pos.transform.localScale = new Vector3 (1, 1, 1);
		pause_menu_pos.transform.localPosition = new Vector2 (0, 0);
		pause_menu_img.name = "pause_ui";
	}


	public Image background_prefab;
	public Image MakeBackgroundBlack(){
		Image bg_black = (Image) Instantiate(background_prefab);
		GameObject my_canvas = GameObject.Find ("UserInterface");
		bg_black.transform.SetParent(my_canvas.transform, true);
		RectTransform bg_black_pos = bg_black.GetComponent<RectTransform>();
		bg_black_pos.transform.localScale = new Vector3 (1, 1, 1);
		bg_black_pos.transform.localPosition = new Vector2 (0, 0);
		bg_black.transform.SetSiblingIndex (3);
		return bg_black;
	}
}
