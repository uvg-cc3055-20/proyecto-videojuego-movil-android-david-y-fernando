// Universidad del Valle de Guatemala
// Programacion de plataformas moviles y juegos
// File: Fernano.cs
// Script para controlar al personaje 
// Autores: Fernando Hengstenberg 17699 y David Valenzuela 171001

// Librerias necesarias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Fernando : MonoBehaviour
{
    // RigidBody del Personaje
    Rigidbody2D rb2d;
    // SpriteRenderer del personaje
    SpriteRenderer sr;
    // Camara del nivel
    public Camera cam;
    // Velocidad con la que avanza el personaje
    private float speed = 5f;
    // Potencias del salto
    private float jumpForce = 350f;

    // Hacia donde apunta el personaje
    private bool facingRight = true;
    Animator anim;
    public Text score;

    // Parte de abajo del personaje
    public GameObject feet;
    // Layer del mundo
    public LayerMask layerMask;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        sr = GetComponent<SpriteRenderer>();
        cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // SI el personaje esta vivo
        if (GameController.instance.gameOver == false)
        {
            // Obtenemos la direccion del movimiento

          float move = CrossPlatformInputManager.GetAxis("Horizontal");
          //float move = Input.GetAxis("Horizontal");
            if (move != 0)
            {
                // Agregamos la fuerza al rigid body, movemos la camara y miramos hacia donde aounta el personaje
                rb2d.transform.Translate(new Vector3(1, 0, 0) * move * speed * Time.deltaTime);
                cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
                facingRight = move > 0;
            }

            // Agregamos la animacion y cambiamos hacia donde apunta el personaje
            anim.SetFloat("Speed", Mathf.Abs(move));
            sr.flipX = !facingRight;

            // Saltar
            //if (Input.GetButtonDown("Jump"))
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                // Verifiamos que toque el suelo y saltamos
                RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.5f, layerMask);
                Debug.Log(raycast.collider);
                if (raycast.collider != null)
                {
                    rb2d.AddForce(Vector2.up * jumpForce);
                }
            }


        }

        // Sumamos el puntaje
        GameController.instance.score = GameController.instance.score + 1 * Time.deltaTime;
        score.text = GameController.instance.score.ToString();
        
        // Si cayo del nivel
        if (rb2d.transform.position.y < -8)
        {
            // Reiniciamos el nivel y la informacion del personaje
            string level = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(level);
            GameController.instance.gameOver = true;
            anim.SetBool("dead", GameController.instance.gameOver);
            GameController.instance.score = 0;
        }

    }

    // Al colisionar
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si es un enemigo
        if (collision.gameObject.tag == "Enemy")
        {
            // LO botamos del nivel y iniciamos las animaciones
            GameController.instance.gameOver = true;
            anim.SetBool("dead", GameController.instance.gameOver);
            rb2d.AddForce(Vector2.up * 155f);
            Destroy(rb2d.GetComponent<PolygonCollider2D>());
        }
    }

    // Si llego a un trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Al llegar al portal cambiamos al siguiente nivel
        if (collision.tag == "portal")
        {
            // Dependiendo del nivel pasamos al siguiente
            if (SceneManager.GetActiveScene().name == "Level 1")
            {
                SceneManager.LoadScene("Level 2");
            }
            else if (SceneManager.GetActiveScene().name == "Level 2")
            {
                SceneManager.LoadScene("Level 3");
            }
            else if (SceneManager.GetActiveScene().name == "Level 3")
            {
                SceneManager.LoadScene("Level 4");
            }
            else if (SceneManager.GetActiveScene().name == "Level 4")
            {
                SceneManager.LoadScene("Winer");
            }
        }

        /// Si el score es mejor lo guardamos
        if (GameController.instance.score < PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", GameController.instance.score);
        }
    }

    public void onClick()
    {
        SceneManager.LoadScene("1");
    }

}
