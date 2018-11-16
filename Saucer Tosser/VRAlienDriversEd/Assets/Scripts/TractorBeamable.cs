using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeamable : MonoBehaviour {

    Rigidbody rb;
    bool isCaptured = false;
    GameObject triggerZone;
    public ItemAlert itemAlert;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        gameObject.layer = 10;
        gameObject.tag = "TractorBeamable";
        triggerZone = GameObject.FindGameObjectWithTag("TractorBeamTrigger");
	}
	
	// Update is called once per frame
	void Update () {
		if (isCaptured)
        {
            rb.useGravity = false;
            float speed = 3;
            transform.position = Vector3.MoveTowards(transform.position, triggerZone.transform.position, speed * Time.deltaTime);
            
        }
        else
        {
            rb.useGravity = true;
            rb.velocity = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "TractorBeam")
        {
            isCaptured = true;
        }
        if (collision.gameObject == triggerZone)
        {
            transform.parent = GameObject.FindGameObjectWithTag("UFO").transform;
            transform.gameObject.layer = 9;
            transform.localScale = transform.localScale / 25;
            transform.position = GameObject.FindGameObjectWithTag("Trunk").transform.position;
            itemAlert.ShowAlert();
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "TractorBeam")
        {
            isCaptured = false;
            rb.velocity = Vector3.zero;
        }
    }

    public void ParentToUFO()
    {
        transform.parent = GameObject.FindGameObjectWithTag("UFO").transform;
    }
}
