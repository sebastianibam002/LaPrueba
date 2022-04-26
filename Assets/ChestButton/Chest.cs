using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Chest : MonoBehaviour {

	private Button chestButton;
	private string notification;
	public Text chestTimer;
	private ulong LastChestOpen;
	public float msToWait = 5000.0f;
	//Para incrementar la variabl
	public GameObject Money;
	public GameObject Notificaciones;
	private int HowMuch;




	private void Start(){
		

		chestButton = GetComponent<Button> ();
		LastChestOpen = ulong.Parse(PlayerPrefs.GetString ("LastChestOpen"));



		if (!IsChestReady ())
			chestButton.interactable = false;


		

	}


	private void Update(){
	
		if (!chestButton.IsInteractable()) {
		
			if(IsChestReady()){
				chestButton.interactable = true;
				chestTimer.text = "Ready";
				Money.SendMessage ("Increasethis", 20);
				notification = "Ganaste: " + 20.ToString ();
				Notificaciones.SendMessage ("TextThis", notification);
				return; 

			}
		//Set the Timer
			ulong diff = (ulong)DateTime.Now.Ticks - LastChestOpen;	
			ulong m = diff / TimeSpan.TicksPerMillisecond;
			float secondsLeft = (float)(msToWait - m) / 1000.0f;

			string r = "";
			//Hours
			r += ((int)secondsLeft /3600).ToString() + "h ";

			secondsLeft -= ((int)secondsLeft / 3600) * 3600;
			//Minutes

			r += ((int)secondsLeft / 60).ToString ("00") + "m ";

			//Senconds

			r += (secondsLeft % 60).ToString ("00") + "s ";;

			chestTimer.text = r;

				
		
		}
	}

	public void ChestClick(){
	


		LastChestOpen = (ulong)DateTime.Now.Ticks;
		PlayerPrefs.SetString ("LastChestOpen", DateTime.Now.Ticks.ToString());
		chestButton.interactable = false;


	
	}

	private bool IsChestReady(){

		ulong diff = (ulong)DateTime.Now.Ticks - LastChestOpen;	
		ulong m = diff / TimeSpan.TicksPerMillisecond;
		float secondsLeft = (float)(msToWait - m) / 1000.0f;

		if (secondsLeft < 0) 
		{
			chestTimer.text = "Ready";
			return true;

		}
		return false;
	
	}

	public void reward(int howmuch)
	{
		HowMuch = howmuch;
		print (HowMuch);


	}
}
