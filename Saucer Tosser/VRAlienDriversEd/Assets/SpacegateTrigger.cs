using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacegateTrigger : MonoBehaviour {

    public Spacegate spacegate;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        spacegate.triggerSpacegate();
        Debug.Log("TRIGGERED!");
    }
}
