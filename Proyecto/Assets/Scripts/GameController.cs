// Universidad del Valle de Guatemala
// Programacion de plataformas moviles y juegos
// File: GameController.cs
// Controlador del juego 
// Autores: Fernando Hengstenberg 17699 y David Valenzuela 171001


// Librerias necesarias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    // Atrbutos de la clase
    public bool gameOver;
    public float score;
    public static GameController instance;

    // Use this for initialization
    void Start()
    {

        gameOver = false;
        score = 0;
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {

    }
}