using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Variable para gestionar la velocidad desde Unity
    public float speed;

    Animator anim;
    Rigidbody2D rb2d;
	//Variables Vida
	public int Health = 3;
	public GameObject Vida1;
	public GameObject Vida2;
	public GameObject Vida3;
	//Variables Comida
	public int Food ;
	public GameObject comida1;
	public GameObject comida2;
	public GameObject comida3;
	//Variable de tiempo
	public float tiempo;
	public float tiemporango;
	public int Pedri;


    Vector2 mov;

    void Start()

	{
		

		Food = PlayerPrefs.GetInt ("Food");

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        

    }

    void Update()
    {
		Food = PlayerPrefs.GetInt ("Food");


		//PlayerPrefs.SetInt ("Food", Food);
		//PlayerPrefs.GetInt ("Food");
			
			
		Time.timeScale = 1;
		//Vidas del jugador
		Vidas ();
		//Comida ();
		RestarComida ();
		print ("Comida antes " + Food);

		//Movimiento del jugador
	
			mov = new Vector2 (
           
				Input.GetAxisRaw ("Mouse X"),
				Input.GetAxisRaw ("Mouse Y")
            
			);

		if (mov != Vector2.zero)
        {
			anim.SetFloat("movX", mov.x);
			anim.SetFloat("movY", mov.y);
            anim.SetBool("Walking", true);
        }
        else {
            anim.SetBool("Walking", false);
        }
		//REINICIO DE COMIDA
		if(Input.GetKeyDown("space")){
			PlayerPrefs.SetInt ("Food", 3);
			PlayerPrefs.GetInt ("Food");
			print ("Reiniciado");
		}
		if(Food == 3){
			comida1.SetActive (true);
			comida2.SetActive (true);
			comida3.SetActive (true);

		}else if(Food == 2){
			comida1.SetActive (false);
			comida2.SetActive (true);
			comida3.SetActive (true);

		}else if(Food == 1){
			comida1.SetActive (false);
			comida2.SetActive (false);
			comida3.SetActive (true);

		}else if (Food == 0){
			print ("Restar una Vida");
			comida1.SetActive (false);
			comida2.SetActive (false);
			comida3.SetActive (false);
			tiempo += Time.deltaTime;
			if (tiempo > 30){
				Health = 2;
			}
			if (tiempo > 60){
				Health = 1;
			}
			if (tiempo > 90){
				Health = 0;
			}

		}
       
    }
    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
	public void Vidas(){
		if(Health == 3){
			Vida1.SetActive (true);
			Vida2.SetActive (true);
			Vida3.SetActive (true);

		}else if(Health == 2){
			Vida1.SetActive (false);
			Vida2.SetActive (true);
			Vida3.SetActive (true);

		}else if(Health == 1){
			Vida1.SetActive (false);
			Vida2.SetActive (false);
			Vida3.SetActive (true);

		}else if (Health == 0){
			print ("Se murio");
			Vida1.SetActive (false);
			Vida2.SetActive (false);
			Vida3.SetActive (false);
		}
	}
	public void Comida(){
		if(Food == 3){
			comida1.SetActive (true);
			comida2.SetActive (true);
			comida3.SetActive (true);

		}else if(Food == 2){
			comida1.SetActive (false);
			comida2.SetActive (true);
			comida3.SetActive (true);

		}else if(Food == 1){
			comida1.SetActive (false);
			comida2.SetActive (false);
			comida3.SetActive (true);

		}else if (Food == 0){
			print ("Restar una Vida");
			comida1.SetActive (false);
			comida2.SetActive (false);
			comida3.SetActive (false);
			tiempo += Time.deltaTime;
			if (tiempo > 30){
				Health = 2;
			}
			if (tiempo > 60){
				Health = 1;
			}
			if (tiempo > 90){
				Health = 0;
			}

		}


}
	public void RestarComida(){
		if(Time.time > 30){
			//PlayerPrefs.SetInt ("Food" , Food--);
			//PlayerPrefs.GetInt ("Food");
			Subtract();
			if(Input.GetMouseButton(0)){
				print ("Comida: " + PlayerPrefs.GetInt ("Food"));

		}
		if(Time.time > 60){

				Subtract ();
			if(Input.GetMouseButton(0)){
				print ("Comida: " + PlayerPrefs.GetInt ("Food") );

		}
		if(Time.time > 90){
					Subtract ();
			if(Input.GetMouseButton(0)){
			print ("Comida: " + PlayerPrefs.GetInt ("Food") );
					
			}
		}

	}

}
	}

	public void Subtract (){
		Food -= 1;
	}
	public void prueba(){

	}
}