using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class controlador : MonoBehaviour {
	public int numero;

	public void RandomScene(){
	
		numero = Random.Range (0, 4);
		RestartGame ();
		Debug.Log (numero);

	}
	public void RestartGame(){

        if (numero == 0) {
            SceneManager.LoadScene("Juego");

        } else if (numero == 1) {
            SceneManager.LoadScene("JuegoTwo");


        } else if (numero == 2) {
            SceneManager.LoadScene("JuegoThree");

        } else if (numero == 3) {
            SceneManager.LoadScene("RandomMonwy");
        }

	}

}
