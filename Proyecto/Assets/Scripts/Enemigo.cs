using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector3 direction;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        sr = GetComponent<SpriteRenderer>();
        direction = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        rb.transform.Translate(direction * 2 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
       direction.x = direction.x * -1;
    }
}
