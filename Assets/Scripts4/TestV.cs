using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TestV : MonoBehaviour {
	//Gameobjects 
	public GameObject greenPanel;
	public GameObject redPanel;
	public GameObject greypanel;
    //public GameObject Inputfield;
    //public GameObject agradecimiento;
    
	public GameObject Uiadicionales;
	public GameObject Uipuntaje;
	//Text objects
	public Text infotext;
	public Text timetext;
	public Text puntaje;
    public Text gracias;

	//gamestates
	public enum estadoapp {Awake ,stop,begin, finished}
	public estadoapp elestadoes = estadoapp.stop;
	private float timer = 0f;

	public float startTime;

	//Almacena Random.RAnge
	public int kermit;

	//LUGAR DE PRUEBAS

	public float puntaje1;
	public float puntaje2;
	public float one = 0f;
	public float two;







	// Use this for initialization
	void Start () {
		kermit = Random.Range(5,7);
		
		timetext.GetComponent<Text> ();
		infotext.GetComponent<Text> ();
		puntaje.GetComponent<Text> ();
        gracias.GetComponent<Text>();










    }
	
	// Update is called once per frame
	void Update (){
		Debug.Log ("El tiempo de espera seleccionado fue: " + kermit);


		one +=  Time.deltaTime;
		//main Menu
		if(elestadoes == estadoapp.Awake){
			greypanel.SetActive (true);
			redPanel.SetActive (false);
			greenPanel.SetActive (false);
            //Inputfield.SetActive(false);
            //agradecimiento.SetActive(false);


            scaletime ();
			if (Input.GetMouseButtonDown(0)) {
				elestadoes = estadoapp.stop;
				redPanel.SetActive (true);
				greenPanel.SetActive (false);
				greypanel.SetActive (false);
                //Inputfield.SetActive(false);


				resetTime ();

			}
		
		//Inicio de prueba
		}else if (elestadoes == estadoapp.stop &&  one >= kermit) {
			//rojo
			redPanel.SetActive (true);
			greenPanel.SetActive (false);
			greypanel.SetActive (false);
			elestadoes = estadoapp.begin;
		



		} else if (elestadoes == estadoapp.begin) {
			//Prueba en progreso el contador comienza
			redPanel.SetActive (false);
			greenPanel.SetActive (true);
			greypanel.SetActive (false);
			Uipuntaje.SetActive (false);
			Activetime ();



			Debug.Log ("Stop");
       		//prueba ya se acabo
			if (Input.GetMouseButtonDown(0)) {
				scaletime ();
				elestadoes = estadoapp.finished;
				Uipuntaje.SetActive (true);
				Uiadicionales.SetActive (false);
                //Inputfield.SetActive(true);

                puntaje.text = "Tu puntaje fue: " +puntaje1.ToString ("");
                PlayerPrefs.SetFloat("Tu Puntaje",puntaje1);
                
                PlayerPrefs.GetFloat("Tu Puntaje");





            }
            else if (elestadoes == estadoapp.finished){
				puntaje1 = timer;
				Debug.Log ("tu puntaje fue: " +puntaje1);
                
                







            }


		}
			
			



			//timetext.text = "" + Time.time.ToString ("0.0");






	}
	public void Activetime(){
		timer +=  Time.deltaTime;
		timetext.text = "" +timer.ToString ("0.000");
		puntaje1 = timer;







	}
	public void scaletime(){
		Time.timeScale = 0f;
		print ("Time scale= " + Time.timeScale);

	}
	public void resetTime(){
		Time.timeScale = 1f;
		print ("Time scale= " + Time.timeScale);

	}
  
	public void boton(){
		SceneManager.LoadScene ("Mascota2");


	}




}
