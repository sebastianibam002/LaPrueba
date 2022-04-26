using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControlador : MonoBehaviour {

	float hp, maxHp = 100f;
	public Image Time;

	// Use this for initialization
	void Start () {
		hp = maxHp;



	}

	public void Taketime(float amount){
		hp = Mathf.Clamp (hp - amount, 0f, maxHp);
		Time.transform.localScale = new Vector2 (hp / maxHp, 1);


	}
}

	
	
