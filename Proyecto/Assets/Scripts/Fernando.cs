using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Fernando: MonoBehaviour
{

    Rigidbody2D rb2d;
    SpriteRenderer sr;
    public Camera cam;
    private float speed = 5f;
    private float jumpForce = 350f;
    private bool facingRight = true;
    Animator anim;




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
        //float move = CrossPlatformInputManager.GetAxis("Horizontal");}
        float move = Input.GetAxis("Horizontal");
        if (move != 0)
        {
            rb2d.transform.Translate(new Vector3(1, 0, 0) * move * speed * Time.deltaTime);
            cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            facingRight = move > 0;
        }

        anim.SetFloat("Speed", Mathf.Abs(move));
        sr.flipX = !facingRight;

       //if (CrossPlatformInputManager.GetButtonDown("Jump"))
       if(Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(Vector2.up * jumpForce);
        }

        

    }
}
