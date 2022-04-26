
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class Shop : MonoBehaviour {

    public int PuntosTotales;
    public Text Money;
	private int Coins;
    public int[] puntosjuego;
    



    // Use this for initialization
    void Start () {


        puntosjuego = new int[4];
        puntosjuego[0] = PlayerPrefs.GetInt("Mejores Puntos");//JUEGO 2 "Naves
        puntosjuego[1] = PlayerPrefs.GetInt("Max Points");//"JUEGO 1 "jUMP"
        puntosjuego[2] = PlayerPrefs.GetInt("Max Points2");// JUEGO 3 
        puntosjuego[3] = PlayerPrefs.GetInt("Max PointsGT")/ 10; // VELOCIDAD DE REACCI0ON JUEGO4

        PuntosTotales = (puntosjuego[0] + puntosjuego[1] + puntosjuego[2] + puntosjuego[3]);
        print(PuntosTotales);

        PlayerPrefs.SetInt("Puntos totales", PuntosTotales);
        PlayerPrefs.GetInt("Puntos totales");

	


    }
	
	// Update is called once per frame
	void Update () {
		Coins = PlayerPrefs.GetInt ("Money1");

		Money.text = Coins.ToString();
        

    }
}
