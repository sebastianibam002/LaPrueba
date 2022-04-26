using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
	
	public GameObject Coin;
	public GameObject MundoController;




	public int Positionx;
	public int PositionY;

	void start (){
		
	}

	public void SumaleunPunto (){

		Positionx	= Random.Range(-5,5);
		PositionY	= Random.Range(-5,5);


		//game.SendMessage ("Sumale");
		//game.SendMessage ("Sound");
		Coin.transform.position = new Vector2 (Positionx, PositionY);


		MundoController.SendMessage ("sonido");



		//MundoController.SendMessage ("Puntos");

		//print ( "position changed = " + transform.position.x);





	}

}