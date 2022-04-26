using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MundoController : MonoBehaviour {

	private AudioSource player;
	public AudioClip point;

	public GameObject inicio;
	public GameObject juego;
	public GameObject Monedas;
	public GameObject money;

	private bool begin;
	private int puntos;
	private int puntostotales;
	private bool dinero;

	public Text puntaje;
	public Text timer;
	public Text indicaciones;
	public Text Nivel2;
	public Image background;
	private enum gamestate {nivel1, nivel2, nivel3, final, ganaste};
	private gamestate elestadoes = gamestate.nivel1;
	private bool active = true;

	private float tiempo = 20;
	private float tiempo2 = 30;
	private float tiempo3 = 40;
	private bool cerrar;

	// Use this for initialization
	void Start () {
		
		player = GetComponent<AudioSource>();
		inicio.SetActive (true);
		juego.SetActive (false);
		dinero = true;
		puntos = 0;


	}
	
	// Update is called once per frame
	void Update () {

		puntostotales = puntos + PlayerPrefs.GetInt ("PuntosActualizados");
		puntaje.text = "Puntos: " + puntostotales.ToString();



		switch (elestadoes) {
		case gamestate.nivel1:
			//Indicaiones del GUI
			indicaciones.text = "Dificultad: facil\n\nObJetIvo: 60 monedas\n\nTiempo: 20(s)";
			Nivel2.text = "Nivel 1";
			background.color = new Color32(20, 91, 120, 255);

			//COdigo del juego como tal

			if (Input.GetMouseButtonDown (0)) {
				inicio.SetActive (false);
				juego.SetActive (true);
				begin = true;
				puntostotales = puntos + PlayerPrefs.GetInt ("PuntosActualizados");

			} 
			if(begin){

				tiempo -= Time.deltaTime;
				timer.text = "Tiempo: " + (Mathf.Abs(tiempo)).ToString();
				if(tiempo < 0){
					begin = false;
					elestadoes = gamestate.final;


				}

			}

			if(puntos >= 40){
				PlayerPrefs.SetInt ("puntostotales", puntostotales);
				print ("Nivel2");
				elestadoes = gamestate.nivel2;




			}

			break;

		case gamestate.nivel2:
			if (elestadoes == gamestate.nivel2 && active == true) {
				inicio.SetActive (true);
				juego.SetActive (false);


			}
			//Indicaiones del GUI
			indicaciones.text = "Dificultad: media\n\nObJetIvo: 100 monedas\n\nTiempo: 30(s)";
			Nivel2.text = "Nivel 2";
			background.color = new Color32(24, 120, 20, 255);

			//COdigo del juego como tal

			if (Input.GetMouseButtonDown (0)) {
				inicio.SetActive (false);
				juego.SetActive (true);
				begin = true;
				puntostotales = puntos + PlayerPrefs.GetInt ("PuntosActualizados");
				active = false;

			} 
			if(begin){
				

				tiempo2 -= Time.deltaTime;
				timer.text = "Tiempo: " + (Mathf.Abs(tiempo2)).ToString();

				if(tiempo2 < 0){
					begin = false;
					elestadoes = gamestate.final;


				}

			}

			if(puntos >= 80){
				PlayerPrefs.SetInt ("puntostotales", puntostotales);
				print ("Nivel3");
				elestadoes = gamestate.nivel3;
				active = true;



			}


			break;

		

		case gamestate.nivel3:

			//Indicaiones del GUI
			if (elestadoes == gamestate.nivel3 && active == true) {
				inicio.SetActive (true);
				juego.SetActive (false);


			}

			indicaciones.text = "Dificultad: extremo\n\nObJetIvo: 120 monedas\n\nTiempo: 40(s)";
			Nivel2.text = "Nivel 3";
			background.color = new Color32(156, 0, 0, 255);

			//COdigo del juego como tal

			if (Input.GetMouseButtonDown (0)) {
				inicio.SetActive (false);
				juego.SetActive (true);
				begin = true;
				puntostotales = puntos + PlayerPrefs.GetInt ("PuntosActualizados");
				active = false;

			} 
			if(begin){
				
				//tiempo3 = 40;
				tiempo3 -= Time.deltaTime;

				timer.text = "Tiempo: " + (Mathf.Abs(tiempo3)).ToString();

				if(tiempo < 0){
					begin = false;
					elestadoes = gamestate.final;


				}

			}

			if(puntos >= 100){
				PlayerPrefs.SetInt ("puntostotales", puntostotales);
				elestadoes = gamestate.ganaste;
			

				//elestadoes = gamestate.nivel2;

			}


			break;


		case gamestate.final:
			inicio.SetActive (true);
			juego.SetActive (false);
			indicaciones.text = "Perdiste,  Tu Puntaje fue: " + puntostotales;
			;
			Nivel2.text = "Nivel 3";
			background.color = new Color32 (20, 91, 120, 255);
			if(dinero)
			{
				money.SendMessage ("Increasethis", puntostotales);
				dinero = false;
			}



			break;

		case gamestate.ganaste:
			inicio.SetActive (true);
			juego.SetActive (false);
			background.color = new Color32 (156, 0, 0, 255);

			if (cerrar) {
				puntostotales = puntostotales + 30;
				cerrar = false;
			}
			PlayerPrefs.SetInt ("puntostotales", puntostotales);
			indicaciones.text = "Ganaste: " + puntostotales + " monedas + un bono de 30";
			if(dinero)
			{
				money.SendMessage ("Increasethis",puntostotales);
				dinero = false;
			}

			Monedas.SendMessage ("SaveScore", puntostotales);


			if(Input.GetMouseButtonDown(0)){

				SceneManager.LoadScene ("Mascota2");
			}




			break;


		}

	}
	public void sonido(){
		player.clip = point;
		player.Play ();

		puntos++;
	
	}




}
