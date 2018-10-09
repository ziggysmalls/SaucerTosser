using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            AltShipPhysics ship = player.GetComponent<AltShipPhysics>();
            ship.stopShip();
            Debug.Log("AHHHHHHHH");
        }
    }
}
