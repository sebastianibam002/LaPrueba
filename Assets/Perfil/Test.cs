using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {



	public string[] items;
	private string nombre;
	private int beginning;
	//private int end;
	//private int total;
	private string lenght;
	private bool appears = false;
	private int numero;

	void Awake(){
	
		//PlayerPrefs.SetString ("username", "Juanito Alimaña");
		//print (PlayerPrefs.GetString ("username"));
	}
	IEnumerator Start() {
		WWW itemsData = new WWW("https://sebastianibarramedez.000webhostapp.com/CargarTabla3.php");
		yield return itemsData;
		string itemsDataString = itemsData.text;
		print(itemsDataString);
		items = itemsDataString.Split(';');
		print(GetDataValue(items[2],"Nombre:"));




		if (itemsDataString.Contains (PlayerPrefs.GetString ("username"))) {
			print ("Your name apeers here");
			nombre = PlayerPrefs.GetString ("username");
			beginning = itemsDataString.IndexOf (nombre);
			print ("beginning: " + beginning);

			lenght = itemsDataString.Substring (beginning - 10, 1);
			print ("LEnght: " + lenght);
			numero = int.Parse(lenght);
			print ("numero: " +  numero);




			print ("ID: " + lenght);
			appears = true;
		}

		if (!appears) {
		
			print ("You dont appear");
		}
	}
	string GetDataValue(string data, string index) {

		string value = data.Substring(data.IndexOf(index) + index.Length);
		if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
		return value;



	}
}
	
