using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warpgate : MonoBehaviour {

    public GameObject targetGate;
    public GameObject npc;
    public float timerLength;
    float timer = 0;
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
		if (timer < 0)
        {
            timer = timerLength;
            if (targetGate != null)
            {
                UFO ufo = Instantiate(npc,transform).GetComponent<UFO>();
                ufo.spawnGate = gameObject.name;
                ufo.targetGate = targetGate;

            }
        }
	}
}
