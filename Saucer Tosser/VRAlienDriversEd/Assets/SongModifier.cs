using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongModifier : Modifier
{
    public string song;
    public string artist;

    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Stop();
    }

    public override void ActivateAbility()
    {
        holderText.text = "NOW PLAYING: " + song + " - " + artist;
        audio.Play();
    }

    public override void DisableAbility()
    {
        audio.Stop();
    }
}