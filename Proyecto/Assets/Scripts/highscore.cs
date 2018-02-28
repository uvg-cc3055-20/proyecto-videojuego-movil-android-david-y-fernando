// Universidad del Valle de Guatemala
// Programacion de plataformas moviles y juegos
// File: higscore.cs
// Script para controlar al enemigo 
// Autores: Fernando Hengstenberg 17699 y David Valenzuela 171001

// Importamos librerias necesarias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore : MonoBehaviour {

    public Text score;
    
	// Use this for initialization
	void Start () {
        // Cargamos el highscore
        score.text = "HigShcore: " + PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
