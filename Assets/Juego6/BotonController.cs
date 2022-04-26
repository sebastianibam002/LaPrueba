using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BotonController : MonoBehaviour {
	public GameObject inicio;
	public GameObject juego;
	public GameObject puntaje;
	private enum gamestate {inicio, juego, puntaje};
	private gamestate elestadoes = gamestate.inicio;
	public GameObject money;


	public Image Boton1;
	public Image Boton2;
	public Image Boton3;
	public Image Boton4;
	public Image background;

	public Text puntajefinal;
	public Text nivel;
	public Text begin;
	public Text best;



	private Button Bo1;
	private Button Bo2;
	private Button Bo3;
	private Button Bo4;


	public int randomnumber;
	private bool active;
	private bool boton_1;
	private bool boton_2;
	private bool boton_3;
	private bool boton_4;
	public int puntos;



	private float tiempo;
	private float tiempo_1;

	private bool unlick;
	private int niveles;
	private bool tempo;
	private float decreasing;





	// Use this for initialization
	void Start () {
		

		decreasing = 0.9f;


	




	}

	// Update is called once per frame
	void Update () {
		




		//Estados Del Juego

		//print (decreasing);
		//print (tiempo_1);
		if(tempo){

			temporizador ();
		}




		switch (elestadoes) {
		case gamestate.inicio:
			inicio.SetActive (true);
			juego.SetActive (false);
			puntaje.SetActive (false);
			begin.text = "Toca la pantalla para continuar \nTR minimo: " + decreasing.ToString () + "\nTu Tiempo: " + PlayerPrefs.GetFloat ("tiempo_1").ToString ();
			Boton1.color = new Color32 (169, 169, 169, 255);
			Boton2.color = new Color32 (169, 169, 169, 255);
			Boton3.color = new Color32 (169, 169, 169, 255);
			Boton4.color = new Color32 (169, 169, 169, 255);

			boton_1 = false;
			boton_2 = false;
			boton_3 = false;
			boton_4 = false;

			Time.timeScale = 1;
			tiempo_1 = 0;

			//Texto
			nivel.text = "Nivel " + niveles;
			tempo = false;
			tiempo = Random.Range (1,10);


			if(Input.GetMouseButtonDown(0)){
				unlick = true;
				elestadoes = gamestate.juego;

			}


			break;

		case gamestate.juego:
			inicio.SetActive (false);
			juego.SetActive (true);
			puntaje.SetActive (false);
			//print (tiempo);

			if(unlick){

				tiempo -= Time.deltaTime;
				if(tiempo <= 0){

					randomnumber = Random.Range (1, 4);
					print (randomnumber);
					unlick = false;

					switch(randomnumber){

					case 1:
						Boton1.color = new Color32 (50, 120 , 189, 255);

						boton_1 = true;
						tempo = true;


						break;

					case 2:
						Boton2.color = new Color32 (50, 120 , 189, 255);
						boton_2 = true;
						tempo = true;


						break;


					case 3:
						Boton3.color = new Color32 (50, 120 , 189, 255);

						boton_3 = true;
						tempo = true;
						break;


					case 4:  
						Boton4.color = new Color32 (50, 120 , 189, 255);
						boton_4 = true;
						tempo = true;

						break;




					}
				}
			}

			break;

			//Puntaje 
		case gamestate.puntaje:


			inicio.SetActive (false);
			juego.SetActive (false);
			puntaje.SetActive (true);
			background.color = new Color32 (20, 91, 120, 255);
			puntajefinal.text = "Conseguiste: " + puntos;
			PlayerPrefs.SetInt ("Juego6Puntos", puntos);
			best.text = "Best Score: " + PlayerPrefs.GetInt ("BestJuego6", 0).ToString () + "\n\nBest Time: " + PlayerPrefs.GetFloat ("BestTime6", 0.0f).ToString() ;





		


			if(Input.GetMouseButtonDown(0)){
				
				SceneManager.LoadScene ("Mascota2");
				money.SendMessage ("Increasethis", PlayerPrefs.GetInt("Juego6Puntos"));
			}

			break;

		}

	}

	public void boton(int numero){
		//Si el boton 1 = true y yo preciono el boton con el número 1, suma un punto
		switch(numero){

		case 1: 

			if (boton_1) {
				gano ();


			} else {

				elestadoes = gamestate.puntaje;
			}
			break;
		case 2: 

			if(boton_2){
				decreasing = decreasing - 0.1f;
				gano ();


			}else {
				elestadoes = gamestate.puntaje;
				print ("perdiste");
			}
			break;
		case 3: 

			if(boton_3){
				decreasing = decreasing - 0.1f;
				gano ();

			}else {
				elestadoes = gamestate.puntaje;
				print ("perdiste");
			}
			break;
		case 4: 

			if(boton_4){
				print ("punto4");
				decreasing = decreasing - 0.1f;
				gano ();




			}else {

				print ("perdiste");
				elestadoes = gamestate.puntaje;
			}
			break;




		}

		}

	public void temporizador(){


		tiempo_1 += Time.deltaTime;


	}

	public void gano(){
		
		puntos++;
		niveles++;
		print (tiempo_1);
		PlayerPrefs.SetFloat ("tiempo_1", tiempo_1);
		PlayerPrefs.SetInt ("Juego6Puntos", puntos);
		//PlayerPrefs.SetFloat ("BestTime6", 4);
		print (PlayerPrefs.GetFloat("tiempo_1") +  " :fue tu tiempo: " + PlayerPrefs.GetFloat ("BestTime6"));


		if (puntos >= GetMaxScore ()) {

			SaveScore (puntos);
		}

		if(PlayerPrefs.GetFloat("tiempo_1") <= GetMaxScoreTime()){

			SaveScoreTime (PlayerPrefs.GetFloat("tiempo_1"));
		}
		  

		Time.timeScale = 0;

		if (tiempo_1 < decreasing) {

			elestadoes = gamestate.inicio;
		} else {

			elestadoes = gamestate.puntaje;

		}




	}
	public int GetMaxScore(){

		return PlayerPrefs.GetInt ("BestJuego6");

	}

	public void SaveScore(int currentPointst){

		PlayerPrefs.SetInt ("BestJuego6", currentPointst);

	}
	public float GetMaxScoreTime(){

		return PlayerPrefs.GetFloat ("BestTime6", 1);

	}

	public void SaveScoreTime(float currentPointst){

		PlayerPrefs.SetFloat ("BestTime6", currentPointst);

	}

	
	}

