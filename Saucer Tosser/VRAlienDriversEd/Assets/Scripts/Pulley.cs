using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulley : MonoBehaviour {

    public float triggerDistance = 3f;
    public GameObject tractorBeam;
    SpringJoint spring;


    private void Start()
    {
        spring = GetComponent<SpringJoint>();
    }
    // Update is called once per frame
    void Update () {
        if (transform.localPosition.y > triggerDistance)
        {
            ActivateTractorBeam();

        }else{
            DeactivateTractorBeam();
        }
        transform.localPosition = new Vector3(-0.2096769f, transform.localPosition.y, 1.110558f);

    }

    public void ActivateTractorBeam()
    {
        tractorBeam.SetActive(true);
    }

    public void DeactivateTractorBeam()
    {
        GameObject[] tractorBeamables = GameObject.FindGameObjectsWithTag("TractorBeamable");
        foreach (GameObject tractorBeamable in tractorBeamables)
        {
            tractorBeamable.GetComponent<Rigidbody>().useGravity = true;
        }
        tractorBeam.SetActive(false);
    }
}
