using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storescript : MonoBehaviour {
	



	//NO ALTERAR
	public Text indicaciones;
	//Para bajar dinero
	public GameObject money;
	public Image playercolor;
	public Text precio;
	public Text Dinero;
	private bool yalotienes;
	private bool reset;
	private int color;

	//private string lastcolor;

	private Color32 [] colored = new Color32[11];
	//Colores Obtenidos
	private string[] obtenidos = new string[11];



	// Use this for initialization
	void Start () {
		
		
		Dinero.text = PlayerPrefs.GetInt ("Money1").ToString(); 




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



		color = PlayerPrefs.GetInt ("skin");

		if (PlayerPrefs.GetInt ("skin") == PlayerPrefs.GetInt (obtenidos [color])) {

			playercolor.color = colored [PlayerPrefs.GetInt ("skin")];

		} else {

			playercolor.color = colored [0];

		}


	


	}
	
	// Update is called once per frame
	void Update () {
		

		Dinero.text = PlayerPrefs.GetInt ("Money1").ToString(); 
		if(Input.GetKeyDown("b")){
			money.SendMessage ("Increasethis", 200);

		}

	}

	public void colores (int color)
	{   

		//lastcolor = PlayerPrefs.GetInt (obtenidos [color]).ToString();


		if (color == PlayerPrefs.GetInt (obtenidos [color])) {
			print ("Ya lo tienes");
			//money.SendMessage("Increasethis",20);
			playercolor.color = colored [color];
			precio.fontSize = 15;
			precio.color = Color.black;
			precio.text = "Seleccionado";
			yalotienes = true;
	} else { yalotienes = false;

			if (PlayerPrefs.GetInt ("Money1") >= 20 && yalotienes == false) {
				Costos (20);
				playercolor.color = colored [color];
				precio.text = "20";
				precio.color = Color.black;
				precio.fontSize = 40;
				save (color);

			} else if(PlayerPrefs.GetInt ("Money1") <= 20 && reset == false){

				precio.text = "Fondos Incuficientes";
				precio.color = Color.red;
				precio.fontSize = 17;



			}

	}


		//print ("último color: " + lastcolor);
		PlayerPrefs.SetInt("skin",color);



	}
	public void Costos(int value)
	{

		money.SendMessage ("DecreaseMoney", value);

	}
		
	public void save(int color){
	
		switch (color) 
		{
		case 0:
			print ("Rojo");
			PlayerPrefs.SetInt ("Rojo", 0);
			break;
		case 1:
			print ("Azul");
			PlayerPrefs.SetInt ("Azul", 1);
			break;
		case 2:
			print ("Amarillo");
			PlayerPrefs.SetInt ("Amarillo", 2);
			break;
		case 3:
			print ("Rosado");
			PlayerPrefs.SetInt ("Rosado", 3);
			break;
		case 4:
			print ("Morado");
			PlayerPrefs.SetInt ("Morado", 4);
			break;
		case 5:
			print ("Verde");
			PlayerPrefs.SetInt ("Verde", 5);
			break;
		case 6:
			print ("Cafe");
			PlayerPrefs.SetInt ("Cafe", 6);
			break;
		case 7:
			print ("Naranja");
			PlayerPrefs.SetInt ("Naranja", 7);
			break;
		case 8:
			print ("blanco");
			PlayerPrefs.SetInt ("Blanco", 8);
			break;
		case 9:
			print ("Azul Claro");
			PlayerPrefs.SetInt ("AzulClaro", 9);
			break;
		case 10:
			print ("Oro");
			PlayerPrefs.SetInt ("Oro", 10);
			break;
		
		}


	
	
	}




}
