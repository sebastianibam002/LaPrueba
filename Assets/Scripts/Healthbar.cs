using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

	float hp, maxHp = 100f;
	public Image health;
	public Image health2;
	public Image health3;




	// Use this for initialization
	void Start () {

		hp = maxHp;

		

	}

	public void TakeDamageh1(float amount){
		hp = Mathf.Clamp (hp - amount, 0f, maxHp);
		health.transform.localScale = new Vector2 (hp / maxHp, 1);

	
	}
	public void TakeDamageh2(float amount){
		hp = Mathf.Clamp (hp - amount, 0f, maxHp);
		health.transform.localScale = new Vector2 (hp / maxHp, 1);

}
	public void TakeDamageh3(float amount){
		hp = Mathf.Clamp (hp - amount, 0f, maxHp);
		health.transform.localScale = new Vector2 (hp / maxHp, 1);

}
}