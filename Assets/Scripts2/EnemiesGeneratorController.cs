using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGeneratorController : MonoBehaviour {
	public GameObject enemyPrefab;
	public float generatorTimer = 1.75f;



	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateEnemie(){
		Instantiate (enemyPrefab, transform.position, Quaternion.identity);
	}
	public void StartGenerations(){
		InvokeRepeating ("CreateEnemie", 0f, generatorTimer);
	}
	public void CancelGenerations (bool cleantwo = false)
	{
		CancelInvoke ("CreateEnemie");
		if (cleantwo) {
			Object[] allEnemiesTwo = GameObject.FindGameObjectsWithTag ("enemie");
			foreach (GameObject enemie in allEnemiesTwo) {
				Destroy (enemie);
			}
			
		}
	}
}
