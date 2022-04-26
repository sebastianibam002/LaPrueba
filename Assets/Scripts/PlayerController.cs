using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	public GameObject game;
	public GameObject Coin;
	public GameObject BalasGenerator;



	public GameObject enemyGenerator;
	private AudioSource audioPlayer;
	public AudioClip jumpClip;
	public AudioClip dieClip;
	private float startY;








	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		audioPlayer = GetComponent<AudioSource> ();
		startY = transform.position.y;
	
	
	

	





	}
	
	// Update is called once per frame
	void Update () {
		bool isGrounded = transform.position.y == startY;
		bool gamePlaying = game.GetComponent<GameController>().gameState == GameController.GameState.Playing;
		if (isGrounded && gamePlaying && (Input.GetKeyDown ("up") || Input.GetMouseButtonDown (0))) {
			UpdateState 		("PlayerJump");
			audioPlayer.clip = jumpClip;
			audioPlayer.Play ();




		}
	}
	public void UpdateState (string state = null ){
		if (state != null) {
			animator.Play (state); 
		}



	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") { 
			print ("Me muero");
			UpdateState ("PlayerDie");
			game.GetComponent<GameController> ().gameState = GameController.GameState.Ended;
			enemyGenerator.SendMessage ("CancelGenerator", true);
			BalasGenerator.SendMessage ("CancelGenerator", true);
		





			game.GetComponent<AudioSource> ().Stop ();
			audioPlayer.clip = dieClip;
			audioPlayer.Play ();

		



			game.SendMessage ("ResetTimeScale", 0.5f);
		} else if (other.gameObject.tag == "Point") {

			game.SendMessage ("IncreasePoints");
		} else if (other.gameObject.tag == "Coin") {

			Coin.SendMessage ("IncreaseMoney");

		}


		if (other.gameObject.tag == "Bala") {
		
			print ("Me muero");
			UpdateState ("PlayerDie2");
			game.GetComponent<GameController> ().gameState = GameController.GameState.Ended;
			enemyGenerator.SendMessage ("CancelGenerator", true);
			BalasGenerator.SendMessage ("CancelGenerator", true);
		





			game.GetComponent<AudioSource> ().Stop ();
			audioPlayer.clip = dieClip;
			audioPlayer.Play ();





			game.SendMessage ("ResetTimeScale", 0.5f);

		}
		
	}

	void GameReady(){
		game.GetComponent<GameController>().gameState = GameController.GameState.Ready;

	}


}

