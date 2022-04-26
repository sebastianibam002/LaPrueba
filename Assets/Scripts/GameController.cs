using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	public float parallaxSpeed = 0.02f;
	public RawImage background;
	public RawImage background2;
	public RawImage platform;
	public RawImage houses;
	public int numero;

	public int changelevel;
		

	public Text pointsText;
	public Text recordText;



	public enum GameState { Idle, Playing, Ended, Ready};
	public enum Playing{one, two, three};
	public GameObject uiIdle;
	public GameObject uiScore;
	public GameObject uiPause;
	public GameObject BG1;
	public GameObject BG2;



	public GameState gameState = GameState.Idle;
	public Playing playing = Playing.one;
	public GameObject player;

	private GameObject healthbar;
	public GameObject enemyGenerator;
	public GameObject CoinGenerator;
	public GameObject BalasGeneratorController;
	public GameObject BalasGeneratorControler2;
	public float scaleTime = 6f;
	public float scaleInc = .25f;

	private int points = 0;
	private int Money;
	private AudioSource musicPlayer;





	
	// Use this for initialization
	void Start () {

		recordText.text = "BEST: " + GetMaxScore().ToString();

		musicPlayer = GetComponent<AudioSource> ();

		BG1.SetActive (true);
		BG2.SetActive (false);

		
	}
	
	// Update is called once per frame
	void Update () {
//Money

		if(Input.GetKeyDown("up")){
			print ("Tiene: " + PlayerPrefs.GetInt("Money1") + " De dinero");
		}

		//Para comenzar el juego
		if (gameState == GameState.Idle && (Input.GetKeyDown ("up") || Input.GetMouseButtonDown (0))) {
			gameState = GameState.Playing;
			uiIdle.SetActive (false);
			uiScore.SetActive (true);
            Time.timeScale = 1;


			player.SendMessage ("UpdateState", "PlayerRun");
			enemyGenerator.SendMessage ("StartGenerator");
			CoinGenerator.SendMessage ("StartCoinGenerator");

			InvokeRepeating ("GameTimeScale", scaleTime, scaleTime);
			musicPlayer.Play ();
			//juego comenzado
		} else if (gameState == GameState.Playing) {
			//Comenzar efecto Parallax solo si el juego esta en playing
			Parallax ();

			uiPause.SetActive (true);

		}
	  //Estado Terminado
		else if (gameState == GameState.Ended) {
			CoinGenerator.SendMessage ("CancelCoinGnerator");
			BalasGeneratorControler2.SendMessage ("CancelGenerator", true);
			if (Input.GetKeyDown ("up") || Input.GetMouseButtonDown (0)) {
				RestartGame ();




		
				//TODO
	
			}

		}

		if (points > 20 && playing == Playing.one) {
			changelevel++;

			BG1.SetActive (false);
			BG2.SetActive (true);
			playing = Playing.two;
			print ("One" + changelevel);
			BalasGeneratorController.SendMessage ("StartGenerator");
			BalasGeneratorControler2.SendMessage ("StartGenerator");
			enemyGenerator.SendMessage ("CancelGenerator", true);
		} else if (playing == Playing.two) {
		
			Parallax2 ();
			print ("Two");
		
		}

	}

	void Parallax(){
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x + finalSpeed, 0f, 1f, 1f);
		platform.uvRect = new Rect (background.uvRect.x + finalSpeed, 0f, 1f, 1f);

		

}

	void Parallax2(){
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background2.uvRect = new Rect (background.uvRect.x + finalSpeed, 0f, 1f, 1f);

	
	
	}
	public void RestartGame(){
		ResetTimeScale ();
		numero = Random.Range (0, 3);
        if (numero == 0) {
            SceneManager.LoadScene("JuegoThree");

        } else if (numero == 1) {
            SceneManager.LoadScene("JuegoTwo");

        } else if (numero == 2) {
            SceneManager.LoadScene("RandomMonwy");
        }
		Debug.Log ("El siguiente nivel es: " + numero);
			
	
	}
	void GameTimeScale(){
	
		Time.timeScale += scaleInc;
		Debug.Log ("Ritmo incrementado: " + Time.timeScale.ToString());
	
}

	public void ResetTimeScale(float newTimeScale = 1f){
		CancelInvoke ("GameTimeScale");
		Time.timeScale = newTimeScale;
		Debug.Log("Ritmo reestablecido: " + Time.timeScale.ToString());
	
	}

	public void IncreasePoints(){
		points++;
		pointsText.text = points.ToString ();
		if (points >= GetMaxScore ()) {
			recordText.text = "BEST: " + GetMaxScore ().ToString ();
			SaveScore (points);

		}




	
	}

	public int GetMaxScore(){
	
		return PlayerPrefs.GetInt ("Max Points", 0);

	}

	public void SaveScore(int currentPoints){

		PlayerPrefs.SetInt ("Max Points", currentPoints);

	}
//Puntos Comida



}

