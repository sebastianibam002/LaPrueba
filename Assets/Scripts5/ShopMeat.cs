using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMeat : MonoBehaviour {

	public int Carne = 1;
	public float Food;
	public GameObject Player;
	public GameObject Monedas;
	public Text advertencia;

	void Start(){
		Food = PlayerPrefs.GetFloat ("Food");
	}

	public void CompraCarne(){
		if( PlayerPrefs.GetInt("Money1") >= 10){
			print ("Puedes comprar carne");
			Food = (Food) + 0.50f;
			PlayerPrefs.SetFloat ("Food" , Food);
			print( PlayerPrefs.GetFloat("Food"));
			Monedas.SendMessage ("DecreaseMoney",10);
		}else if (PlayerPrefs.GetInt("Money1") <= 10){
			print ("No tienes suficiente dinero");
			advertencia.color = Color.red;
			advertencia.text = "   No tienes suficiente dinero".ToString();
		}
	}
}
