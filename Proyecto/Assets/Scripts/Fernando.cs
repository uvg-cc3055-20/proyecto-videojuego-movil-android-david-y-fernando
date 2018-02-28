using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Fernando : MonoBehaviour
{

    Rigidbody2D rb2d;
    SpriteRenderer sr;
    public Camera cam;
    private float speed = 5f;
    private float jumpForce = 350f;
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
        if (GameController.instance.gameOver == false)
        {
           float move = CrossPlatformInputManager.GetAxis("Horizontal");
            //float move = Input.GetAxis("Horizontal");
            if (move != 0)
            {
                rb2d.transform.Translate(new Vector3(1, 0, 0) * move * speed * Time.deltaTime);
                cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
                facingRight = move > 0;
            }

            anim.SetFloat("Speed", Mathf.Abs(move));
            sr.flipX = !facingRight;


            //if (Input.GetButtonDown("Jump"))
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                RaycastHit2D raycast = Physics2D.Raycast(feet.transform.position, Vector2.down, 1f, layerMask);
                Debug.Log(raycast.collider);
                if (raycast.collider != null)
                {
                    rb2d.AddForce(Vector2.up * jumpForce);
                }
            }


        }

        GameController.instance.score = GameController.instance.score + 1 * Time.deltaTime;
        score.text = GameController.instance.score.ToString();

        if (rb2d.transform.position.y < -8)
        {
            string level = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(level);
            GameController.instance.gameOver = true;
            anim.SetBool("dead", GameController.instance.gameOver);
            GameController.instance.score = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameController.instance.gameOver = true;
            anim.SetBool("dead", GameController.instance.gameOver);
            rb2d.AddForce(Vector2.up * 155f);
            Destroy(rb2d.GetComponent<PolygonCollider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Al llegar al portal cambiamos al siguiente nivel
        if (collision.tag == "portal")
        {
            // Si esta en el nivel uno, pasamos al 2
            if (SceneManager.GetActiveScene().name == "Level 1")
            {
                SceneManager.LoadScene("Level 2");

                // Si esta en el nivel 2, pasamos al 3
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

        if (GameController.instance.score < PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", GameController.instance.score);
        }
    }

}
