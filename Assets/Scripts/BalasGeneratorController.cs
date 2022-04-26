using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasGeneratorController : MonoBehaviour {
	public GameObject enemyPrefab;
	public float generatorTimer = 10f;
	public float time;


	// Use this for initialization
	void Start () {
		Debug.Log (generatorTimer);


	}

	// Update is called once per frame
	void Update () {

	}

	void CreateEnemy(){
		Instantiate(enemyPrefab, transform.position, Quaternion.identity);

	}

	public void StartGenerator(){


		InvokeRepeating ("CreateEnemy", time, generatorTimer);
	}

	public void CancelGenerator(bool clean = false){

		CancelInvoke ("CreateEnemy");
		if (clean) {
			Object[] allEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (GameObject enemy in allEnemies) {
				Destroy (enemy);
			}
		}
	}

}
