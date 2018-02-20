using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character: MonoBehaviour {

	Rigidbody2D rb2d;
	SpriteRenderer sr;
	public Camera cam;
	private float speed = 5f;
	private float jumpForce = 250f;
	private bool facingRight = true;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
	}

	// Update is called once per frame
	void Update () {

	}

	public void jump(){
		rb2d.AddForce(Vector2.up*jumpForce);
	}

	public void moveLeft(){
		rb2d.transform.Translate(new Vector3(1, 0, 0) * -5 * speed * Time.deltaTime);
		cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
		facingRight = false;
	}

	public void moveRigth(){
		rb2d.transform.Translate(new Vector3(1, 0, 0) * 5 * speed * Time.deltaTime);
		cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
		facingRight = true;
	}

	public void flip(){
		sr.flipX = !facingRight;
	}
}
