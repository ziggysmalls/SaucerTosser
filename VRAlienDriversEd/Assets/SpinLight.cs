using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinLight : MonoBehaviour {

    public float speed = 1;

    public SpaceGate spaceGate;
    Light light;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * Time.deltaTime * speed);

        if (spaceGate.isTriggered)
        {
            light.color = Color.green;
        }
	}
}
