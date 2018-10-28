using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;

public class Radio : MonoBehaviour {

    public AudioClip[] songs;
    public VRTK_PhysicsPusher powerButton;
    public VRTK_PhysicsPusher volumeUpButton;
    public VRTK_PhysicsPusher volumeDownButton;
    public VRTK_PhysicsPusher nextSongButton;
    public VRTK_PhysicsPusher lastSongButton;
    bool nextSongPressed = false;
    bool lastSongPressed = false;
    bool volumeUpPressed = false;
    bool volumeDownPressed = false;
    bool powerButtonPressed = false;
    bool isPowered = false;



    int currentSong = 0;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update() {
        if (nextSongButton.GetNormalizedValue() == 1)
        {
            if (!nextSongPressed)
            {
                nextSongPressed = true;
                currentSong++;
                if (currentSong < 0) currentSong = songs.Length-1;
                audioSource.clip = songs[currentSong];
                audioSource.Play();
            }
        }
        else nextSongPressed = false;

        if (lastSongButton.GetNormalizedValue() == 1)
        {
            if (!lastSongPressed)
            {
                lastSongPressed = true;
                currentSong++;
                if (currentSong > songs.Length) currentSong = 0;
                audioSource.clip = songs[currentSong];
                audioSource.Play();
            }
        }
        else lastSongPressed = false;

        if (volumeUpButton.GetNormalizedValue() == 1)
        {
            if (!volumeUpPressed)
            {
                volumeUpPressed = true;
                audioSource.volume -= .2f;
                if (audioSource.volume < 0f) audioSource.volume = 0;
            }
        }
        else volumeUpPressed = false;

        if (volumeUpButton.GetNormalizedValue() == 1)
        {
            if (!volumeUpPressed)
            {
                volumeUpPressed = true;
                audioSource.volume += .2f;
                if (audioSource.volume > 1f) audioSource.volume = 1;
            }
        }
        else volumeDownPressed = false;


        if (powerButton.GetNormalizedValue() == 1)
        {
            if (!powerButtonPressed)
            {
                powerButtonPressed = true;
                isPowered = !isPowered;
                audioSource.enabled = isPowered;
            }
        }
        else powerButtonPressed = false;
    }

}
