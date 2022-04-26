using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mundo : MonoBehaviour {

	public GameObject Coins;
	public GameObject Monedas;
	public GameObject Uinfotext;
	public GameObject Uicoins;
	public GameObject Puntajes;
	public GameObject info;
    public GameObject Pause;
    private AudioSource player;
	public AudioClip click;


	public Text puntaje;
	public Text MejorPuntaje;
	public Text Tiempo;




	public int puntos = 0;
    public int numero;
	public float one = 10f;
	public float timetostop = 0f;

	public enum Game {stop, begin, finished};
	public Game elestadoes = Game.stop;
	//Booleano para desbloquear 1 nivel


    // Use this for initialization
     void Awake()
    {
       // print(PlayerPrefs.GetInt("Mejores Puntos"));
        puntaje.text = "" + puntos.ToString();
        MejorPuntaje.text = "Best: " + GetMaxScore().ToString();
        Tiempo.text = "" + one.ToString("f0");
        info.SetActive(false);
        player = GetComponent<AudioSource>();
        //if (elestadoes == Game.begin) {
           // tiempo();
        //}
    }
    void Start () {

        print("Time scale= " + Time.timeScale);

	}
	
	// Update is called once per frame
	void Update () {
		

		if(Input.GetKeyDown("b")){
			puntos++;



		}
		puntaje.text = "" + puntos.ToString ();


        
        
        

		if (elestadoes == Game.stop) {
			Uinfotext.SetActive (true);
			Puntajes.SetActive (false);
			Uicoins.SetActive (false);
			if (Input.GetMouseButton (0)) {
				elestadoes = Game.begin;
                tiempo();
                Time.timeScale = 1;
			}
		} else if (elestadoes == Game.begin) {
			Uinfotext.SetActive (false);
			Puntajes.SetActive (true);
			Uicoins.SetActive (true);
			info.SetActive (false);
			tiempo ();
            //one -= Time.deltaTime;

            Tiempo.text = "" + one.ToString("f0");
			if(one <= timetostop){
				elestadoes = Game.finished;
			}

		} else if (elestadoes == Game.finished) {
			
			Destroy (Uicoins);

			print("juego termindao");	
			info.SetActive (true);
            if (Input.GetMouseButton(0)) { RestartGame(); }

            PlayerPrefs.SetInt("Punticos", puntos/10);
            PlayerPrefs.GetInt("Punticos");



		}

		if(puntos >= 20){

			print ("puedes pasar");
			//unlock1 = true;
			PlayerPrefs.SetString ("unlock1", "Leve1");
			SceneManager.LoadScene ("Monedas2.0");
			PlayerPrefs.SetInt ("PuntosActualizados", puntos);



		}
		
	}

	public void tiempo(){
		one -= Time.deltaTime;

	}
	public void Sumale(){
		puntos++;
		Monedas.SendMessage ("IncreaseMoney");
		print ("tienes: "  + puntos);

		if (puntos >= GetMaxScore ()) {

			SaveScore (puntos);
			MejorPuntaje.text = "Best: " + GetMaxScore ().ToString ();

		}



	}

	public int GetMaxScore(){

		return PlayerPrefs.GetInt ("Mejores Puntos", 0);

	}

	public void SaveScore(int currentPointst){

		PlayerPrefs.SetInt ("Mejores Puntos", currentPointst);

	}
	public void Sound(){
	
		player.clip = click;
		player.Play ();
		print ("Sound Activated");

	}
    public void RestartGame() {

        //ResetTimeScale();
        numero = Random.Range(0, 3);
        if (numero == 0)
        {
            SceneManager.LoadScene("JuegoThree");

        }
        else if (numero == 1)
        {
            SceneManager.LoadScene("JuegoTwo");

        }
        else if (numero == 2)
        {
            SceneManager.LoadScene("Juego");
        }
        Debug.Log("El siguiente nivel es: " + numero);
    }
}


