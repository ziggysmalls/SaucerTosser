using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class ShipInput : MonoBehaviour
{
    
    public bool useMouseInput = true;
    public bool addRoll = true;
    GameObject accelerator;
    GameObject rotation;
    SteamVR_TrackedObject tObject;
    SteamVR_Controller.Device device;


    [Space]

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
        tObject = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        if (tObject)
        {
            strafe = Input.GetAxis("Horizontal");
            SetStickCommandsUsingMouse();
            UpdateMouseWheelThrottle();
            UpdateTriggerThrottle(device);
        }
        else
        {            
            pitch = Input.GetAxis("Vertical");
            yaw = Input.GetAxis("Horizontal");

            if (addRoll)
                roll = -Input.GetAxis("Horizontal") * 0.5f;

            strafe = 0.0f;
            UpdateTriggerThrottle(device);
        }
    }

    
    void SetStickCommandsUsingMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        pitch = (mousePos.y - (Screen.height * 0.5f)) / (Screen.height* 0.5f);
        yaw = (mousePos.x - (Screen.width * 0.5f)) / (Screen.width * 0.5f);

        // Make sure the values don't exceed limits.
        pitch = -Mathf.Clamp(pitch, -1.0f, 1.0f);
        yaw = Mathf.Clamp(yaw, -1.0f, 1.0f);
    }

    void UpdateTriggerThrottle(SteamVR_Controller.Device device)
    {
        float target = throttle;
        device = SteamVR_Controller.Input((int)tObject.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            target = 1.0f;
        }
        else
            target = 0.0f;

        throttle = Mathf.MoveTowards(throttle, target, Time.deltaTime * THROTTLE_SPEED);
    }

    void UpdateMouseWheelThrottle()
    {
        throttle += Input.GetAxis("Mouse ScrollWheel");
        throttle = Mathf.Clamp(throttle, 0.0f, 1.0f);
    }
}