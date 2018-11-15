using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectModifier : Modifier
{
    public GameObject toggleObject;
    public string ActiveText;

    private void Start()
    {
        
    }

    public override void ActivateAbility()
    {

        toggleObject.SetActive(true);
        holderText.text = ActiveText;
    }

    public override void DisableAbility()
    {
        toggleObject.SetActive(false);
    }
}
