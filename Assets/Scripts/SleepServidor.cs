using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class SleepServidor : MonoBehaviour {
	public GameObject servidordormido;
	public Text reloj;

	private int horas;

	private string time;
	private string Hour;
	private string minutes;
	private string Seconds;

	void Start(){
		

	}

	
	// Update is called once per frame
	void Update () {
		Hour = DateTime.Now.Hour.ToString();
		minutes = DateTime.Now.Minute.ToString();
		Seconds = DateTime.Now.Second.ToString();


		time = Hour + ":" + minutes + ":" + Seconds;

		reloj.text = time;



		horas = DateTime.Now.Hour;

		if (horas >= 17 && horas < 18) {

			print ("La hora es: " + DateTime.Now.Hour);
			print ("Son las 6");
			servidordormido.SetActive (true);
		} else {
		
			servidordormido.SetActive (false);
		
		}
	}
}
