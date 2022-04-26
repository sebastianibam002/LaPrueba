using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class informe : MonoBehaviour {


	string informurl = "https://sebastianibarramedez.000webhostapp.com/InsertarTabla2.php";
	string rankingurl = "https://sebastianibarramedez.000webhostapp.com/InsertarTabla3.php";
	public Text check;

	private string time;
	private string Hour;
	private string minutes;
	private string Seconds;
	private string day;
	private string month;
	private string year;
	//SEGUNDO INFORME

	private int full;

	private int horas;






	public void Awake(){
		



		//DDDDDDD
		Hour = DateTime.Now.Hour.ToString();
		minutes = DateTime.Now.Minute.ToString();
		Seconds = DateTime.Now.Second.ToString();
		day = DateTime.Now.Day.ToString();
		month = DateTime.Now.Month.ToString();
		year = DateTime.Now.Year.ToString();

		time = Hour + ":" + minutes + ":" + Seconds + "|" +day + "/" +month +"/" +year;  
		//SEGundo informe
		full = (PlayerPrefs.GetInt ("Max Points") + PlayerPrefs.GetInt ("Max Points2") + PlayerPrefs.GetInt ("Max PointsGT") + PlayerPrefs.GetInt ("Mejores Puntos"));
		print (full + "dd");


		//Debido a que el servidor todos los dias a las 6 de la tarde hasta las 7 entoncesvoy  abloquear la pantalla con el coigo a continuaciñon
	





		//12:19:41|1/1/2018 "Ejemplo de vista"



		//print (time);




	}


	
		public void DiaryInform() {
		print(PlayerPrefs.GetString ("username"));
		print (PlayerPrefs.GetFloat("Tu Puntaje"));
		print(Time.time);
		print(PlayerPrefs.GetFloat ("Food"));
		check.text = "Gracias por su Información";




			WWWForm form = new WWWForm ();
		form.AddField ("nombrePost", PlayerPrefs.GetString ("username"));
		form.AddField ("tr_testPost", PlayerPrefs.GetFloat("Tu Puntaje").ToString());
		form.AddField ("tiempoPost", Time.time.ToString());
		form.AddField ("comidaPost", PlayerPrefs.GetFloat ("Food").ToString());
		form.AddField ("horaPost", time);
		WWW www = new WWW (informurl, form);

		rankinginfo ();

		}

	public void rankinginfo(){
		
		full = (PlayerPrefs.GetInt ("Max Points") + PlayerPrefs.GetInt ("Max Points2") + PlayerPrefs.GetInt ("Max PointsGT") + PlayerPrefs.GetInt ("Mejores Puntos"));
		print (full + "dd");
		WWWForm form = new WWWForm ();
		form.AddField ("nombrePost", PlayerPrefs.GetString ("username").ToString());
		form.AddField ("max1Post", PlayerPrefs.GetInt ("Max Points").ToString());//Jump guy
		form.AddField ("max2Post", PlayerPrefs.GetInt ("Max Points2").ToString());//Esquivar meteoros
		form.AddField ("max3Post", PlayerPrefs.GetInt ("Max PointsGT").ToString());//Tap Tap
		form.AddField ("max4Post", PlayerPrefs.GetInt ("Mejores Puntos").ToString());//Monedas
		form.AddField("max5Post", PlayerPrefs.GetFloat ("BestTime6").ToString());//Tiempo de los botones
		form.AddField ("totalPost", full.ToString());//Total
		WWW www = new WWW (rankingurl, form);
	
	
	}

	

}
