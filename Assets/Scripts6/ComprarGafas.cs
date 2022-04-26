using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprarGafas : MonoBehaviour {


	public GameObject GameWorld;
	public Text advertencia;
	public GameObject Monedas;

	public void Gafas(){
	
	
		Comprargafas ();
		print ("Te has comprado unas gafas");
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
