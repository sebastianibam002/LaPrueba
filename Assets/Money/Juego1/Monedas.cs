using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour {

	public GameObject CoinPrefab;
	public float generatorTimer = 20.75f;
	private int Money;
	public float Food;


	// Use this for initialization
	void Start () {
		Debug.Log (generatorTimer);
		Money = PlayerPrefs.GetInt ("Money1");
		Food = PlayerPrefs.GetFloat ("Food");


	}

	// Update is called once per frame
	void Update () {




	}

	void CreateCoin(){
		Instantiate(CoinPrefab, transform.position, Quaternion.identity);

	}

	void StartCoinGenerator(){
		InvokeRepeating ("CreateCoin", 0f, generatorTimer);

	}
	void CancelCoinGnerator(){
		CancelInvoke ("CreateCoin");
	}

	public void IncreaseMoney(){
		Money++;
		PlayerPrefs.SetInt ("Money1",Money);
		PlayerPrefs.GetInt ("Money1");
		print ("Money" + PlayerPrefs.GetInt ("Money1")
		);

	}
	public void DecreaseMoney(int total){
		Money = (Money)- total;
		PlayerPrefs.SetInt ("Money1",Money);
		PlayerPrefs.GetInt ("Money1");
			
	}


	public void Increasethis(int howmuch){
		Money = howmuch + Money;
		PlayerPrefs.SetInt ("Money1",Money);
		PlayerPrefs.GetInt ("Money1");
		print ("Money" + PlayerPrefs.GetInt ("Money1")
		);
	
	}

	/// <summary>
	/// //COMIDA
	/// </summary>


		}
	


