using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControlJuego : MonoBehaviour
{
    public string JuegoUno = "JuegoUno";
    public string JuegoDos = "JuegoDos";
    public string JuegoThree = "JuegoTres";
    public string JuegoFour = "JuegoCuatro";

    public void GetInput(string hey)


    {
        Debug.Log("Level selected " + hey);
        if (hey == JuegoUno)
        {
            SceneManager.LoadScene("Juego");
        }
        else if (hey == JuegoDos)
        {
            SceneManager.LoadScene("JuegoTwo");
        }
        else if (hey == JuegoThree)
        {
            SceneManager.LoadScene("JuegoThree");
        }
        else if (hey == JuegoFour)
        {
            SceneManager.LoadScene("RandomMonwy");
        }

    }
}