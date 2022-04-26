using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasController : MonoBehaviour {

	public float velocity = 2f;
	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		


	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Destroyer") { 

			Destroy (gameObject);

		}
	}

	public void Begin(){


		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = Vector2.left * velocity;
	}

}
