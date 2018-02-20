// Universidad del Valle de Guatemala
// Programacion de plataformas moviles y juegos
// File: ButtonChange.cs
// Acciones al presionar el boton para inciar el juego
// Autores: Fernando Hengstenberg 17699 y David Valenzuela 171001

// Importamos clases necesarias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonPlay : MonoBehaviour
{

    // Funcion a ejecutar al presionar el boton
    public void onClick()
    {
        // Cargamos la escena del juego
        SceneManager.LoadScene("Level 1");
    }
}
