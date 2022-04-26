using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PararTiempo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 0f;

		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Time.time);

		
	}
}
