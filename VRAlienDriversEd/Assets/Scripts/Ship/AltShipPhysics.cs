using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltShipPhysics : MonoBehaviour {

	public Transform joystick;
	public float maxSpeed;

	float throttle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateJoystickThrottle ();
		UpdateShipPosition ();
	}

	float Map(float val, float start1, float start2, float end1, float end2)
	{
		float prop = (val - start1) / (end1 - start1);
		prop = prop * (end2 - start2) + start2;
		return prop;
	}

	void UpdateJoystickThrottle()
	{
		float rot = joystick.rotation.z;
		HingeJoint hinge = joystick.GetComponent<HingeJoint> ();
		float min = hinge.limits.min;
		float max = hinge.limits.max;
		throttle = Map (rot, min, max, 0f, 1f);
		if (throttle < .1) {
			throttle = 0;
		}
	}

	void UpdateShipPosition() {
		Vector3 pos = transform.position;
		pos.z += -throttle * maxSpeed;
		transform.position = new Vector3 (pos.x, pos.y, pos.z);
	}
}
