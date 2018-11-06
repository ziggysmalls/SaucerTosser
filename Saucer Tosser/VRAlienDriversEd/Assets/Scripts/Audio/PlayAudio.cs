using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {

    public AudioClip[] clips;
    public int collisionType; //This var sets the type of collision to check for. Should be a number 1-9. Look at the collision layers.
    //9 = interactable (player hands, stuff inside the ufo) - use this layer for ship control sounds
    //8 = terrain (structures and the terrain duh) - use this for destructible buildings

	// Update is called once per frame
	void Update () {
      
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == collisionType)
        if (!GetComponent<AudioSource>().isPlaying)
        {
            AudioClip newClip = clips[Random.Range(0,clips.Length)];
            GetComponent<AudioSource>().clip = newClip;
            GetComponent<AudioSource>().Play();
            //Debug.Log("The audio should be playing");
        }
        else { GetComponent<AudioSource>().Stop(); }
    }
}
