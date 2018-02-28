using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool gameOver;
    public int score;
    public static GameController instance;

    //public AudioSource musicPlayer;
    // Use this for initialization
    void Start () {
       // musicPlayer = GetComponent<AudioSource>();
        gameOver = false;
        score = 0;
        instance = this;

    }
	
	// Update is called once per frame
	void Update () {
        //musicPlayer.Play();
		
	}
}
