using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class VelocidadeReaccion : MonoBehaviour {


	public Text	tiempoText;
	public float tiempo = 0.0f;
	public string levelToLoad;
	public Text pointsText;
	public Text recordText;
	public Text recordVText;
	private int pointsGT;
	public float velocidad;


	public Text veleText;
	public int numero;
	public GameObject uiIdle;
	public GameObject uiScore;
	public GameObject uipause;
	public GameObject MenuControl;
	public GameObject Pause;

	public GameObject money;
	public int Lifes = 3;
	private int velocidadint;

	private float [] recompenzas  = new float[11];

	public enum GameState{parado, comenzado}
	public GameState gameState = GameState.parado;




	// Use this for initialization
	void Start () {




		recordText.text = "BEST: " + GetMaxScoreGT().ToString();
		recordVText.text = "VELOCIDAD:  " + velocidad.ToString();
		veleText.text = "BEST VELOCIDAD:  " + GetMaxVel().ToString();





		

	
		
	}
	
	// Update is called once per f	rame
	void Update () {
		


		if(gameState == GameState.parado && (Input.GetKeyDown ("up") || Input.GetMouseButton (0))){
			gameState = GameState.comenzado;
			uiIdle.SetActive (false);
			uiScore.SetActive (true);
			uipause.SetActive (true);


		}else if(gameState == GameState.comenzado){
		
			time ();
            Time.timeScale = 1;
			if(Input.GetMouseButtonDown (0)){
				IncreasePoints ();
				velocidad = pointsGT / 10;

				vele ();

			}



	

		}


		/*Debug.Log (velocidad);
		Debug.Log (pointsGT);
*/
recordVText.text = "VELOCIDAD:  " + velocidad.ToString ();
		veleText.text = "BEST VELOCIDAD: " + GetMaxVel().ToString ();







		if (tiempo <= 0) {


			RestartTwoGame ();



		}




	}
	public void time(){tiempo = tiempo - 1 * Time.deltaTime;
		tiempoText.text = "" + tiempo.ToString("f0");
	

	}		
	//velocidad

public void vele(){
		

		veleText.text = velocidad.ToString ();
		if (velocidad >= GetMaxVel ()) {
			veleText.text = "BEST VELOCIDAD:  " + GetMaxVel().ToString ();
			SaveScoresTT (velocidad);



		}
	}
	public float GetMaxVel(){

		return PlayerPrefs.GetFloat ("Max Vel", 0.0f);		
}
	public void SaveScoresTT(float currentPointss){

	 	 PlayerPrefs.SetFloat ("Max Vel", currentPointss);
}
	/*
ACA ESTAMOS HABALNDO DE PUNTOS 

.....................................
..................................
...........................
//////////////////////////////
/// //////////////////////////
/// /////////////////

	*/







	public int GetMaxScoreGT(){

	return PlayerPrefs.GetInt ("Max PointsGT", 0);

}

public void SaveScore(int currentPoints){

	PlayerPrefs.SetInt ("Max PointsGT", currentPoints);

	}
	public void IncreasePoints(){
		pointsGT++;
		pointsText.text = pointsGT.ToString ();
		if (pointsGT >= GetMaxScoreGT ()) {
			recordText.text = "BEST: " + GetMaxScoreGT().ToString ();
			SaveScore (pointsGT);


}
	}
	public void RestartTwoGame(){
		numero = Random.Range (0, 3);

		velocidadint = (int)(Mathf.Abs (velocidad));

		money.SendMessage("Increasethis", velocidadint);

        if (numero == 0) {
            SceneManager.LoadScene("Juego");


        } else if (numero == 1) {
            SceneManager.LoadScene("JuegoTwo");


        } else if (numero == 2) {
            SceneManager.LoadScene("RandomMonwy");
        }

		Debug.Log ("El siguiente juego es:" + numero);
	}

	public void Lifess(){

		if(velocidad < 1){
			Lifes--;
			print ("Tienes " + Lifes);

		}
	}


}

