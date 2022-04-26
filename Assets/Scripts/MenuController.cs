using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void CambiardeEscena (string nombre){
		print ("Cambiando de escena a: " + nombre);
		SceneManager.LoadScene (nombre);

	}
}
