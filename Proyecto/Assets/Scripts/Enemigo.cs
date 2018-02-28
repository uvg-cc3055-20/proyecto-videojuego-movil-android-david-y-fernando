// Universidad del Valle de Guatemala
// Programacion de plataformas moviles y juegos
// File: Enemigo.cs
// Script para controlar al enemigo 
// Autores: Fernando Hengstenberg 17699 y David Valenzuela 171001

//Importar librerias necesarias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    // RigidBody
    private Rigidbody2D rb;

    // Parte de abajo del personaje
    public GameObject side;
    // Layer del mundo
    public LayerMask layerMask;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update() {
        RaycastHit2D raycast = Physics2D.Raycast(side.transform.position, Vector2.right, 0.000001f, layerMask);
        //Si detecta un choque
        if (raycast.collider != null)    
        {
            rb.transform.Rotate(new Vector3(0, 180, 0));
            //side.transform.Rotate(new Vector3(0, 180, 0));
        }
        rb.transform.Translate(new Vector3(1, 0, 0) * 2 * Time.deltaTime);
      
    }

}
