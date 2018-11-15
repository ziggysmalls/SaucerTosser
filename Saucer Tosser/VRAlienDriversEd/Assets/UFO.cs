using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {


    Rigidbody rb;

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

        powered = false;
    }
}
