using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;

public class ToggleShipPower : MonoBehaviour {

    VRTK_PhysicsPusher physicsPusher;
    bool shipPowered = false;
    bool buttonDown = false;

    public ShipPhysics shipPhysics;
    public Rigidbody shipRigidbody;

	// Use this for initialization
	void Start () {
        physicsPusher = GetComponent<VRTK_PhysicsPusher>();
        ToggleShipPowerOff();
	}
	
	// Update is called once per frame
	void Update () {
        if (physicsPusher.GetNormalizedValue() == 1) //if button is pressed
        {
            if (!buttonDown)
            {
                if (shipPowered)
                {
                    ToggleShipPowerOff();
                }
                else
                {
                    ToggleShipPowerOn();
                }
                buttonDown = true;
            }
        }
        else
        {
            buttonDown = false;
        }
	}

    public void ToggleShipPowerOn()
    {
        shipPowered = true;
        shipPhysics.enabled = true;
        shipRigidbody.useGravity = false;
    }

    public void ToggleShipPowerOff()
    {
        shipPowered = false;
        shipPhysics.enabled = false;
        shipRigidbody.useGravity = true;
    }
}
