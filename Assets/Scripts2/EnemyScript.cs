
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	// Variable para gestionar la velocidad desde Unity
	public float speed;
	public GameObject gameTwo;
	public GameObject enemiesGenerator;
	public GameObject Coin;
	public AudioClip explosion;
	public AudioClip pointclip;





	private AudioSource audiop;
	private Animator animator;


	// Variable para establecer un punto de destino
	Vector3 target;

	void Start () {
		// Inicialmente el punto de destino es la posición actual
		target = transform.position;
		animator = GetComponent<Animator>();
		audiop = GetComponent<AudioSource> ();

	}

	void Update () {
		bool gameTwoPlaying = gameTwo.GetComponent<GameTwoController> ().gameStatet == GameStatet.playing;


		/*
			Puedes eliminar el bloque if para crear el efecto de perseguir al puntero 
			dejando únicamente el contenido que establece el target
		*/

		// Detectamos cuando hacemos clic izquierdo
		if (gameTwoPlaying && (Input.GetMouseButtonDown(0))){  
			// Buscamos la posición del clic respecto a la escena
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			// Establecemos la z a 0 para que no se modifique la profundidad
			target.z = 0f;
		}

		// Movemos el objeto hacia el punto de destino a una velocidad rectificada
		transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);

		// Optaticamente podemos debugear una línea con el trayecto a recorrer
		Debug.DrawLine(transform.position, target, Color.red);
	}


	void OnTriggerEnter2D (Collider2D other){
		if(other.gameObject.tag == "enemie" ){
			UpdateState("PlayerDiesanim");
			gameTwo.GetComponent<GameTwoController> ().gameStatet = GameStatet.Ended;
			enemiesGenerator.SendMessage ("CancelGenerations", true);
			gameTwo.SendMessage ("ResetTimeScaleT"); 
			gameTwo.GetComponent<AudioSource> ().Stop ();
		
	







			audiop.clip = explosion;
			audiop.Play ();

			
		}else if (other.gameObject.tag == "PointT"){
			gameTwo.SendMessage ("IncreasePointsT");
			audiop.clip = pointclip;
			audiop.Play ();

			
		}else if(other.gameObject.tag == "Coin"){

			Coin.SendMessage ("IncreaseMoney");
		}

	}
	public void UpdateState(string state = null){
		if(state != null){animator.Play (state);
			
			
		}
	}
	void GameReady(){
		gameTwo.GetComponent<GameTwoController> ().gameStatet = GameStatet.Ready;


	}
}
