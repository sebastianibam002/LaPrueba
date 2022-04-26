using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creditos : MonoBehaviour {

    public Text Puntosx;
    public Text JuegoTotal;
    public Text VelocidadPromedio;
    public Text VelocidadMon;
    public Text TiempodeReaccion;
    public Text nombres;
	public Text comida;
    public int velocidadmonedas;


    public string nombre;
    

	// Use this for initialization
	void Start () {


        print("Puntos Totels: " + PlayerPrefs.GetInt("Puntos totales"));
        Puntosx.text = "Puntos Totales: " + PlayerPrefs.GetInt("Puntos totales").ToString();
        //nombres.text = "Nombre: " + PlayerPrefs.GetString("nombre").ToString();
        TiempodeReaccion.text = "Tiempo de Reacción: " + PlayerPrefs.GetFloat("Tu Puntaje").ToString();

        JuegoTotal.text = "Tiempo Jugado:  " +Time.time.ToString();
        

        VelocidadPromedio.text = "Velocidad Promedio:  " + PlayerPrefs.GetInt("Max PointsGT").ToString();
        VelocidadMon.text = "Velocidad Monedas:  " + PlayerPrefs.GetInt("Punticos").ToString() + "M/S";
		comida.text = "Comida: " + PlayerPrefs.GetInt ("Food").ToString ();



    }
	
	// Update is called once per frame
	void Update () {



        //JuegoTotal.text = "Tiempo Jugado:  " + Time.time;
        //VelocidadMon.text = "Velocidad Monedas:  " + PlayerPrefs.GetInt("Punticos").ToString();

        //VelocidadMon.text = "Velocidad Monedas: " + velocidadmonedas.ToString();



    }
   
}
