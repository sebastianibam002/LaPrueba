using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despausa : MonoBehaviour {
	public GameObject menu;

	public void MandaelMens (){
		menu.SendMessage ("Despausalo");
		print ("Despausando");




	}

}