using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCookie : MonoBehaviour {

	public int Galleta = 1;
	public float Food;

	public GameObject Monedas;
	public Text advertencia;

	void Start(){
		Food = PlayerPrefs.GetFloat ("Food");
	}

	public void CompraGalleta(){
		if( PlayerPrefs.GetInt("Money1") >= 5){
			print ("Puedes comprar carne");
			Food = (Food) + 0.25f;
			PlayerPrefs.SetFloat ("Food" , Food);
			print( PlayerPrefs.GetFloat("Food"));
			Monedas.SendMessage ("DecreaseMoney",5);
		}else if (PlayerPrefs.GetInt("Money1") <= 5){
			print ("No tienes suficiente dinero");
			advertencia.color = Color.red;
			advertencia.text = "   No tienes suficiente dinero".ToString();
		}
	}
}