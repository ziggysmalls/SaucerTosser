using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class ShipInput : MonoBehaviour
{
    
    
	public Transform joystick;
	
    public HingeJoint turnHandle;


    
    [Range(-1, 1)]
    public float pitch;
    [Range(-1, 1)]
    public float yaw;
    [Range(-1, 1)]
    public float roll;
    [Range(-1, 1)]
    public float strafe;
    [Range(0, 1)]
    public float throttle;

    // How quickly the throttle reacts to input.
    private const float THROTTLE_SPEED = 0.5f;

    // Keep a reference to the ship this is attached to just in case.
    private Ship ship;

    void Awake()
    {
        ship = GetComponent<Ship>();

    }
   public void Update()
    {
		UpdateJoystickThrottle ();
		UpdateJoystickYaw ();
    }

    
   

    void UpdateMouseWheelThrottle()
    {
        throttle += Input.GetAxis("Mouse ScrollWheel");
        throttle = Mathf.Clamp(throttle, 0.0f, 1.0f);
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
        if (throttle < 0f)
        {
            throttle = 0;
        }
    }

	void UpdateJoystickYaw()
	{
        float ang = turnHandle.angle;
        if (ang > 20)
        {
            yaw = -1;
        }
        else

        if (ang < -20)
        {
            yaw = 1;
        }
        else yaw = 0;
    }
}