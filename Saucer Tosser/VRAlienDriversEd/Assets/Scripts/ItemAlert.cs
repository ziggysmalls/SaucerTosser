using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemAlert : MonoBehaviour {

    Text myText;
    public Light shipLight;
    Color shipLightColor;
    public float timerLength;
    float timer = -1;

	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        shipLightColor = shipLight.color;

    }
	
	// Update is called once per frame
	void Update () {
		if (timer < 0)
        {
            myText.text = "";
            shipLight.color = shipLightColor;
        }
        timer -= Time.deltaTime;
	}

    public void ShowAlert()
    {
        myText.text = "ITEM ACQUIRED";
        shipLight.color = Color.green;
        timer = timerLength;
    }
}
