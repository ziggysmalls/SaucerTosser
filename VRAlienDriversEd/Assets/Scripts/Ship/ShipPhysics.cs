﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPhysics : MonoBehaviour 
{
    
    public Vector3 linearForce = new Vector3(100.0f, 100.0f, 100.0f);

    public Vector3 angularForce = new Vector3(100.0f, 100.0f, 100.0f);

    [Range(0.0f, 1.0f)]
    public float reverseMultiplier = 1.0f;

    public float forceMultiplier = 100.0f;

    public Rigidbody Rigidbody { get { return rbody; } }

    private Vector3 appliedLinearForce = Vector3.zero;
    private Vector3 appliedAngularForce = Vector3.zero;

    private Rigidbody rbody;

    // Keep a reference to the ship this is attached to just in case.
    private Ship ship;

    // Use this for initialization
    void Awake()
    {
        rbody = GetComponent<Rigidbody>();
        if (rbody == null)
        {
            Debug.LogWarning(name + ": ShipPhysics has no rigidbody.");
        }

        ship = GetComponent<Ship>();
    }

    void FixedUpdate()
    {
        if (rbody != null)
        {
            rbody.AddRelativeForce(appliedLinearForce * forceMultiplier, ForceMode.Force);
            rbody.AddRelativeTorque(appliedAngularForce * forceMultiplier, ForceMode.Force);
        }
    }

    public void SetPhysicsInput(Vector3 linearInput, Vector3 angularInput)
    {
        appliedLinearForce = MultiplyByComponent(linearInput, linearForce);
        appliedAngularForce = MultiplyByComponent(angularInput, angularForce);
    }

    private Vector3 MultiplyByComponent(Vector3 a, Vector3 b)
    {
        Vector3 ret;

        ret.x = a.x * b.x;
        ret.y = a.y * b.y;
        ret.z = a.z * b.z;

        return ret;
    }
}