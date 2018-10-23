using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatewayTrigger : MonoBehaviour {

    public SpaceGate spaceGate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        spaceGate.isTriggered = true;
    }
}
