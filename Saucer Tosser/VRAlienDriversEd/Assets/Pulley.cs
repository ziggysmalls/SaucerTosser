using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulley : MonoBehaviour {

    public float triggerDistance = 3f;
    public GameObject tractorBeam;

	// Update is called once per frame
	void Update () {
        if (transform.localPosition.y > triggerDistance)
        {
            ActivateTractorBeam();
            Debug.Log("ACTIVE BEAM");
        }else{
            DeactivateTractorBeam();
            Debug.Log("INACTIVE BEAM");
        }
        Debug.Log(transform.localPosition.y);
        Debug.Log(triggerDistance);

    }

    public void ActivateTractorBeam()
    {
        tractorBeam.SetActive(true);
    }

    public void DeactivateTractorBeam()
    {
        tractorBeam.SetActive(false);
    }
}
