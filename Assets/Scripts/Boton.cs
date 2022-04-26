using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour {

	public GameObject Controlador;


	public void hey(){
		Controlador.SendMessage ("RestartGame");
}
}
