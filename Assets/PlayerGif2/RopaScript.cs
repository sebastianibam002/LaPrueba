using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopaScript : MonoBehaviour {




	//PRUEBAS

	public Sprite [] prendas = new Sprite [10];

	public Dropdown dropdownTrajes;
	public Dropdown dropdownDeportiva;
	public GameObject money;
	private int buyint;
	private int precio;
	private string[] obtenidos = new string[10];
	private int restar;
	private bool activetrajes;
	private bool activeDeportiva;
	private int newvalue;
	//public Sprite prenda;
	private int subract;

	//EL tamaño del las imagenes debe ser del lienzo 269* 269 y las imagenes tirne como base un semicirculo blanco

	//UI

	public Text Dinero;
	public Text Advertencia;


	// Use this for initialization
	void Start () {

		dropdownDeportiva.interactable = true;
		dropdownTrajes.interactable = true;
		

		obtenidos[0] = "Traje1";
		obtenidos[1] = "Traje2";
		obtenidos[2] = "Traje3";
		obtenidos[3] = "Sudadera1";
		obtenidos[4] = "Sudadera2";
		obtenidos[5] = "Sudadera3";
		obtenidos[6] = "Sudadera4";
		obtenidos[7] = "Sudadera5";
		subract = PlayerPrefs.GetInt ("index") - 1;

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = prendas [subract];

		Advertencia.color = Color.black;
		Advertencia.text = "";
		restar = 0;
		activetrajes = true;
		activeDeportiva = true;

	}
	
	// Update is called once per frame
	void Update () {
		Dinero.text = PlayerPrefs.GetInt ("Money1").ToString(); 

		//dropdownDeportiva.interactable = activetrajes;
		//dropdownTrajes.interactable = activeDeportiva;

		
	}




	public void Dropdown_Change(int index){
		activetrajes = false;

		switch (index) {

		case 0:

			activetrajes = true;

			break;

		case 1:
			print ("Traje 1" + index);

			this.gameObject.GetComponent<SpriteRenderer> ().sprite = prendas [0];


			break;

		case 2:

			print ("Traje 2" + index);

			this.gameObject.GetComponent<SpriteRenderer>().sprite = prendas[1];
			precio = 30;
			break;

		case 3:
			print ("Traje 3" + index);

			this.gameObject.GetComponent<SpriteRenderer>().sprite = prendas[2];
			precio = 30;

			break;



		}
		PlayerPrefs.SetInt ("index", index);


	}

	public void buy()
	{
		restar = 0;


		//SELECT

		restar = (PlayerPrefs.GetInt ("index")) - 1;


		if (PlayerPrefs.GetInt ("index") == PlayerPrefs.GetInt (obtenidos [restar])) {


			print ("Seleccionado");
			Advertencia.color = Color.black;
			Advertencia.text = "Seleccionado";
		} else {

			if((PlayerPrefs.GetInt ("Money1")) >= precio){

				money.SendMessage ("DecreaseMoney", precio);
				print (PlayerPrefs.GetInt ("index"));
				save (PlayerPrefs.GetInt ("index"));
				Advertencia.text = precio.ToString();
			}else if(PlayerPrefs.GetInt ("Money1") < precio){
				Advertencia.color = Color.red;
				Advertencia.text = "No tienes fondos suficientes";
			}

		}



	}

	public void save(int ropa)
	{

		switch (ropa) {

		case 1:

			print ("Traje 1 comprado");

			PlayerPrefs.SetInt ("Traje1", 1);
			break;
		case 2:
			print ("Traje 2 comprado");

			PlayerPrefs.SetInt ("Traje2", 2);


			break;
		case 3:
			print ("Traje 3 comprado");

			PlayerPrefs.SetInt ("Traje3", 3);


			break;

		case 4:
			print ("Sudadera 1 comprada");
			PlayerPrefs.SetInt ("Sudadera1", 4);

			break;
		case 5:
			print ("Sudadera 2 comprada");
			PlayerPrefs.SetInt ("Sudadera2", 5);

			break;
		case 6:
			print ("Sudadera 3 comprada");
			PlayerPrefs.SetInt ("Sudadera3", 6);

			break;
		case 7:
			print ("Sudadera 4 comprada");
			PlayerPrefs.SetInt ("Sudadera4", 7);

			break;
		case 8:
			print ("Sudadera 5 comprada");
			PlayerPrefs.SetInt ("Sudadera5", 8);

			break;



		}




	}

	public void Select()

	{
		restar = 0;

		restar = (PlayerPrefs.GetInt ("index")) - 1;
		Advertencia.color = Color.black;

		if (PlayerPrefs.GetInt ("index") == PlayerPrefs.GetInt (obtenidos [restar])) {


			print ("Seleccionado");
			Advertencia.text = "Seleccionado";
		} else {
		
			print ("no lo tienes");
			Advertencia.text = "No lo tienes";
		
		}

	}
	public void Dropdown_ChangeDeportiva(int index){
		activeDeportiva = false;



		switch (index) {

		case 0:
			activeDeportiva = true;
			newvalue = 3;
			break;

		case 1:
			print ("Sudadera 1" + index);

			this.gameObject.GetComponent<SpriteRenderer> ().sprite = prendas [3];
			precio = 20;
			newvalue = 4;

			break;

		case 2:

			print ("Sudadera 2" + index);

			this.gameObject.GetComponent<SpriteRenderer>().sprite = prendas[4];
			precio = 20;
			newvalue = 5;
			break;

		case 3:
			print ("Sudadera 3" + index);

			this.gameObject.GetComponent<SpriteRenderer>().sprite = prendas[5];
			precio = 20;
			newvalue = 6;

			break;
		case 4:
			print ("Sudadera 4" + index);

			this.gameObject.GetComponent<SpriteRenderer>().sprite = prendas[6];
			precio = 20;
			newvalue = 7;

			break;
		case 5:
			print ("Sudadera 5" + index);

			this.gameObject.GetComponent<SpriteRenderer>().sprite = prendas[7];
			precio = 20;
			newvalue = 8;

			break;



		}
		PlayerPrefs.SetInt ("index", newvalue);

	}

	public void ninguno (){
	
		this.gameObject.GetComponent<SpriteRenderer>().sprite = prendas[9];
		PlayerPrefs.SetInt ("index", 9);
	
	}

}
