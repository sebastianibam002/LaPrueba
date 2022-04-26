using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ropa2 : MonoBehaviour {

	public Sprite [] prendas = new Sprite [10];
	private string[] obtenidos = new string[10];
	private int restar;
	// Use this for initialization
	void Start () {
		
		restar = PlayerPrefs.GetInt ("index") - 1;
		obtenidos[0] = "Traje1";
		obtenidos[1] = "Traje2";
		obtenidos[2] = "Traje3";
		obtenidos[3] = "Sudadera1";
		obtenidos[4] = "Sudadera2";
		obtenidos[5] = "Sudadera3";
		obtenidos[6] = "Sudadera4";
		obtenidos[7] = "Sudadera5";

	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("index") == PlayerPrefs.GetInt (obtenidos [restar])) {
			
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = prendas [restar];
		} else {
		
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = prendas [9];
		
		}
	}
}
