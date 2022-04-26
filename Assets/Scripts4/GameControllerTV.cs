using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerTV : MonoBehaviour {

    public GameObject TestV;


    public void GetInputt(string guess) {
        Debug.Log("HI " + guess);
        if (guess != null) {
            TestV.SendMessage ("Fine");
            PlayerPrefs.SetString("nombre", guess );
            PlayerPrefs.GetString("nombre");
        }
    }

}