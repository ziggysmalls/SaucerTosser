using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceModifier : Modifier {

    public PhysicMaterial ship;


    public override void ActivateAbility()
    {
        ship.bounciness = 10000;
        holderText.text = "BOUNCY MODE ACTIVATED";
    }

    public override void DisableAbility()
    {
        ship.bounciness = 0.5f;
    }
}
