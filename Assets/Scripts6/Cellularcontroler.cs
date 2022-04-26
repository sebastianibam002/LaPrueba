using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cellularcontroler: MonoBehaviour {


	public GameObject Botones;
	public GameObject Botones2;

	void Awake(){
		Botones.SetActive (true);
		Botones2.SetActive (false);
	}

	public void Siguiente(){
	
		Botones.SetActive (false);
		Botones2.SetActive (true);
	
	}
		

}
