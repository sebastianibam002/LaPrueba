using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class warp : MonoBehaviour
{


    public GameObject target;

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player") {

            print("Hey");
			SceneManager.LoadScene ("Cartas");
        }
    }
}

