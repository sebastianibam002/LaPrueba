using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anterior : MonoBehaviour {

	public GameObject Botones;
	public GameObject Botones2;


	public void anterior(){

		Botones.SetActive (true);
		Botones2.SetActive (false);

	}
}
