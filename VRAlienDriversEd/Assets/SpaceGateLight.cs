using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGateLight : MonoBehaviour {

    public SpaceGate spaceGate;
    MeshRenderer rend;
    public Material triggerMat;

	// Use this for initialization
	void Start () {
        rend = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (spaceGate.isTriggered)
        {
            rend.material = triggerMat;
        }
	}
}
