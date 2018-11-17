using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPlane : MonoBehaviour {

    MeshRenderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lavaTrigger") rend.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "lavaTrigger") rend.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "lavaTrigger") rend.enabled = true;
    }
}
