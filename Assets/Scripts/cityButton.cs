using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cityButton : MonoBehaviour {

	public void gotoCity(string nombre){
		SceneManager.LoadScene (nombre);

	}
}