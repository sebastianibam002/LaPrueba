using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopChicken : MonoBehaviour {

	public int Pollo = 1;
	public float Food;

	public GameObject Monedas;
	public Text advertencia;

	void Start(){
		Food = PlayerPrefs.GetFloat ("Food");
	}

	public void CompraPollo(){
		if( PlayerPrefs.GetInt("Money1") >= 20){
			print ("Puedes comprar carne");
			Food = (Food) + 1.0f;
			PlayerPrefs.SetFloat ("Food" , Food);
			print( PlayerPrefs.GetFloat("Food"));
			Monedas.SendMessage ("DecreaseMoney",20);
		}else if (PlayerPrefs.GetInt("Money1") <= 20){
			print ("No tienes suficiente dinero");
			advertencia.color = Color.red;
			advertencia.text = "   No tienes suficiente dinero".ToString();
		}
	}
}