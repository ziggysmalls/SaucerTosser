using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacegateLight : MonoBehaviour {

    public Light light;
    public Material triggerMat;
    MeshRenderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Trigger()
    {
        rend.material = triggerMat;
    }
}
