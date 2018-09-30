using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltShipPhysics : MonoBehaviour {

	public Transform joystick;
    public Transform turnHandle;
	public float maxSpeed;
    public float turnSpeed;
    public float yawDirection;
	Transform yTransform;

	float throttle;

	// Use this for initialization
	void Start () {
		yTransform = transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateJoystickThrottle ();
        UpdateJoystickYaw();
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
		if (throttle < 0f) {
			throttle = 0;
		}
	}

    void UpdateJoystickYaw()
    {
        float ang = turnHandle.rotation.y;
        if (ang > 20)
        {
            yawDirection = -1;
        }
        else

        if (ang < -20)
        {
            yawDirection = 1;
        } else yawDirection = 0;
        Debug.Log(turnHandle.rotation.x);
    }

    void UpdateShipPosition() {
		Vector3 pos = transform.position;
		pos.z += -throttle * maxSpeed * Time.deltaTime;
        transform.position += -transform.right * -throttle * maxSpeed; //new Vector3 (pos.x, pos.y, pos.z);

        Vector3 rot = transform.eulerAngles;
        rot.y += yawDirection;// * turnSpeed * Time.deltaTime;
        yTransform.Rotate(transform.up,yawDirection,Space.Self);
	}
}
