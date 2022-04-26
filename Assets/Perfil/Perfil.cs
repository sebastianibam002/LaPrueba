using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Perfil : MonoBehaviour {

	public Text edads;
	public string hombres = "men";
	public string mujeres = "woman";
	public string quintoa = "5a";
	public string quintob = "5b";
	public string inputUserName;
	public int inputPassword;
	public string inputEmail;

	public GameObject subir2;

	private string[] items;


	string CreateUserURL = "http://sebastianibarramedez.000webhostapp.com/InsertarTabla.php";
	//string informurl = "https://sebastianibarramedez.000webhostapp.com/InsertarTabla2.php";


	// Use this for initialization
	void Awake () {

		subir2.SetActive (true);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetInput(string nombre){
		if(nombre != null){

			PlayerPrefs.SetString ("username",nombre);
			PlayerPrefs.GetString ("username");

			print ("su nombre es: " + PlayerPrefs.GetString ("username"));

		}
	
	}

	public void Age(float edaded){



		int edadedint = Mathf.FloorToInt(edaded);
			
		if(edaded != 0){


			PlayerPrefs.SetInt ("Age", edadedint);
			PlayerPrefs.GetInt ("Age");

			print ("su edad es: " + PlayerPrefs.GetInt ("Age"));

			edads.text = "" + PlayerPrefs.GetInt ("Age").ToString ();
		}

	
	}

	public void toggleh(bool hombre){
	//toggleh = toggle hombre
		if (hombre == true) {
			PlayerPrefs.SetString ("sexo",hombres);
			PlayerPrefs.GetString ("sexo");

			print (PlayerPrefs.GetString ("sexo"));
		} else {
			print ("no es hombre");
		}
	
	
	}
	public void togglem(bool mujer){
		//togglem = toggle mujer
		if (mujer == true) {
			PlayerPrefs.SetString ("sexo",mujeres);
			PlayerPrefs.GetString ("sexo");

			print (PlayerPrefs.GetString ("sexo"));

		} else {
			print ("no es mujer");
		}


	}
	public void toggle5a(bool a){
		
		if (a == true) {
			PlayerPrefs.SetString ("curso",quintoa);
			PlayerPrefs.GetString ("curso");

			print (PlayerPrefs.GetString ("curso"));


		} else {
			print ("no es de 5a");
		}


	}
	public void toggle5b(bool b){
		//toggleh = toggle hombre
		if (b == true) {
			PlayerPrefs.SetString ("curso",quintob);
			PlayerPrefs.GetString ("curso");

			print (PlayerPrefs.GetString ("curso"));

		} else {
			print ("no es 5b");
		}


	}

	public void subir(){
	
		print ("nombre: "+PlayerPrefs.GetString ("username"));
		print ("edad: "+PlayerPrefs.GetFloat ("Age"));
		print ("sexo: "+PlayerPrefs.GetString ("sexo"));
		print ("curso: "+PlayerPrefs.GetString ("curso"));

		CreateUser (PlayerPrefs.GetString ("username"),PlayerPrefs.GetInt ("Age"),PlayerPrefs.GetString ("sexo"),PlayerPrefs.GetString ("curso") );
		subir2.SetActive (false);

		SceneManager.LoadScene ("Mascota2");
	}
	public void CreateUser(string nombre, int age, string sexo, string curso) {
		WWWForm form = new WWWForm();
		form.AddField("nombrePost",nombre);
		form.AddField("edadPost", age);
		form.AddField("sexoPost", sexo);
		form.AddField("cursoPost", curso);
		WWW www = new WWW(CreateUserURL, form);
	}


}
