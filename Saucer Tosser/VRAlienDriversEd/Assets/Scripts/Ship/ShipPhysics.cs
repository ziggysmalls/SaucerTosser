using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPhysics : MonoBehaviour {

	public Transform joystick;
	public GameObject turnHandle;
    public Transform elevator;
	public float maxSpeed;
    public float turnSpeed;
	Transform yTransform;

	float throttle;
	float yawDirection;
    float liftDirection;

    public float collisionRange;
    public float liftSpeed = 20;

    Vector3 totalVec = new Vector3(0, 0, 0);

    Rigidbody rb;

	// Use this for initialization
	void Start () {
		yTransform = transform;
        rb = GetComponent<Rigidbody>();
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
    }

    void UpdateElevator()
    {
        
        float rot = elevator.localRotation.eulerAngles.z;

        if (rot > 283)
        {
            liftDirection = -0.1f;
        }
        else if (rot < 270)
        {
            liftDirection = 0.1f;
        }
        else liftDirection = 0;
    }

    void UpdateShipPosition() {

        Vector3 pos = transform.position;
        Vector3 throttleVec = transform.right * throttle * maxSpeed; //Apply throttle
        Vector3 elevatorVec = transform.up * liftDirection; //Apply elevator
        totalVec = throttleVec + elevatorVec;

        Vector3 rot = transform.eulerAngles;
        rot.y += yawDirection;
        //yTransform.Rotate(transform.up,yawDirection*turnSpeed,Space.Self);
        //transform.position += totalVec;

        //rb.AddForce(elevatorVec*steadySpeed) ;//totalVec;
       

        float xr = Mathf.Lerp(transform.rotation.x,0, .00001f);
        float zr = Mathf.Lerp(transform.rotation.y, 0, .00001f);
        //transform.rotation = Quaternion.Euler(xr, transform.rotation.y, zr);
        //rb.rotation = (Quaternion.Euler(0, rot.y, 0));
        //rb.velocity = (elevatorVec * liftSpeed)+throttleVec;
        rb.velocity = ((elevatorVec * liftSpeed) + throttleVec);
        rb.MoveRotation(Quaternion.Euler(0, rot.y, 0));


    }

    public void stopShip()
    {
        transform.position -= totalVec;
    }
}
