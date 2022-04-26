using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamwWorld : MonoBehaviour {

	public Text food;
	private float Food;
	//public GameObject Shop;
	//public GameObject Gafas;
	public GameObject notificaciones;
	public GameObject Chest;
	public GameObject conexioninternet;
	public Text notxt;
	public bool yes;
	public Text Coin;
	Vector2 mov;
	private int howmuch;
	// Use this for initialization
//Variable para e informe diario

	private bool active;
	void Start () {
		active = true;

		howmuch = Random.Range (-1,20);
		Chest.SendMessage ("reward", howmuch);



		Time.timeScale = 1;
		Food = PlayerPrefs.GetFloat ("Food");
		yes = true;
		InvokeRepeating ("Subtract", 10f, 20f);
		InvokeRepeating ("change", 10f, 20f);
		//Shop.SetActive (false);

		if (PlayerPrefs.GetString ("username") == "") {

			SceneManager.LoadScene ("perfil");

		}
		if(PlayerPrefs.GetString ("username") != ""){

			print ("ya tenemos su usuario" + PlayerPrefs.GetString ("username"));
			notificaciones.SendMessage("TextThis", PlayerPrefs.GetString ("username").ToString());




		}

	}
	
	// Update is called once per frame
	void Update () {




		//Probar concexion a internet
	
		if (Application.internetReachability == NetworkReachability.NotReachable) {
			Debug.Log ("Error. Check internet connection!");
			conexioninternet.SetActive (true);

		} else { conexioninternet.SetActive (false);
		}

		food.text = PlayerPrefs.GetFloat ("Food").ToString();
		Coin.text = PlayerPrefs.GetInt ("Money1").ToString();


		if (PlayerPrefs.GetFloat ("Food") < 0) {
		


			notificaciones.SendMessage("TextThis", "Tengo Hambre");
		}
		if (PlayerPrefs.GetFloat ("Food") < (-10)){
			
			notificaciones.SendMessage("TextThis", "Me Morí");
		}
	


	}

	public void Subtract (){
		if (yes) {
			if (yes == true){
				Food = (Food) - 0.5f;
				yes = false;
		}
		}

			

		PlayerPrefs.SetFloat ("Food",Food);
		PlayerPrefs.GetFloat ("Food");

	}public void change(){
		yes = true;
	}


}
