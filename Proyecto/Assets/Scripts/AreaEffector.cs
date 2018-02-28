using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffector : MonoBehaviour {
    public GameObject child;
    public float time;
    public bool active = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time = Time.deltaTime + time;
        if (time >= 2f)
        {
            active = !active;
            child.gameObject.SetActive(active);
            time = 0;
        }

    }
}
