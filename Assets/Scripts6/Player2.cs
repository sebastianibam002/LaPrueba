using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour {

	//private Animator animator;
	public Image fondoplayer;
	private Color32 [] colored = new Color32[11];
	private string[] obtenidos = new string[11];

	private int color;




	// Use this for initialization
	void Start () {
		skin();
		//animator = GetComponent<Animator> ();

		colored [0] = new Color32(255, 0, 0, 255);//Rojo+
		colored [1] = new Color32 (0, 84, 255, 248);//Azul
		colored [2] = new Color32 (255,237,0, 255);//Amarillo
		colored [3] = new Color32 (249,183, 248, 255);//Rosado
		colored [4] = new Color32 (193, 36, 189, 255);//Morado
		colored [5] = new Color32 (85, 195, 6, 255);//verde
		colored [6] = new Color32 (129, 62, 25, 255);//Cafe
		colored [7] = new Color32 (255, 132, 0, 255);//Naranja
		colored [8] = new Color32 (255, 255, 255, 255);//Blanco
		colored [9] = new Color32 (0, 202, 255, 255);//Azul claro
		colored [10] = new Color32 (236, 189, 87, 255);//Oro


		obtenidos [0] = "Rojo";
		obtenidos [1] = "Azul";
		obtenidos [2] = "Amarillo";
		obtenidos [3] = "Rosado";
		obtenidos [4] = "Morado";
		obtenidos [5] = "Verde";
		obtenidos [6] = "Cafe";
		obtenidos [7] = "Naranja";
		obtenidos [8] = "Blanco";
		obtenidos [9] = "AzulClaro";
		obtenidos [10] = "Oro";

		
	}
	
	// Update is called once per frame
	void Update () {
		skin ();
	}
	public void skin()


	{

		color = PlayerPrefs.GetInt ("skin");

		if (PlayerPrefs.GetInt ("skin") == PlayerPrefs.GetInt (obtenidos [color])) {
		
			fondoplayer.color = colored [PlayerPrefs.GetInt ("skin")];
		
		} else {
		
			fondoplayer.color = colored [0];
		
		}
		;






	}
		
}
