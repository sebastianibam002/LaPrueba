using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveScript : MonoBehaviour {

	public GameObject one;
	public GameObject two;
	public GameObject three;
	public static LiveScript estadojuego;


	void Awake (){
	


			DontDestroyOnLoad (gameObject); 

	}


	// Use this for initialization
	void Start () {

		one.SetActive (true);
		two.SetActive (true);
		three.SetActive (true);


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
