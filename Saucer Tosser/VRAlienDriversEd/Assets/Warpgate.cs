using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportGate : MonoBehaviour {

    public GameObject targetGate;
    public GameObject npc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (targetGate != null)
        {
            UFO ufo = Instantiate(npc).GetComponent<UFO>();
            ufo.spawnGate = gameObject.name;
            ufo.targetGate = targetGate;

        }
	}
}
