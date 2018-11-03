using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionWarning : MonoBehaviour {

    Text myText;
    public string[] warnings;
    int warning = 0;
    public float timerLength = 0.8f;
    float timer;
    public Light shipLight;
    Color shipLightColor;

    public ShipPhysics ship;

    // Use this for initialization
    void Start() {
        myText = GetComponent<Text>();
        timer = timerLength;
        shipLightColor = shipLight.color;
    }

    // Update is called once per frame
    
	void Update () {

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            int lastWarning = warning;
            warning = Random.Range(0,warnings.Length);
            if (warning == lastWarning) warning = Random.Range(0, warnings.Length);
            timer = timerLength;
        }
        myText.text = warnings[warning];

        RaycastHit hit;
        Physics.Raycast(transform.position + transform.forward, transform.forward, out hit);
        if ((hit.distance < 30) && (hit.transform.gameObject.layer == 8) && (ship.throttle > 0.1))
        {
            myText.enabled = true;
            shipLight.color = Color.red;
        }
        else
        {
            myText.enabled = false;
            shipLight.color = shipLightColor;
        }
        Debug.DrawRay(transform.position, transform.forward*30);
        Debug.Log(hit.transform.gameObject);
	}
}
