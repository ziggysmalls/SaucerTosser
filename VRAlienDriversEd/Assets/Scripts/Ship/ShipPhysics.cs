using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPhysics : MonoBehaviour 
{
    public float maxSpeed;
    public float turnSpeed;
    float throttle;
    public float yawDirection;
    private Ship ship;

    private void Awake()
    {
        ship = GetComponent<Ship>();
    }
    public void UpdateShipPosition()
    {
        Vector3 pos = transform.position;
        pos.z += -throttle * maxSpeed;
        transform.position += -transform.right * -throttle * maxSpeed; //new Vector3 (pos.x, pos.y, pos.z);

        Vector3 rot = transform.rotation.eulerAngles;
        rot.y += yawDirection * turnSpeed;
        transform.rotation = Quaternion.Euler(rot);
    }
}