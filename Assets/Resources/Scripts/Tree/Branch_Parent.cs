using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch_Parent : Tree {

	private int degree;
	private int idBranch;
	// Use this for initialization
	void Start () {
		//Cantidad de ramas
		idBranch = GetBranchCount();
		IncrementBranchCount ();
		//Determinar su sprite
		int numR = Random.Range (1, int.MaxValue-1);
		//SetSprite(gameObject,"Sprites/log",numR%3);

		SetAngularPosition (numR);

	}

	void SetAngularPosition(int numR){
		switch (idBranch-1) {
		case 0:
			degree = ((numR % 25)*-1)+17;
			break;
		case 1:
			degree = (numR % 25)+(37*5)-17;
			break;
		case 2:
			degree = (numR % 25)+(37*4)-17;
			break;
		case 3:
			degree = (numR % 25)+(37*3)-17;
			break;
		case 4:
			degree = (numR % 25)+(37*2)-17;
			break;
		case 5:
			degree = (numR % 25)+(37*1)-17;
			break;
		default:
			degree = (numR % 180);
			break;
		}
		//Rotación
		transform.Rotate(0,0,(degree));
	}

}
