using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkModifier : Modifier {

    public GameObject ship;
    public float shrinkModifier = 5;

    // Use this for initialization
    void Start () {
		
	}

    public override void ActivateAbility()
    {

        ship.transform.localScale = ship.transform.localScale / shrinkModifier;
        holderText.text = "SHRINK MODIFIER ACTIVE";
    }

    public override void DisableAbility()
    {
        ship.transform.localScale = ship.transform.localScale * shrinkModifier;
    }
}
