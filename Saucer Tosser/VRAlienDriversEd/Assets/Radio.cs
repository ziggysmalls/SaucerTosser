using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {

    public AudioClip[] songs;
    public GameObject powerButton;
    public GameObject volumeUpButton;
    public GameObject volumeDownButton;
    public GameObject nextSongButton;
    public GameObject lastSongButton;

    int currentSong = 0;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == nextSongButton)
            currentSong++;
        if (collision.gameObject == lastSongButton)
            currentSong--;

        if (currentSong > songs.Length) currentSong = 0;
        audioSource.clip = songs[currentSong];
        audioSource.Play();
    }

}
