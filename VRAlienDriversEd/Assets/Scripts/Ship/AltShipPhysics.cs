using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltShipPhysics : MonoBehaviour {

	public Transform joystick;
	public GameObject turnHandle;
    public Transform elevator;
	public float maxSpeed;
    public float turnSpeed;
	Transform yTransform;

	float throttle;
	float yawDirection;
    float liftDirection;

	// Use this for initialization
	void Start () {
		yTransform = transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateThrottle();
        UpdateTurnLever();
        UpdateElevator();
		UpdateShipPosition ();
	}

	float Map(float val, float start1, float start2, float end1, float end2)
	{
		float prop = (val - start1) / (end1 - start1);
		prop = prop * (end2 - start2) + start2;
		return prop;
	}

    void UpdateThrottle()
    {
        float rot = joystick.localRotation.z;
        HingeJoint hinge = joystick.GetComponent<HingeJoint>();
        float min = hinge.limits.min;
        float max = hinge.limits.max;
        throttle = Map(rot, min, max, 0f, 1f);
        if (throttle < 0f)
        {
            throttle = 0;
        }
    }

    void UpdateTurnLever()
    {
		float ang = turnHandle.transform.localRotation.eulerAngles.y;
        float deadZone = 5;

        float midAng = 101;
        float maxAng = 112;
        float minAng = 80;

        if (ang > 101 + deadZone/2) //Turn Left
        {
            yawDirection = (ang - midAng) / (midAng - maxAng);
        }
        else

        if (ang < 101 - deadZone/2) //Turn Right
        {
            yawDirection = (ang - midAng) / (midAng - maxAng);
        } else yawDirection = 0;
        Debug.Log(yawDirection);
    }

    void UpdateElevator()
    {
        
        float rot = elevator.localRotation.eulerAngles.z;
        /*HingeJoint hinge = elevator.GetComponent<HingeJoint>();
        float min = 290 - hinge.limits.min;
        float max = 290 + hinge.limits.max;
        liftDirection = Map(rot, min, max, 0f,1f);
        if (liftDirection < 0.3f && liftDirection > -0.3f)
        {
            //liftDirection = 0;
        }
        Debug.Log("Rotation: " + rot);
        Debug.Log("Lift Direction: " + liftDirection);
        Debug.Log("Min: " + min);
        Debug.Log("Max: " + max);
        */
        if (rot > 300)
        {
            liftDirection = -0.1f;
        }
        else if (rot < 280)
        {
            liftDirection = 0.1f;
        }
        else liftDirection = 0;
    }

    void UpdateShipPosition() {
		Vector3 pos = transform.position;
		pos.z += -throttle * maxSpeed * Time.deltaTime;
        transform.position += -transform.right * -throttle * maxSpeed; //Apply throttle
        transform.position += transform.up * liftDirection; //Apply elevator


        Vector3 rot = transform.eulerAngles;
        rot.y += yawDirection;// * turnSpeed * Time.deltaTime;
        yTransform.Rotate(transform.up,yawDirection,Space.Self);
	}
}
