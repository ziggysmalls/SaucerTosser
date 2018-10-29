using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour {

    public float speed = 1;
    public GameObject UFO;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.GetComponent<Rigidbody>() != null)
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            //rb.AddForce(new Vector3(0, speed, 0));
            col.transform.position = Vector3.MoveTowards(col.transform.position, UFO.transform.position, speed);
            rb.useGravity = false;
            Debug.Log(col);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }
}
