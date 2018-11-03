using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {

    public string spawnGate;
    public GameObject targetGate;
    Rigidbody rb;

    bool powered = true;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (powered)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetGate.transform.position, 1);
            transform.position += transform.right * Random.Range(-1, 1) * .01f;
        }
        else
        {
            rb.useGravity = true;
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
    }
}
