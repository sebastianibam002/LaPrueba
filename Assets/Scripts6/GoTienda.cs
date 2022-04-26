using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoTienda : MonoBehaviour {

	public GameObject House;
	public GameObject Shop;
	public GameObject GameWorld;
	public GameObject Monedas;
	public Text advertencia;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Tienda(){

		House.SetActive (false);
		Shop.SetActive (true);

	}
	public void Casa(){

		House.SetActive (true);
		Shop.SetActive (false);

	}

	public void Comprargafas(){
		if (PlayerPrefs.GetInt ("Money1") >= 100) {
			GameWorld.SendMessage ("ActivarGafas");
			Monedas.SendMessage ("DecreaseMoney", 100);
		}else if (PlayerPrefs.GetInt("Money1") <= 100){
			advertencia.color = Color.red;
			advertencia.text = "   No tienes suficiente dinero".ToString();
		}
	}
}
