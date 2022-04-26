using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animación : MonoBehaviour {

	public GameObject Player;
	public void segundaAnim(){
		Player.SendMessage ("SegundaAnimacion");
		print ("hey");
	}
}