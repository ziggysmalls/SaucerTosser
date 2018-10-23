﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class LagCamera : MonoBehaviour
{    
    [Tooltip("Speed at which the camera rotates. (Camera uses Slerp for rotation.)")]
    public float rotateSpeed = 90.0f;

    [Tooltip("If the parented object is using FixedUpdate for movement, check this box for smoother movement.")]
    public bool usedFixedUpdate = true;

    private Transform target;
    private Vector3 startOffset;

    private void Start()
    {
        target = transform.parent;

        
        startOffset = transform.localPosition;
        transform.SetParent(null);
    }

    private void Update()
    {
        if (!usedFixedUpdate)
            UpdateCamera();
    }

    private void FixedUpdate()
    {
        if (usedFixedUpdate)
            UpdateCamera();
    }

    private void UpdateCamera()
    {
        if (target != null)
        {
            transform.position = target.TransformPoint(startOffset);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, rotateSpeed * Time.deltaTime);
        }
    }
}

