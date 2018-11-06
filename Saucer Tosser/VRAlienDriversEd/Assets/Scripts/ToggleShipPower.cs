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
    public GameObject[] shipLights;
    public Transform joystick_rot;

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
        GetComponent<AudioSource>().Play();
        shipPhysics.enabled = true;
        shipRigidbody.useGravity = false;
        shipRigidbody.angularDrag = 100;
        //shipRigidbody.drag = 100;
        foreach (GameObject shipLight in shipLights)
        {
            //shipLight.GetComponent<Light>().enabled = true;
            shipLight.SetActive(true);
        }
    }

    public void ToggleShipPowerOff()
    {
        shipPowered = false;
        GetComponent<AudioSource>().Stop();
        shipPhysics.enabled = false;
        
        shipRigidbody.useGravity = true;
        shipRigidbody.angularDrag = 10;
        //shipRigidbody.drag = 0;
        joystick_rot.localRotation = Quaternion.Euler(joystick_rot.rotation.x, joystick_rot.rotation.y, 50);
        foreach (GameObject shipLight in shipLights)
        {
            //shipLight.GetComponent<Light>().enabled = false;
            shipLight.SetActive(false);
        }
    }
}
