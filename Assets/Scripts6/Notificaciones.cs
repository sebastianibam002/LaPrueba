using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notificaciones : MonoBehaviour {

	public Text textos;
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TextThis(string print)
	{
		textos.text = "" + print;

	}
}
