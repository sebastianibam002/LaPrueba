using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause : MonoBehaviour {

	bool active;
	Canvas canvas;
    


	// Use this for initialization
	void Start () {
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			active = !active;
			canvas.enabled = active;
			Time.timeScale = (active) ? 0 : 1f;
		
		}

        
		
	}

	public void Pausalo(){
		active = !active;
		canvas.enabled = active;
		Time.timeScale = (active) ? 0 : 1f;
        
	
	}

	public void Despausalo(){
		active = !active;
		canvas.enabled = active;
		Time.timeScale = (active) ? 0 : 1f;

	}
}
	/*
	public void GotoMainMenu(){
		if(Input.GetKeyDown("up") || Input.GetMouseButton(0)){
			
			SceneManager.LoadScene ("MenúPrincipal");
		}
	}
}
*/