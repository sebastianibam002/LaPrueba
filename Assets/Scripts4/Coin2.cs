using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2 : MonoBehaviour {
	public int points;
	public GameObject Coin;
	public GameObject game;
	//private AudioSource audioPlayeer;
	//public AudioClip Click;
	public int kermit;
	public int kermitY;

	void start (){
		//audioPlayeer = GetComponent<AudioSource> ();
	}

	public void SumaleunPunto (){
		
		kermit	= Random.Range(-5,5);
		kermitY	= Random.Range(-5,5);
		//audioPlayeer.clip = Click;
		//audioPlayeer.Play ();
		
		game.SendMessage ("Sumale");
		game.SendMessage ("Sound");
		Coin.transform.position = new Vector2 (kermit, kermitY);



		//print ( "position changed = " + transform.position.x);





	}
}