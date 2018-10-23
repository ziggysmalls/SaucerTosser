using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {

    public AudioClip thisClip;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().clip = thisClip;
	}
	
	// Update is called once per frame
	void Update () {
      
	}

    private void OnCollisionEnter(Collision other)
    { if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
            //Debug.Log("The audio should be playing");
        }
        else { GetComponent<AudioSource>().Stop(); }
    }
}
