using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private const string SCORE_TEXT = "Score: ";

	public float floatscore;

	public float startTime;

	public Text scoretext;

	void Awake(){
		startTime = Time.time;

		scoretext = GetComponent<Text> ();
	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		floatscore = Time.time - startTime;
		int intScore = GetIntScore ();

		scoretext.text = SCORE_TEXT + intScore;

		
	}
	public int GetIntScore(){
		return Mathf.RoundToInt (floatscore);

	}
}
