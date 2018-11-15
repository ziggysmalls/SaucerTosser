using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {


    Rigidbody rb;
    public float timer = 0;

    bool powered = true;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!powered)
        {
            rb.useGravity = true;
            GetComponent<EnemyPath>().enabled = false;
        }

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            powered = true;
            GetComponent<EnemyPath>().enabled = true;
            rb.useGravity = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Warpgate")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "UFORigidbody")
        {
            powered = false;
            
        }
        timer = 1;
        powered = false;

        
    }
}
