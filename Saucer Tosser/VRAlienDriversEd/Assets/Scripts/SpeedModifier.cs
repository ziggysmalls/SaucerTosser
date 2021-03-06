﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModifier : Modifier
{
    public ShipPhysics ship;
    public float speedModifier = 3;

    private void Start()
    {
    }

    public override void ActivateAbility()
    {

        ship.maxSpeed = ship.maxSpeed * speedModifier;
        holderText.text = "SPEED MODIFIER ACTIVE";
    }

    public override void DisableAbility()
    {
        ship.maxSpeed = ship.maxSpeed / speedModifier;
    }
}