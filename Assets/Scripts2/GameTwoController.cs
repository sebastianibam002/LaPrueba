using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum GameStatet {Ilde, playing, Ended, Ready	}

public class GameTwoController : MonoBehaviour {
	
	[Range (0f, 0.20f)]
	public float parallaxSpeed = 0.02f;
	public RawImage backgroundtwo;
	public GameObject playertwo;
	public GameObject uiIdle;
	public GameObject uiScore;
	public GameObject Coin;
	public GameObject uiPause;
	public int numero;

	public GameObject  EnemiesGeneratorController;
	public float scaleTimeTwo = 6f;
	public float scaleIncTwo = 0.25f;
	public Text pointsTextT;
	public Text record2Text;
	public GameStatet gameStatet = GameStatet.Ilde;


	private AudioSource music; 
	private int points = 0;





	// Use this for initialization
	void Start () {
		music = GetComponent<AudioSource> ();
		record2Text.text = "BEST: " + GetMaxScore2 ().ToString ();


	}
	
	// Update is called once per frame
	void Update () {
        //Game Start
		if (gameStatet == GameStatet.Ilde && (Input.GetKeyDown ("up") || Input.GetMouseButton (0))) {
			gameStatet = GameStatet.playing;
			uiIdle.SetActive (false);
			uiScore.SetActive (true);
			uiPause.SetActive (true);
            Time.timeScale = 1;

			playertwo.SendMessage ("UpdateState", "Playeridle");
			Coin.SendMessage ("StartCoinGenerator");
			EnemiesGeneratorController.SendMessage ("StartGenerations");
			InvokeRepeating ("GameTimeScaleT", scaleTimeTwo, scaleTimeTwo );


			music.Play ();
			//Game In Movement
		} else if (gameStatet == GameStatet.playing) {
			Parallax ();


			//Game Prepared for restart
		}else if(gameStatet == GameStatet.Ready){
			Coin.SendMessage ("CancelCoinGnerator");
			if (Input.GetKeyDown ("up") || Input.GetMouseButton (0)) {
				RestartTwoGame ();




			}
	}




	}
	void Parallax(){
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		backgroundtwo.uvRect = new Rect (backgroundtwo.uvRect.x + finalSpeed, 0f, 1f, 1f);
	}
	public void RestartTwoGame(){
		numero = Random.Range (0, 3);

        if (numero == 0) {
            SceneManager.LoadScene("Juego");

        } else if (numero == 1) {
            SceneManager.LoadScene("JuegoThree");


        } else if (numero == 2) {
            SceneManager.LoadScene("RandomMonwy");
        }

		Debug.Log ("El siguiente juego es:" + numero);
	}

	void GameTimeScaleT(){
		Time.timeScale += scaleIncTwo;
		Debug.Log ("Ritmo Incrementado: " + Time.timeScale.ToString());
	}

	public void ResetTimeScaleT(){
		CancelInvoke ("GameTimeScaleT");
		Time.timeScale = 1f;
		Debug.Log ("Ritmo restablecido: " + Time.timeScale.ToString());
	}

	public void IncreasePointsT(){
		
		pointsTextT.text = (++points).ToString ();
		if (points >= GetMaxScore2 ()) {
			record2Text.text = "BEST: " + points.ToString ();
			SaveScore2 (points);
		}


	}

	public int GetMaxScore2(){
		return PlayerPrefs.GetInt ("Max Points2", 0);

	}

	public void SaveScore2(int currentPoints){

		PlayerPrefs.SetInt ("Max Points2", currentPoints);
		 
	
	}




}
