using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaundTrack : MonoBehaviour
{
    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("VolumeMusic"))
        {
            audio.volume = PlayerPrefs.GetFloat("VolumeMusic");
        }
        else
        {
            audio.volume = 1;
        }
    }

}
