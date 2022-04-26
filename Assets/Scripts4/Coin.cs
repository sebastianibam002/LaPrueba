using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public GameObject coin;
	public int value;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

		
	}

	public void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			Debug.Log("+1");
		}
}
}
