using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHazard : MonoBehaviour {

    public float speed;
    public float jumpLength;
    float timer;

    Rigidbody rb;


	// Use this for initialization
	void Start () {
		timer = jumpLength;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += (transform.up * speed * Time.deltaTime);

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            speed = -speed;
            timer = jumpLength;
        }
	}
}
